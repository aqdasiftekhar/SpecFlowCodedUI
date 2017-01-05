//-----------------------------------------------------------------------
// <copyright company="Stewart">
//     Copyright (c) AIM+. All rights reserved.
// </copyright>
// <author>Aqdas Iftekhar - CTO 24/7</author>
//-----------------------------------------------------------------------

namespace Automation.Page.Google.Validator
{
    using Base;
    using Map;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Login Validator Class which imnplementes Assertion and validation 
    /// for Login Module.
    /// </summary>
    public class GoogleValidator : BaseValidator<GoogleMap>
    {
        public void AssertNugetSiteInSearchResults(string url)
        {
            Assert.IsTrue(Map.NugetSiteLink(url).Exists, "Expected the nuget in the search results ");
        }
    }
}
