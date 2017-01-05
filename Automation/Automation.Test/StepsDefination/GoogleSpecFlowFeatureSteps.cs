using System;
using System.Diagnostics;
using System.IO;
using Automation.Base;
using Automation.Page.Google.Map;
using Automation.Page.Google.Page;
using Automation.Page.Google.Validator;
using Automation.Utils;
using Microsoft.VisualStudio.TestTools.UITesting;
using TechTalk.SpecFlow;
using Automation.Page.Nuget.Page;
using Automation.Page.Nuget.Map;
using Automation.Page.Nuget.Validator;

namespace ESB.Test.StepsDefination
{
    [Binding]
    public class GoogleSpecFlowFeatureSteps
    {
        private  Process _windowProcess;
        private GooglePage google = null;
        private NugetPage nuget = null;
        public GoogleSpecFlowFeatureSteps()
        {          

            if (ExcelUtil._dataCollection.Count == 0)
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
            }
            
        }

        [Given(@"I am on Google Page")]
        public void GivenIAmOnGooglePage()
        {
             google = PageFactory.Create<GooglePage, GoogleMap, GoogleValidator>(ExcelUtil.ReadData(1, "url"), false);
            _windowProcess = google.WindowProcess;
        }

        [Given(@"I have entered nuget in search box")]
        public void GivenIHaveEnteredNugetInSearchBox()
        {
            google.LookFor(ExcelUtil.ReadData(1, "SearchString"));
        }

        [When(@"I click on Search button")]
        public void WhenIClickOnSearchButton()
        {
            google.Search();           
        }
        [Then(@"verify that nuget exist in search results")]
        public void GivenVerifyThatNugetExistInSearchResults()
        {
            Playback.Wait(1500);
            google.ValidateNugetSiteLinkInResults(ExcelUtil.ReadData(1, "ResultUrl"));
        }

        [Then(@"google redirect to nuget page")]
        public void ThenGoogleRedirectToNugetPage()
        {
           nuget = google.VisitNugetSite(ExcelUtil.ReadData(1, "ResultUrl"));
        }

        [Then(@"verify if nuget website is opened successfully")]
        public void ThenVerifyIfNugetWebsiteIsOpenedSuccessfully()
        {
            nuget.VerifyNugetSiteLoaded();
        }


    }
}
