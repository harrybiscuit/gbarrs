using BriteBIT.Stuff.Validation.Castle;
using BriteBIT.Validation;
using Castle.Components.Validator;

namespace BriteBIT.Stuff.CassiniWrapper
{
    public class WebServerConfiguration
    {
        [ValidateFilePath("The Cassisni executable could not be found at the specified path.")]
        [ValidateNonEmpty("The path to the Cassisni executable is missing.")]
        public string CassiniExecutableFilePath { get; set; }

        [ValidateNonEmpty("The file name of the default Web site page is missing.")]
        public string DefaultWebPageFileName { get; set; }

        public bool OpenDefaultPageAutomatically { get; set; }

        /// <summary>
        /// Specifying a port number of 0 (zero) with cause the
        /// Web server to start with an auto-assignedIp address
        /// </summary>
        [ValidateInteger("The port number that the server instance should run on is invalid.")]
        public int PortNumber { get; set; }

        [ValidateDirectory("The specified Web site root directory could not be found.")]
        [ValidateNonEmpty("The name of the Web site root directory is missing.")]
        public string WebSiteRootFolder { get; set; }
    }
}