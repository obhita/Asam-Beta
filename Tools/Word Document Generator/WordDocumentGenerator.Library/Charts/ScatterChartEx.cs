// ----------------------------------------------------------------------
// <copyright file="ScatterChartEx.cs" author="Atul Verma">
//     Copyright (c) Atul Verma. This utility along with samples demonstrate how to use the Open Xml 2.0 SDK and VS 2010 for document generation. They are unsupported, but you can use them as-is.
// </copyright>
// ------------------------------------------------------------------------

namespace WordDocumentGenerator.Library
{
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing;
    using DocumentFormat.OpenXml.Drawing.Charts;
    using DocumentFormat.OpenXml.Packaging;
    using SpreadSheet = DocumentFormat.OpenXml.Spreadsheet;

    /// <summary>
    /// Scatter chart
    /// </summary>
    public class ScatterChartEx : ChartEx<ScatterChart>
    {
        ScatterChartData chartData = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScatterChartEx"/> class.
        /// </summary>
        /// <param name="chartPart">The chart part.</param>
        /// <param name="chartData">The chart data.</param>
        public ScatterChartEx(ChartPart chartPart, ScatterChartData chartData)
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
            int rowIndex = 0;
            // Add first row for column names(A, B)
            InsertText(sheetData, sharedStringTablePart, GetExcelColumnName(0), rowIndex, chartData.xColumnName, SpreadSheet.CellValues.SharedString);
            InsertText(sheetData, sharedStringTablePart, GetExcelColumnName(1), rowIndex, chartData.yColumnName, SpreadSheet.CellValues.SharedString);

            rowIndex += 1;
            // Add subsequent rows for column names(A, B)
            foreach (var v in chartData.xValToYValMap)
            {
                InsertText(sheetData, sharedStringTablePart, GetExcelColumnName(0), rowIndex, v.Key.ToString(), SpreadSheet.CellValues.Number);
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
                chart.RemoveAllChildren<ScatterChartSeries>();
                ScatterChartSeries scatterChartSeries = chart.AppendChild<ScatterChartSeries>(new ScatterChartSeries());
                
                Outline outline = new Outline() { Width = 28575 };
                NoFill noFill = new NoFill();
                outline.Append(noFill);
                scatterChartSeries.ChartShapeProperties = new ChartShapeProperties(outline); 

                UpdateSeriesText(sheetName, scatterChartSeries, "B", 1, chartData.yColumnName);

                XValues xValues = scatterChartSeries.AppendChild<XValues>(new XValues());
                YValues yValues = scatterChartSeries.AppendChild<YValues>(new YValues());
                
                NumberReference referenceX = CreateNumberReference(xValues, sheetName + "!$A$2:$A$" + (chartData.Count + 1).ToString());
                NumberReference referenceY = CreateNumberReference(yValues, sheetName + "!$B$2:$B$" + (chartData.Count + 1).ToString());

                NumberingCache ncX;
                PointCount ptXCount;
                NumberingCache ncY;
                PointCount ptYCount;

                SetNumberingCache(referenceX, out ncX, out ptXCount);
                SetNumberingCache(referenceY, out ncY, out ptYCount);

                int rowIndex = 0;

                foreach (var xToY in chartData.xValToYValMap)
                {
                    AddNumericPoint(ncX, ptXCount, rowIndex, xToY.Key.ToString());
                    AddNumericPoint(ncY, ptYCount, rowIndex, xToY.Value.ToString());
                    rowIndex += 1;
                }
            }
        }
    }
}
