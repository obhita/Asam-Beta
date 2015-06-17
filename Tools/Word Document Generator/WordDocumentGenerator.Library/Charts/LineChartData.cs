// ----------------------------------------------------------------------
// <copyright file="LineChartData.cs" author="Atul Verma">
//     Copyright (c) Atul Verma. This utility along with samples demonstrate how to use the Open Xml 2.0 SDK and VS 2010 for document generation. They are unsupported, but you can use them as-is.
// </copyright>
// ------------------------------------------------------------------------

namespace WordDocumentGenerator.Library
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Line chart data class
    /// </summary>
    public class LineChartData : ChartData
    {
        public Dictionary<string, List<string>> columnNameToSeries = new Dictionary<string, List<string>>();

        /// <summary>
        /// Gets the count.
        /// </summary>
        public override int Count
        {
            get
            {
                return columnNameToSeries == null ? 0 : columnNameToSeries.Values.FirstOrDefault().Count();
            }
        }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid()
        {
            return (columnNameToSeries != null) && (columnNameToSeries.Keys.Where(key => string.IsNullOrEmpty(key)).Count() == 0) &&
            (columnNameToSeries.Values.Where(value => value == null).Count() == 0) && (columnNameToSeries.Values.Where(value => value.Count != this.Count).Count() == 0);
        }        
    }
}
