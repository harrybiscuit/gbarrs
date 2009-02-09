using System;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using NUnit.Framework;

namespace TestingLoginWithWatinTests
{
    [TestFixture]
    public class WebAiiFramework
    {
        private static void RunTest(Manager myManager)
        {
            if (myManager == null) throw new ArgumentNullException("myManager");
            // Start the manager
            myManager.Start();
            // Launch a new browser instance. [This will launch an IE instance given the setting above]
            myManager.LaunchNewBrowser();
            // Navigate to a certain web page
            myManager.ActiveBrowser.NavigateTo("http://www.google.com");

            // Perform your automation actions.
            Element mybtn = myManager.ActiveBrowser.Find.ByTagIndex("input", 3);
            myManager.ActiveBrowser.Actions.Click(mybtn);

            // Shut-down the manager and do all clean-up
            myManager.Dispose();
        }

        [Test]
        public void firstTest()
        {
            // Initialize the settings you want used.

            var myIeSettings = new Settings(BrowserType.InternetExplorer, @"c:\log\");
            var myFfSettings = new Settings(BrowserType.FireFox, @"c:\lol\");


            // Create the manager object

            var myIeManager = new Manager(myIeSettings);
            var myFfManager = new Manager(myFfSettings);


            RunTest(myIeManager);
            RunTest(myFfManager);
        }
    }
}