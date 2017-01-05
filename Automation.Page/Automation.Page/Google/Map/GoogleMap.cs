//-----------------------------------------------------------------------
// <copyright company="Stewart">
//     Copyright (c) AIM+. All rights reserved.
// </copyright>
// <author>Aqdas Iftekhar - CTO 24/7</author>
//-----------------------------------------------------------------------


namespace Automation.Page.Google.Map
{
    using Base;
    using Utils;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System;

    /// <summary>
    /// Login Map class to Which implement baseMap class.
    /// This class is written to find required controls based on conditions 
    /// on Login module. 
    /// </summary>
    public class GoogleMap : BaseMap
    {
        /// <summary>
        /// Contructor of class with ApplicationUnderTest as parameter.
        /// </summary>
        /// <param name="window"></param>
        public GoogleMap(BrowserWindow window)
            : base(window)
        {
        }

        internal HtmlDiv SearchBox()
        {
            var searchConditions = new PropertyExpressionCollection {
                new PropertyExpression(HtmlControl.PropertyNames.Id, "sb_ifc0", PropertyExpressionOperator.EqualTo),
                new PropertyExpression(HtmlControl.PropertyNames.Class, "sbib_b", PropertyExpressionOperator.EqualTo)
            };
            return Window.Find<HtmlDiv>(searchConditions);
        }
        internal HtmlControl SearchButton()
        {
            var searchConditions = new PropertyExpressionCollection {
                new PropertyExpression(HtmlControl.PropertyNames.Name, "btnG", PropertyExpressionOperator.EqualTo),
                new PropertyExpression(HtmlControl.PropertyNames.TagName, "button", PropertyExpressionOperator.EqualTo)
            };
            return Window.Find(searchConditions);
        }

        internal HtmlHyperlink NugetSiteLink(string url)
        {
            var searchConditions = new PropertyExpressionCollection {
                new PropertyExpression("href", url, PropertyExpressionOperator.Contains)
            };
            return Window.Find<HtmlHyperlink>(searchConditions);
        }
        internal void Navigate(string url)
        {
            Window.NavigateToUrl(new Uri(url));
        }
    }
}
