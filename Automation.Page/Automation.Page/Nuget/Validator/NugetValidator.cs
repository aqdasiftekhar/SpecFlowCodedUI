using Automation.Base;
using Automation.Page.Nuget.Map;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automation.Page.Nuget.Validator
{
    public class NugetValidator : BaseValidator<NugetMap>
    {
        public void AssertNugetLogoOnSite()
        {
            Assert.IsTrue(Map.LogoDiv().Exists, "Expected a logo on the website");
        }
    }
}
