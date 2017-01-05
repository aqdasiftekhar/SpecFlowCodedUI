using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Web;
using System.IO;
using Automation.Base;
using Automation.Page.Google.Map;
using Automation.Page.Google.Page;
using Automation.Page.Google.Validator;
using Automation.Utils;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace ESB.Test
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        private static Process _windowProcess;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null)
            {
                if (directoryInfo.Parent != null)
                {
                    string excelPath = directoryInfo.Parent.FullName + @"\Automation.Test\Data\Google.xlsx";
                    ExcelUtil.PopulateInCollection(excelPath);
                }
            }

            //Every control in the hierarchy will be searched in order.
            //Any failure will result in test failure
            Playback.PlaybackSettings.MatchExactHierarchy = true;

            Playback.Initialize();

        }
        [TestMethod]
        public void Google_SearchForNugetSite()
        {
            var google = PageFactory.Create<GooglePage, GoogleMap, GoogleValidator>("http://www.google.com", false);
            _windowProcess = google.WindowProcess;

            google.LookFor("nuget")
                .Search().
                ValidateNugetSiteLinkInResults(ExcelUtil.ReadData(1, "ResultUrl"));

        }
        [TestMethod]
        public void Nuget_SearchPackageOnNugetTest()
        {
            var google = PageFactory.Create<GooglePage, GoogleMap, GoogleValidator>(_windowProcess);
            google.VisitNugetSite(ExcelUtil.ReadData(1, "ResultUrl")).VerifyNugetSiteLoaded();
        }
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            var window = ApplicationUnderTest.FromProcess(_windowProcess);
            window.Close();
        }
    }
}
