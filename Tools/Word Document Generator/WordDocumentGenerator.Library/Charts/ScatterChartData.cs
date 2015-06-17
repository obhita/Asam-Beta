// ----------------------------------------------------------------------
// <copyright file="ScatterChartData.cs" author="Atul Verma">
//     Copyright (c) Atul Verma. This utility along with samples demonstrate how to use the Open Xml 2.0 SDK and VS 2010 for document generation. They are unsupported, but you can use them as-is.
// </copyright>
// ------------------------------------------------------------------------

namespace WordDocumentGenerator.Library
{
    using System.Collections.Generic;

    /// <summary>
    /// Scatter chart data
    /// </summary>
    public class ScatterChartData : ChartData
    {
        public string xColumnName = string.Empty;
        public string yColumnName = string.Empty;
        public Dictionary<int, int> xValToYValMap = null;

        /// <summary>
        /// Gets the count.
        /// </summary>
        public override int Count
        {
            get
            {
                return xValToYValMap == null ? 0 : xValToYValMap.Count;
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
            return !(string.IsNullOrEmpty(xColumnName) && string.IsNullOrEmpty(yColumnName) && Count > 0);
        }        
    }
}
