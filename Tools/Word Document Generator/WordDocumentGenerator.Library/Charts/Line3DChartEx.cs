// ----------------------------------------------------------------------
// <copyright file="Line3DChartEx.cs" author="Atul Verma">
//     Copyright (c) Atul Verma. This utility along with samples demonstrate how to use the Open Xml 2.0 SDK and VS 2010 for document generation. They are unsupported, but you can use them as-is.
// </copyright>
// ------------------------------------------------------------------------

namespace WordDocumentGenerator.Library
{
    using System.Linq;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing.Charts;
    using DocumentFormat.OpenXml.Packaging;
    using SpreadSheet = DocumentFormat.OpenXml.Spreadsheet;

    /// <summary>
    /// Line Chart
    /// </summary>
    public class Line3DChartEx : ChartEx<Line3DChart>
    {
        LineChartData chartData = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Line3DChartEx"/> class.
        /// </summary>
        /// <param name="chartPart">The chart part.</param>
        /// <param name="chartData">The chart data.</param>
        public Line3DChartEx(ChartPart chartPart, LineChartData chartData)
            : base(chartPart)
        {
            this.chartData = chartData;
        }

        /// <summary>
        /// Gets the chart data.
        /// </summary>
        /// <returns></returns>
        protected override ChartData GetChartData()
        {
            return this.chartData;
        }

        /// <summary>
        /// Updates the embedded object.
        /// </summary>
        /// <param name="sheetData">The sheet data.</param>
        /// <param name="sharedStringTablePart">The shared string table part.</param>
        protected override void UpdateEmbeddedObject(SpreadSheet.SheetData sheetData, SharedStringTablePart sharedStringTablePart)
        {
            int seriesIndex = 0;

            foreach (string seriesKey in chartData.columnNameToSeries.Keys)
            {
                // Add first row for column names(A, B ...)
                InsertText(sheetData, sharedStringTablePart, GetExcelColumnName(seriesIndex), 0, seriesKey, SpreadSheet.CellValues.SharedString);

                for (int seriesPointIndex = 0; seriesPointIndex < chartData.columnNameToSeries[seriesKey].Count; seriesPointIndex++)
                {
                    // Add subsequent rows for column names(A, B ...)
                    // Index 0 is category axis data
                    InsertText(sheetData, sharedStringTablePart, GetExcelColumnName(seriesIndex), seriesPointIndex + 1, chartData.columnNameToSeries[seriesKey][seriesPointIndex].ToString(), seriesIndex == 0 ? SpreadSheet.CellValues.SharedString : SpreadSheet.CellValues.Number);
                }

                seriesIndex += 1;
            }
        }

        /// <summary>
        /// Updates the chart.
        /// </summary>
        /// <param name="chart">The chart.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        protected override void UpdateChart(OpenXmlCompositeElement chart, string sheetName)
        {
            if (chart != null)
            {
                chart.RemoveAllChildren<LineChartSeries>();

                // Index 0 is for category axis data
                for (int index = 1; index < chartData.columnNameToSeries.Count(); index++)
                {
                    string columnName = GetExcelColumnName(index);
                    LineChartSeries lineChartSeries = chart.AppendChild<LineChartSeries>(new LineChartSeries());

                    UpdateSeriesText(sheetName, lineChartSeries, columnName, 1, chartData.columnNameToSeries.Skip(index).FirstOrDefault().Key);

                    // Update Category Axis data
                    CategoryAxisData catAxisData = new CategoryAxisData();
                    catAxisData.RemoveAllChildren<StringReference>();
                    catAxisData.RemoveAllChildren<NumberReference>();

                    StringReference catStringReference = GetStringReference(sheetName + "!$A$2:$A$" + (chartData.Count + 1).ToString(), chartData.Count);

                    // Series 0 is for category axis data
                    foreach (string cat in chartData.columnNameToSeries.First().Value)
                    {
                        AddStringPoint(catStringReference.StringCache, catStringReference.StringCache.Descendants<StringPoint>().Count(), cat);
                    }

                    catAxisData.Append(catStringReference);

                    // Update Values
                    NumberingCache numberingCache;
                    PointCount pointCount;
                    Values values = lineChartSeries.AppendChild<Values>(new Values());
                    NumberReference reference = CreateNumberReference(values, sheetName + "!$" + columnName + "$2:$" + columnName + "$" + (chartData.Count + 1).ToString());

                    SetNumberingCache(reference, out numberingCache, out pointCount);

                    int rowIndex = 0;

                    foreach (var point in chartData.columnNameToSeries.Skip(index).FirstOrDefault().Value)
                    {
                        AddNumericPoint(numberingCache, pointCount, rowIndex, point.ToString());
                        rowIndex += 1;
                    }
                }
            }
        }
    }
}
