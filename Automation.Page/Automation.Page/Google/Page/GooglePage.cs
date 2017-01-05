//-----------------------------------------------------------------------
// <copyright company="Stewart">
//     Copyright (c) AIM+. All rights reserved.
// </copyright>
// <author>Aqdas Iftekhar - CTO 24/7</author>
//-----------------------------------------------------------------------

namespace Automation.Page.Google.Page
{
    using Base;
    using Utils;
    using Map;
    using Validator;
    using Nuget.Page;
    using Nuget.Validator;
    using Nuget.Map;
    using Microsoft.VisualStudio.TestTools.UITesting;


    /// <summary>
    /// GooglePage which implements all actions related to Google Search
    /// </summary>
    public class GooglePage : BasePage<GoogleMap, GoogleValidator>
    {
        public GooglePage LookFor(string keyword)
        {
            Map.SearchBox().SetText(keyword);
            return this;
        }
        public GooglePage Search()
        {
            Map.SearchButton().Click();
            return this;
        }
        public GooglePage ValidateNugetSiteLinkInResults(string url)
        {
            Validator.AssertNugetSiteInSearchResults(url);
            return this;
        }
        public NugetPage VisitNugetSite(string url)
        {
            var nugetLink = Map.NugetSiteLink(url);
            Map.Navigate(nugetLink.Href);
            return PageFactory.Create<NugetPage, NugetMap, NugetValidator>(WindowProcess);
        }

    }
}
