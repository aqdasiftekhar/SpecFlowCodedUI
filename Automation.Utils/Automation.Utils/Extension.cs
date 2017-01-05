//-----------------------------------------------------------------------
// <copyright>
//     Copyright (c) Coded UI using SpecFlow.
// </copyright>
// <author>Aqdas Iftekhar</author>
//-----------------------------------------------------------------------

using System;

namespace Automation.Utils
{
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    public static class Extension
    {
        public static HtmlControl Find(this UITestControl container, PropertyExpressionCollection searchProperties, PropertyExpressionCollection filterProperties = null)
        {
            var control = new HtmlControl { Container = container };
            control.SearchProperties.AddRange(searchProperties);
            if (filterProperties != null)
            {
                control.FilterProperties.AddRange(filterProperties);
            }
            return control;
        }

        public static TControl Find<TControl>(this UITestControl container, PropertyExpressionCollection searchProperties, PropertyExpressionCollection filterProperties = null) 
            where TControl : HtmlControl, new()
        {
            var control = new TControl { Container = container };
            control.SearchProperties.AddRange(searchProperties);
            if (filterProperties != null)
            { control.FilterProperties.AddRange(filterProperties);
            }
            return control;
        }
        public static void Click(this UITestControl control)
        {
            Mouse.Click(control);
        }
        public static void SetText(this UITestControl control, string value)
        {
            Keyboard.SendKeys(control, value);
        }

    }
}
