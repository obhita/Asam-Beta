using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordDocumentGenerator.Library.Charts
{
    /// <summary>
    /// Bar chart data
    /// </summary>
    public class BarChartData : ChartData
    {
        public string xColumnName = string.Empty;
        public string yColumnName = string.Empty;
        public Dictionary<string, double> xValToYValMap = null;

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
