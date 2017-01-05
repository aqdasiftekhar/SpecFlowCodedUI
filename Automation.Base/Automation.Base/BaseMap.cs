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

    /// <summary>
    /// Developed a BaseMap class which holds the reference of ApplicationUnderTest.
    /// The controls are found in the context of container that can be used in the 
    /// concerete classes that implement BaseMap
    /// </summary>
    public abstract class BaseMap
    {
        /// <summary>
        /// ReadOnly object of ApplicationUnderTest. 
        /// </summary>
        protected readonly BrowserWindow Window;

        /// <summary>
        /// Application Process which will hold instance of Process of initialized application.
        /// </summary>
        internal Process ApplicationProcess { get; private set; }

        /// <summary>
        /// Constructor of baseMap Class which set ApplicationUnderTest object and 
        /// Process of Application which is under test.
        /// </summary>
        /// <param name="window"></param>
        protected BaseMap(BrowserWindow window)
        {
            Window = window;
            ApplicationProcess = Window.Process;
        }
    }
}
