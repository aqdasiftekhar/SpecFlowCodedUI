using Automation.Base;
using Automation.Page.Nuget.Map;
using Automation.Page.Nuget.Validator;

namespace Automation.Page.Nuget.Page
{
    public class NugetPage : BasePage<NugetMap, NugetValidator>
    {
        public NugetPage VerifyNugetSiteLoaded()
        {
            Validator.AssertNugetLogoOnSite();
            return this;
        }
    }
}
