using System;
using System.IO;
using System.Reflection;
using BriteBIT.Stuff.CassiniWrapper;
using NUnit.Framework;
using WatiN.Core;
using NUnit.Framework.SyntaxHelpers;

namespace TestingLoginWithWatinTests
{
    [TestFixture]
    public class LoginTests
    {
        private WebServer _webServer;
        private const int _portNumber = 9876;

        #region Setup/Teardown

        [SetUp]
        public void SetupFixture()
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
                PortNumber = _portNumber,
                WebSiteRootFolder = Path.GetFullPath(@"..\..\..\TestingLoginWithWatin")
            };

            _webServer = new WebServer(webServerConfiguration);
            _webServer.Start();
        }

        [TearDown]
        public void TeardownFixture()
        {
            if(_webServer!=null )
            {
                _webServer.Stop();
            }
        }

        #endregion

        [Test]
        [Category("System")]
        public void Login_PasswordIdIsCalledPassword_WatinPopulatesPasswordField()
        {

            // arrange
            var ie = new IE("about:blank");
            try
            {
                ie.GoTo(string.Format("http://localhost:{0}/", _portNumber));
                ie.TextField(Find.ById("loginId")).TypeText("fred");
                ie.TextField(Find.ById("password")).TypeText("thepassword");

                // act
                ie.Button(Find.ByName("submitLoginDetails")).Click();

                // assert
                Assert.That(ie.Text.Contains("You have logged in"), Is.True);

            }
            finally
            {
                ie.Close();                
            }

            


        }
    }
}