using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using BriteBIT.Stuff.CassiniWrapper;
using Castle.Components.Validator;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace BriteBIT.Stuff.Tests.CassiniWrapper.Tests
{
    [TestFixture]
    public class CassiniWrapperTests
    {
        private const string _assemblyFullName =
            "UltiDevCassiniHttpRequestProcessor2.0, Version=2.1.4.3, Culture=neutral, PublicKeyToken=cc16caed94880aaa";
        private const string _assemblyFilePath = @"Resources\UltiDevCassiniHttpRequestProcessor2.0.dll";
        private const string _expectedProcessName = "UltiDevCassinWebServer2a";

        private WebServer _webServer;

        private static StringBuilder GetContent(Stream responseStream)
        {
            int count;

            var content = new StringBuilder();
            var buffer = new byte[8192];

            do
            {
                count = responseStream.Read(buffer, 0, buffer.Length);
                if (count == 0) continue;
                string tempString = Encoding.ASCII.GetString(buffer, 0, count);
                content.Append(tempString);
            } while (count > 0);

            return content;
        }

        private static WebServerConfiguration GetValidCassisniContext()
        {
            string codeBasePath = string.Format(@"{0}/Resources/UltiDevCassinWebServer2a.exe", Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase));
            UriBuilder uri = new UriBuilder(codeBasePath);
            string executableFilePath = Uri.UnescapeDataString(uri.Path).Replace('/', '\\');
            var webServerConfiguration = new WebServerConfiguration
            {
                CassiniExecutableFilePath =
                    executableFilePath,
                DefaultWebPageFileName = "default.aspx",
                OpenDefaultPageAutomatically = true,
                PortNumber = 8765,
                WebSiteRootFolder = Path.GetFullPath(@"..\..\..\TestingLoginWithWatin")
            };

            return webServerConfiguration;
        }

        private static void KillAllCassiniProcesses()
        {
            while (!(Process.GetProcessesByName(_expectedProcessName).Length == 0))
            {
                foreach (Process process in Process.GetProcessesByName(_expectedProcessName))
                {
                    if (process != null)
                    {
                        lock (new Object())
                        {
                            if (!process.HasExited)
                            {
                                process.Kill();
                            }
                        }
                    }
                }
            }
        }


        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            if (!Gac.IsInGac(_assemblyFullName))
            {
                Gac.InstallAssembly(_assemblyFilePath);
            }

            KillAllCassiniProcesses();
        }

        [Test]
        [ExpectedException(typeof(FileNotFoundException))]
        [Category("Unit")]
        public void StartWebServer_CassisniDefaultWebPageFilePathInvalid_ExceptionThrown()
        {
            // arrange
            WebServerConfiguration configuration = GetValidCassisniContext();
            configuration.DefaultWebPageFileName = @"ThisFileNameIsInvalid.aspx";
            _webServer = new WebServer(configuration);
            // act
            try
            {
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : about to start server");
                _webServer.Start();
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : server has been started");
            }
            finally
            {
                _webServer.Stop();
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : stop was  called");
            }
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        [Category("Unit")]
        public void StartWebServer_CassisniFilePathInvalid_ExceptionThrown()
        {
            // arrange
            WebServerConfiguration configuration = GetValidCassisniContext();
            configuration.CassiniExecutableFilePath = @"C:\This file does not exist";
            _webServer = new WebServer(configuration);

            // act
            try
            {
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : about to start server");
                _webServer.Start();
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : server has been started");
            }
            finally
            {
                _webServer.Stop();
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : stop was  called");
            }
        }

        [Test]
        [ExpectedException(typeof(ValidationException))]
        [Category("Unit")]
        public void StartWebServer_CassisniWebSiteRootFolderInvalid_ExceptionThrown()
        {
            // arrange
            WebServerConfiguration configuration = GetValidCassisniContext();
            configuration.WebSiteRootFolder = @"C:\This directory does not exist";
            _webServer = new WebServer(configuration);

            // act
            try
            {
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : about to start server");
                _webServer.Start();
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : server has been started");
            }
            finally
            {
                _webServer.Stop();
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : stop was  called");
            }
        }

        [Test]
        [Category("Unit")]
        [ExpectedException(typeof(NotImplementedException))]
        public void StartWebServer_PortNumberIsZero_PortNumberAvailableInWebServerContextNotImplemented()
        {
            // arrange
            WebServerConfiguration configuration = GetValidCassisniContext();
            configuration.PortNumber = 0;
            _webServer = new WebServer(configuration);


            // act
            try
            {
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : about to start server");
                _webServer.Start();
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : server has been started");
            }
            finally
            {
                _webServer.Stop();
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : stop was  called");
            }


            // assert
        }

        [Test]
        [Category("Unit")]
        public void StartWebServer_ValidContextSupplied_WebServerStartedAndProcessHostingServiceIsReturned()
        {
            // arrange                 
            WebServerConfiguration configuration = GetValidCassisniContext();

            try
            {
                // act
                Assert.That(Process.GetProcessesByName(_expectedProcessName).Length, Is.EqualTo(0));
                _webServer = new WebServer(configuration);
                Assert.That(_webServer, Is.Not.Null);
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : about to start server");
                _webServer.Start();
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : server has been started");
                Assert.That(Process.GetProcessesByName(_expectedProcessName).Length, Is.EqualTo(1));

                string requestedUri = @"http://localhost:" + configuration.PortNumber + "/" +
                                      configuration.DefaultWebPageFileName;
                var request = (HttpWebRequest)WebRequest.Create(requestedUri);

                WebResponse response = request.GetResponse();
                Assert.That(response, Is.Not.Null);

                Stream responseStream = response.GetResponseStream();
                string theContent = GetContent(responseStream).ToString();

                // assert
                Assert.That(theContent.Contains("Login Page"), Is.True);
            }
            finally
            {
                _webServer.Stop();
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : stop was  called");
            }
        }

        [Test]
        [Category("Unit")]
        public void StopWebServer_WebServerNotStarted_NoExceptionThrown()
        {
            // arrange
            WebServerConfiguration configuration = GetValidCassisniContext();
            _webServer = new WebServer(configuration);

            // act
            try
            {
                _webServer.Stop();
                Trace.WriteLine(MethodBase.GetCurrentMethod().Name + " : stop was  called");
            }
            catch
            {
                Assert.Fail("Calling stop on a server that wasn't started caused an exception.");
            }
        }

        [Test]
        [Category("Unit")]
        public void StopWebServer_WebServerStarted_WebServerStoppedSuccessfully()
        {
            KillAllCassiniProcesses();
            Assert.That(Process.GetProcessesByName(_expectedProcessName).Length,Is.EqualTo(0));

            try
            {
                WebServerConfiguration configuration = GetValidCassisniContext();
                _webServer = new WebServer(configuration);
                _webServer.Start();

                Assert.That(Process.GetProcessesByName(_expectedProcessName).Length, Is.EqualTo(1));
                _webServer.Stop();
                Thread.Sleep(2000);
                Assert.That(Process.GetProcessesByName(_expectedProcessName).Length, Is.EqualTo(0));
            }
            catch (Exception ex)
            {
                
                Assert.Fail(ex.ToString());
            }
            finally
            {
                KillAllCassiniProcesses();
            }
        }
    }
}