﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using Castle.Components.Validator;

namespace BriteBIT.Stuff.CassiniWrapper
{
    public class WebServer
    {
        private const string _assemblyFilePath = @"Resources\UltiDevCassiniHttpRequestProcessor2.0.dll";
        private const string _assemblyFullName =
            "UltiDevCassiniHttpRequestProcessor2.0, Version=2.1.4.3, Culture=neutral, PublicKeyToken=cc16caed94880aaa";

        private readonly ProcessStartInfo _startInfo;
        private Process _process;

        public WebServer(WebServerConfiguration webServerConfiguration)
        {
            ValidateContext(webServerConfiguration);

            if (!Gac.IsInGac(_assemblyFullName))
            {
                Gac.InstallAssembly(_assemblyFilePath);
            }

            string openInBrowser = (webServerConfiguration.OpenDefaultPageAutomatically) ? " nobrowser" : string.Empty;
            _startInfo = new ProcessStartInfo
            {
                FileName = webServerConfiguration.CassiniExecutableFilePath,
                Arguments =
                    (@"/run " + webServerConfiguration.WebSiteRootFolder + " " +
                     webServerConfiguration.DefaultWebPageFileName + " " +
                     webServerConfiguration.PortNumber + openInBrowser)
            };
            PortNumber = webServerConfiguration.PortNumber;
        }

        public void Start()
        {
            _process = new Process { StartInfo = _startInfo };
            Debug.Assert(_process.Start());
            Trace.WriteLine("Web server process started : " + _process.Id + " : " + _process.ProcessName);
            PortNumber = (PortNumber > 0) ? PortNumber : getAutoGeneratedPortNumber();
        }

        public void Stop()
        {
            if (_process == null) return;

            lock (new Object())
            {
                if (!_process.HasExited)
                {
                    _process.Kill();
                }
            }
        }
        
        public int PortNumber { get; private set; }

        private static int getAutoGeneratedPortNumber()
        {
            throw new NotImplementedException();
        }

        private static void ValidateContext(WebServerConfiguration context)
        {
            var validator = new ValidatorRunner(true, new CachedValidationRegistry());
            if (!validator.IsValid(context))
            {
                string[] errorList = validator.GetErrorSummary(context).ErrorMessages;
                var messageBuilder = new StringBuilder("The CassisniContext contained invalid data. ");
                foreach (string item in errorList)
                {
                    messageBuilder.AppendLine(item);
                }

                throw new ValidationException(messageBuilder.ToString());
            }

            if (context.PortNumber == 0)
            {
                string message =
                    "You must specify a port number. Auto-configured port numbers are not supported untill I figure out how to return the selected port number.";
                throw new NotImplementedException(message);
            }

            if (!File.Exists(Path.Combine(context.WebSiteRootFolder, context.DefaultWebPageFileName)))
            {
                string message = string.Format("Could not find the default page '{0}'",
                                               Path.Combine(context.WebSiteRootFolder, context.DefaultWebPageFileName));
                throw new FileNotFoundException(message);
            }
        }


    }
}