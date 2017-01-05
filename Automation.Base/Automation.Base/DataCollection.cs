//-----------------------------------------------------------------------
// <copyright company="Stewart">
//     Copyright (c) AIM+. All rights reserved.
// </copyright>
// <author>Aqdas Iftekhar - CTO 24/7</author>
//-----------------------------------------------------------------------

namespace Automation.Base
{
    /// <summary>
    /// Developed a DataCollection class which holds all CSV or Excel Objects in Collection.
    /// </summary>
    public class DataCollection
    {
        /// <summary>
        /// Row number for each item from csv in list.
        /// </summary>
        public int RowNumber { get; set; }

        /// <summary>
        /// Column Name for each item from csv in list.
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// Column value for each item from csv in list.
        /// </summary>
        public string ColumnValue { get; set; }
    }
}
