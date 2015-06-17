// ----------------------------------------------------------------------
// <copyright file="ChartData.cs" author="Atul Verma">
//     Copyright (c) Atul Verma. This utility along with samples demonstrate how to use the Open Xml 2.0 SDK and VS 2010 for document generation. They are unsupported, but you can use them as-is.
// </copyright>
// ------------------------------------------------------------------------

namespace WordDocumentGenerator.Library
{
    /// <summary>
    /// Base class for chart data
    /// </summary>
    public abstract class ChartData
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        public abstract int Count
        {
            get;
        }

        /// <summary>
        /// Determines whether this instance is valid.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsValid();
    }
}
