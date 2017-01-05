using Automation.Base;
using Automation.Utils;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Automation.Page.Nuget.Map
{
    public class NugetMap : BaseMap
    {
        public NugetMap(BrowserWindow window) : base(window)
        {
        }

        public HtmlDiv LogoDiv()
        {
            var searchConditions = new PropertyExpressionCollection
            {
                new PropertyExpression(HtmlControl.PropertyNames.Id, "logo", PropertyExpressionOperator.EqualTo)
            };
            return Window.Find<HtmlDiv>(searchConditions);
        }
    }
}
