// ----------------------------------------------------------------------
// <copyright file="ChartEx.cs" author="Atul Verma">
//     Copyright (c) Atul Verma. This utility along with samples demonstrate how to use the Open Xml 2.0 SDK and VS 2010 for document generation. They are unsupported, but you can use them as-is.
// </copyright>
// ------------------------------------------------------------------------

namespace WordDocumentGenerator.Library
{
    using System;
    using System.Linq;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Drawing.Charts;
    using DocumentFormat.OpenXml.Packaging;
    using SpreadSheet = DocumentFormat.OpenXml.Spreadsheet;

    /// <summary>
    /// Base class for Charts
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ChartEx<T> where T : OpenXmlCompositeElement
    {
        protected readonly ChartPart chartPart = null;

        #region Constructor
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ChartEx&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="chartPart">The chart part.</param>
        public ChartEx(ChartPart chartPart)
        {
            this.chartPart = chartPart;
        }

        #endregion

        #region Public Methods        

        /// <summary>
        /// Refreshes this instance.
        /// </summary>
        public void Refresh()
        {
            ChartData chartData = this.GetChartData();

            if (chartData != null && chartData.IsValid())
            {
                string sheetName = this.UpdateEmbeddedObject();

                Chart chart = chartPart.ChartSpace.Elements<Chart>().FirstOrDefault();

                if (chart != null)
                {
                    this.UpdateChart(chart.Descendants<T>().FirstOrDefault(), sheetName);
                }              
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Gets the chart data.
        /// </summary>
        /// <returns></returns>
        protected abstract ChartData GetChartData();

        /// <summary>
        /// Updates the embedded object.
        /// </summary>
        /// <param name="sheetData">The sheet data.</param>
        /// <param name="sharedStringTablePart">The shared string table part.</param>
        protected abstract void UpdateEmbeddedObject(SpreadSheet.SheetData sheetData, SharedStringTablePart sharedStringTablePart);

        /// <summary>
        /// Updates the chart.
        /// </summary>
        /// <param name="chart">The chart.</param>
        /// <param name="sheetName">Name of the sheet.</param>
        protected abstract void UpdateChart(OpenXmlCompositeElement chart, string sheetName);

        /// <summary>
        /// Updates the embedded object.
        /// </summary>
        /// <returns></returns>
        protected string UpdateEmbeddedObject()
        {
            EmbeddedPackagePart embeddedPackagePart = chartPart.EmbeddedPackagePart;
            string sheetName = string.Empty;

            if (embeddedPackagePart != null)
            {
                using (SpreadsheetDocument spreadsheetDoc = SpreadsheetDocument.Open(embeddedPackagePart.GetStream(), true))
                {
                    SharedStringTablePart sharedStringTablePart;
                    SpreadSheet.Sheet sheet = spreadsheetDoc.WorkbookPart.Workbook.Sheets.FirstOrDefault() as SpreadSheet.Sheet;
                    string sheetId = sheet.Id;
                    sheetName = sheet.Name;

                    WorksheetPart wsp = (WorksheetPart)spreadsheetDoc.WorkbookPart.Parts.Where(pt => pt.RelationshipId == sheetId).FirstOrDefault().OpenXmlPart;
                    SpreadSheet.SheetData sheetData = wsp.Worksheet.Elements<SpreadSheet.SheetData>().FirstOrDefault();
                                        
                    if (spreadsheetDoc.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                    {
                        sharedStringTablePart = spreadsheetDoc.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();

                        if (sharedStringTablePart.SharedStringTable != null)
                        {
                            sharedStringTablePart.SharedStringTable.RemoveAllChildren<SpreadSheet.SharedStringItem>();
                        }
                    }
                    else
                    {
                        sharedStringTablePart = spreadsheetDoc.WorkbookPart.AddNewPart<SharedStringTablePart>();
                    }

                    sheetData.RemoveAllChildren<SpreadSheet.Row>();
                    UpdateEmbeddedObject(sheetData, sharedStringTablePart);

                    wsp.Worksheet.Save();
                }
            }

            return sheetName;
        }

        /// <summary>
        /// Inserts the text.
        /// </summary>
        /// <param name="spreadSheetData">The spread sheet data.</param>
        /// <param name="sharedStringPart">The share string part.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="column">The column.</param>
        /// <param name="text">The text.</param>
        /// <param name="cellValues">The cell values.</param>
        protected static void InsertText(SpreadSheet.SheetData spreadSheetData, SharedStringTablePart sharedStringPart, string column, int rowIndex, string text, SpreadSheet.CellValues cellValues)
        {
            int sharedStringIndex = 0;
            rowIndex += 1;

            if (cellValues == SpreadSheet.CellValues.SharedString)
            {
                sharedStringIndex = InsertSharedStringItem(sharedStringPart, text);
            }

            SpreadSheet.Cell cell = InsertCellInWorksheet(spreadSheetData, column, (uint)rowIndex);
            cell.CellValue = new SpreadSheet.CellValue(cellValues == SpreadSheet.CellValues.SharedString ? sharedStringIndex.ToString() : text);
            cell.DataType = new EnumValue<SpreadSheet.CellValues>(cellValues);
        }

        /// <summary>
        /// Inserts the cell in worksheet.
        /// </summary>
        /// <param name="sheetData">The sheet data.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <returns></returns>
        protected static SpreadSheet.Cell InsertCellInWorksheet(SpreadSheet.SheetData sheetData, string columnName, uint rowIndex)
        {
            string cellReference = columnName + rowIndex;            
            SpreadSheet.Row row;

            if (sheetData.Elements<SpreadSheet.Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<SpreadSheet.Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new SpreadSheet.Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }

            // If column doesn't exist, insert one.  
            if (row.Elements<SpreadSheet.Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<SpreadSheet.Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {                
                SpreadSheet.Cell refCell = null;

                foreach (SpreadSheet.Cell cell in row.Elements<SpreadSheet.Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }

                SpreadSheet.Cell newCell = new SpreadSheet.Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);

                return newCell;
            }
        }

        /// <summary>
        /// Inserts the shared string item.
        /// </summary>
        /// <param name="shareStringPart">The share string part.</param>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        protected static int InsertSharedStringItem(SharedStringTablePart shareStringPart, string text)
        {
            int sharedStringIndex = 0;

            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SpreadSheet.SharedStringTable();
            }            
            
            foreach (SpreadSheet.SharedStringItem item in shareStringPart.SharedStringTable.Elements<SpreadSheet.SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return sharedStringIndex;
                }

                sharedStringIndex++;
            }
                        
            shareStringPart.SharedStringTable.AppendChild(new SpreadSheet.SharedStringItem(new SpreadSheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return sharedStringIndex;
        }

        /// <summary>
        /// Gets the name of the excel column.
        /// </summary>
        /// <param name="columnNumber">The column number.</param>
        /// <returns></returns>
        protected static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber + 1;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        /// <summary>
        /// Gets the string reference.
        /// </summary>
        /// <param name="formulaText">The formula text.</param>
        /// <param name="pointCountVal">The point count val.</param>
        /// <returns></returns>
        protected static StringReference GetStringReference(string formulaText, int pointCountVal)
        {
            StringReference stringReference = new StringReference();
            Formula formula = new Formula();
            formula.Text = formulaText;

            StringCache stringCache = new StringCache();
            PointCount pointCount = new PointCount() { Val = (UInt32Value)(uint)pointCountVal };

            stringCache.Append(pointCount);

            stringReference.Append(formula);
            stringReference.Append(stringCache);
            
            return stringReference;
        }

        /// <summary>
        /// Adds the string point.
        /// </summary>
        /// <param name="stringCache">The string cache.</param>
        /// <param name="index">The index.</param>
        /// <param name="stringPointNumericVal">The string point numeric val.</param>
        protected static void AddStringPoint(StringCache stringCache, int index, string stringPointNumericVal)
        {
            StringPoint stringPoint = new StringPoint();
            stringPoint.Index = new UInt32Value((uint)index);
            stringPoint.NumericValue = new NumericValue(stringPointNumericVal);
            stringCache.Append(stringPoint);
        }

        /// <summary>
        /// Adds the numeric point.
        /// </summary>
        /// <param name="numberingCache">The numbering cache.</param>
        /// <param name="pointCount">The point count.</param>
        /// <param name="rowIndex">Index of the row.</param>
        /// <param name="numericValueText">The numeric value text.</param>
        protected static void AddNumericPoint(NumberingCache numberingCache, PointCount pointCount, int rowIndex, string numericValueText)
        {
            NumericPoint numericPount = new NumericPoint();
            numericPount.Index = new UInt32Value((uint)rowIndex);
            numericPount.NumericValue = new NumericValue(numericValueText);
            numberingCache.AppendChild<NumericPoint>(numericPount);
            pointCount.Val = new UInt32Value((UInt32)(pointCount.Val.Value + 1));
        }

        /// <summary>
        /// Sets the numbering cache.
        /// </summary>
        /// <param name="numberReference">The number reference.</param>
        /// <param name="numberingCache">The numbering cache.</param>
        /// <param name="pointCount">The point count.</param>
        protected static void SetNumberingCache(NumberReference numberReference, out NumberingCache numberingCache, out PointCount pointCount)
        {
            numberingCache = numberReference.Descendants<NumberingCache>().FirstOrDefault();
            
            if (numberingCache == null)
            {
                numberingCache = new NumberingCache();
                numberReference.AppendChild<NumberingCache>(numberingCache);
            }
            
            pointCount = numberingCache.Descendants<PointCount>().FirstOrDefault();

            if (pointCount == null)
            {
                pointCount = new PointCount();
                numberingCache.AppendChild<PointCount>(pointCount);
            }

            pointCount.Val = new UInt32Value((uint)0);
            numberingCache.FormatCode = new FormatCode("General");
        }

        protected static void SetStringCache(StringReference stringReference, out StringCache stringCache, out StringPoint stringPoint)
        {
            stringCache = stringReference.Descendants<StringCache>().FirstOrDefault();

            if (stringCache == null)
            {
                stringCache = new StringCache();
                stringReference.AppendChild<StringCache>(stringCache);
            }

            stringPoint = stringCache.Descendants<StringPoint>().FirstOrDefault();

            if (stringPoint == null)
            {
                stringPoint = new StringPoint();
                stringCache.AppendChild<StringPoint>(stringPoint);
            }

            stringPoint.Index = new UInt32Value((uint)0);
        }

         /// <summary>
         /// Creates the number reference.
         /// </summary>
         /// <param name="values">The values.</param>
         /// <param name="formulaText">The formula text.</param>
         /// <returns></returns>
        protected static NumberReference CreateNumberReference(AxisDataSourceType values, string formulaText)
        {
            values.RemoveAllChildren<NumberReference>();
            NumberReference numberReference = values.AppendChild<NumberReference>(new NumberReference());
            numberReference.Formula = new Formula();
            numberReference.Formula.Text = formulaText;
            return numberReference;
        }

        /// <summary>
        /// Creates the number reference.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="formulaText">The formula text.</param>
        /// <returns></returns>
        protected static NumberReference CreateNumberReference(NumberDataSourceType values, string formulaText)
        {
            values.RemoveAllChildren<NumberReference>();
            NumberReference numberReference = values.AppendChild<NumberReference>(new NumberReference());
            numberReference.Formula = new Formula();
            numberReference.Formula.Text = formulaText;
            return numberReference;
        }

        protected static StringReference CreateStringReference(CategoryAxisData categoryAxisData, string formulaText = "")
        {
            categoryAxisData.RemoveAllChildren<StringReference>();
            var stringReference = categoryAxisData.AppendChild(new StringReference());
            if (!string.IsNullOrWhiteSpace(formulaText))
            {
                stringReference.Formula = new Formula {Text = formulaText};
            }
            return stringReference;
        }

        /// <summary>
        /// Updates the series text.
        /// </summary>
        /// <param name="sheetName">Name of the sheet.</param>
        /// <param name="chartSeries">The chart series.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="pointCountVal">The point count val.</param>
        /// <param name="stringPointNumericVal">The string point numeric val.</param>
        protected static void UpdateSeriesText(string sheetName, OpenXmlCompositeElement chartSeries, string columnName, int pointCountVal, string stringPointNumericVal)
        {
            if (chartSeries != null)
            {
                SeriesText seriesText = chartSeries.Descendants<SeriesText>().FirstOrDefault();

                if (seriesText == null)
                {
                    seriesText = chartSeries.AppendChild<SeriesText>(new SeriesText());
                }
                else
                {
                    seriesText.RemoveAllChildren<StringReference>();
                }
                               
                StringReference stringReference = GetStringReference(sheetName + "!$" + columnName + "$1", pointCountVal);
                AddStringPoint(stringReference.StringCache, 0, stringPointNumericVal);
                seriesText.Append(stringReference);
            }
        }

        #endregion        
    }    
}
