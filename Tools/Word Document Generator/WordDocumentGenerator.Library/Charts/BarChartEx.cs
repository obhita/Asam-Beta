using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Packaging;
using SpreadSheet = DocumentFormat.OpenXml.Spreadsheet;

namespace WordDocumentGenerator.Library.Charts
{
    /// <summary>
    /// Scatter chart
    /// </summary>
    public class BarChartEx : ChartEx<BarChart>
    {
        BarChartData chartData = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScatterChartEx"/> class.
        /// </summary>
        /// <param name="chartPart">The chart part.</param>
        /// <param name="chartData">The chart data.</param>
        public BarChartEx(ChartPart chartPart, BarChartData chartData)
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
            var rowIndex = 0;
            // Add first row for column names(A, B)
            InsertText(sheetData, sharedStringTablePart, GetExcelColumnName(0), rowIndex, chartData.xColumnName, SpreadSheet.CellValues.SharedString);
            InsertText(sheetData, sharedStringTablePart, GetExcelColumnName(1), rowIndex, chartData.yColumnName, SpreadSheet.CellValues.SharedString);

            rowIndex += 1;
            // Add subsequent rows for column names(A, B)
            foreach (var v in chartData.xValToYValMap)
            {
                InsertText(sheetData, sharedStringTablePart, GetExcelColumnName(0), rowIndex, v.Key.ToString(), SpreadSheet.CellValues.String);
                InsertText(sheetData, sharedStringTablePart, GetExcelColumnName(1), rowIndex, v.Value.ToString(), SpreadSheet.CellValues.Number);
                rowIndex += 1;
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
                chart.RemoveAllChildren<BarChartSeries>();

                var barChartSeries = chart.InsertAt ( new BarChartSeries(), 3 );
                barChartSeries.Index = new Index {Val = 1};
                barChartSeries.Order = new Order {Val = 1};
                barChartSeries.SeriesText = new SeriesText(new NumericValue { Text = chartData.xColumnName });

                var categoryAxisData = barChartSeries.AppendChild(new CategoryAxisData());
                var values = barChartSeries.AppendChild(new Values());
                var stringReference = categoryAxisData.AppendChild(new StringReference());
                var numberReference = values.AppendChild(new NumberReference());

                var stringCache = stringReference.AppendChild(new StringCache());
                var numberingCache = numberReference.AppendChild(new NumberingCache());

                uint rowIndex = 0;
                foreach (var xToY in chartData.xValToYValMap)
                {
                    var stringPoint = stringCache.AppendChild(new StringPoint { Index = rowIndex });
                    stringPoint.AppendChild(new NumericValue { Text = xToY.Key });

                    var numericPoint = numberingCache.AppendChild(new NumericPoint { Index = rowIndex });
                    numericPoint.AppendChild(new NumericValue { Text = xToY.Value.ToString() });
                    rowIndex++;
                }
            }
        }
    }
}
