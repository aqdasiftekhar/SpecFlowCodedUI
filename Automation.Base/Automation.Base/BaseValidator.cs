//-----------------------------------------------------------------------
// <copyright>
//     Copyright (c) Coded UI using SpecFlow.
// </copyright>
// <author>Aqdas Iftekhar</author>
//-----------------------------------------------------------------------

namespace Automation.Base
{
    /// <summary>
    /// Assertion and Validation of Module are done in this class.
    /// The base validator holds the isntance of the Map object to find 
    /// control to perform assertion against.
    /// </summary>
    /// <typeparam name="TMap">Accept Map Object as paramter.</typeparam>
    public abstract class BaseValidator<TMap> where TMap : BaseMap
    {
        /// <summary>
        /// Get or set Map Object.
        /// </summary>
        public TMap Map { get; set; }

        /// <summary>
        /// Set map object at constructor level.
        /// </summary>
        /// <param name="map"></param>
        protected BaseValidator(TMap map) { Map = map; }

        /// <summary>
        /// internal constructor.
        /// </summary>
        protected BaseValidator() { }
    }
}
