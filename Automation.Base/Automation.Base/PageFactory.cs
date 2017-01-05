//-----------------------------------------------------------------------
// <copyright>
//     Copyright (c) Coded UI using SpecFlow.
// </copyright>
// <author>Aqdas Iftekhar</author>
//-----------------------------------------------------------------------

namespace Automation.Base
{
    using System;
    using System.Diagnostics;
    using Microsoft.VisualStudio.TestTools.UITesting;
    public class PageFactory
    {
        public static TModule Create<TModule, TMap, TValidator>(string url, bool disposeOnPlayback = true)
            where TModule : BasePage<TMap, TValidator>
            where TMap : BaseMap
            where TValidator : BaseValidator<TMap>
        {
            return CreatePage<TModule, TMap, TValidator>(url, disposeOnPlayback);
        }

        public static TModule Create<TModule, TMap, TValidator>(Process browserProcess)
            where TModule : BasePage<TMap, TValidator>
            where TMap : BaseMap
            where TValidator : BaseValidator<TMap>
        {
            return CreatePage<TModule, TMap, TValidator>(browserProcess);
        }

        private static TModule CreatePage<TModule, TMap, TValidator>(string url, bool disposeOnPlayback = true)
            where TModule : BasePage<TMap, TValidator>
            where TMap : BaseMap
            where TValidator : BaseValidator<TMap>
        {
            var window = BrowserWindow.Launch(new Uri(url));
            window.Maximized = true;
            if (!disposeOnPlayback)
            {
                window.CloseOnPlaybackCleanup = false;
            }
            var map = Activator.CreateInstance(typeof(TMap), window) as TMap;
            var validator = Activator.CreateInstance<TValidator>();
            var page = Activator.CreateInstance<TModule>();
            validator.Map = map;
            page.Map = map;
            page.Validator = validator;
            return page;
        }

        private static TModule CreatePage<TModule, TMap, TValidator>(Process browserProcess)
            where TModule : BasePage<TMap, TValidator>
            where TMap : BaseMap
            where TValidator : BaseValidator<TMap>
        {
            var window = BrowserWindow.FromProcess(browserProcess);
            window.Maximized = true;
            var map = Activator.CreateInstance(typeof(TMap), window) as TMap;
            var validator = Activator.CreateInstance<TValidator>();
            var page = Activator.CreateInstance<TModule>();
            validator.Map = map;
            page.Map = map;
            page.Validator = validator;
            return page;
        }
    }
}
