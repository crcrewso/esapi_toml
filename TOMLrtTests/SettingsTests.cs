using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOMLrt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;

namespace TOMLrt.Tests
{


    [TestClass()]
    [DeploymentItem("Resources\\")]
    public class SettingsTests
    {
        //static string resourceFolder = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
        //static string siteFile = Path.Combine(resourceFolder, "site.toml");


        [TestMethod()]

        public void FileAccess()
        {
            Assert.IsTrue(File.Exists("site.toml"));
        }

        [TestMethod()]
        public void SettingsCanOpenBasicFile()
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "nomachines.toml");
            Settings settings = new Settings(fullPath);
        }

        [TestMethod()]
        public void SettingsBasicFileCanReadSite()
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), "Resources", "nomachines.toml");
            Settings settings = new Settings(fullPath);
            Assert.AreEqual("My Hospital", settings.Site);
        }


        [TestMethod()]
        public void HasMachinesTest()
        {
            Assert.Fail();
        }
    }
}