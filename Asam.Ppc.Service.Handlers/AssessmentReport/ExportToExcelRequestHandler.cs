namespace Asam.Ppc.Service.Handlers.AssessmentReport
{
    #region Using Statements

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Common;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using Domain.AssessmentModule;
    using Domain.CommonModule;
    using Domain.CommonModule.ValueObjects;
    using Domain.Scoring.ScoringModule;
    using Infrastructure.Domain;
    using Messages.AssessmentReport;
    using NHibernate;
    using Pillar.Domain;
    using Pillar.Domain.Attributes;
    using Primitives;

    #endregion

    public class ExportToExcelRequestHandler : ServiceRequestHandler<ExportToExcelRequest, FileStreamResponse>
    {
        #region Fields

        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IAssessmentScoreRepository _assessmentScoreRepository;
        private readonly ISession _session;

        #endregion

        #region Constructors and Destructors

        public ExportToExcelRequestHandler ( IAssessmentRepository assessmentRepository, IAssessmentScoreRepository assessmentScoreRepository, ISessionProvider sessionProvider )
        {
            _assessmentRepository = assessmentRepository;
            _assessmentScoreRepository = assessmentScoreRepository;
            _session = sessionProvider.GetSession();
        }

        #endregion

        #region Methods

        protected override void Handle(ExportToExcelRequest request, FileStreamResponse response)
        {
            var assessment = _assessmentRepository.GetByKey(request.AssessmentKey); 
            assessment = (Assessment)_session.GetSessionImplementation().PersistenceContext.Unproxy(assessment);
            object entity = assessment;
            var name = "ASAM";
            if ( request.GetScore )
            {
                entity = _assessmentScoreRepository.GetAssessmentScoreByAssessment ( assessment );
                name = "ASAM Score";
            }
            using ( var stream = new MemoryStream () )
            {
                using ( var spreadsheet = CreateWorkbook ( stream ) )
                {
                    var worksheet = AddWorksheet ( spreadsheet, name );
                    RecurseHelper ( entity, spreadsheet, worksheet );
                    InsertCellInWorksheet ( "A", 3, worksheet );
                    spreadsheet.WorkbookPart.Workbook.Save ();
                }
                stream.Position = 0;
                response.FileStream = stream.ToArray ();
            }
        }

        private static SpreadsheetDocument CreateWorkbook(Stream stream)
        {
            SpreadsheetDocument spreadSheet = null;

            // Create the Excel workbook
            spreadSheet = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook, false);

            // Create the parts and the corresponding objects
            // Workbook
            spreadSheet.AddWorkbookPart();
            spreadSheet.WorkbookPart.Workbook = new Workbook();
            spreadSheet.WorkbookPart.Workbook.Save();

            // Sheets collection
            spreadSheet.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            return spreadSheet;
        }

        private static string FixName ( string name )
        {
            name = name.Replace ( "DiagnosticStatisticalManualOfMentalDisorders", "DSM" );
            name = name.Replace("Dimension", "Dim");
            name = name.Replace("Dimal", "Dimensional");
            name = name.Replace("Scores", "");
            name = name.Replace("Results", "");
            return name.Substring ( 0, Math.Min ( 31, name.Length) );
        }

        private static Worksheet AddWorksheet(SpreadsheetDocument spreadsheet, string name)
        {
            name = FixName ( name );
            var sheets = spreadsheet.WorkbookPart.Workbook.GetFirstChild<Sheets>();

            // Add the worksheetpart
            var worksheetPart = spreadsheet.WorkbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            worksheetPart.Worksheet.Save();

            // Add the sheet and make relation to workbook
            var sheet = new Sheet()
                {
                    Id = spreadsheet.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = (uint)(spreadsheet.WorkbookPart.Workbook.Sheets.Count() + 1),
                    Name = name
                };
            sheets.Append(sheet);
            spreadsheet.WorkbookPart.Workbook.Save();

            return worksheetPart.Worksheet;
        }

        private static void SetCellText(Cell cell,string text, SharedStringTablePart shareStringPart)
        {
            var index = InsertSharedStringItem(text, shareStringPart);
            cell.CellValue = new CellValue(index.ToString());
            cell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
        }

        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }

        private static Cell InsertCellInWorksheet(string columnName, uint rowIndex, Worksheet worksheet)
        {
            var sheetData = worksheet.GetFirstChild<SheetData>();
            var cellReference = columnName + rowIndex;
            Row row;
            Cell refCell = null;
            if (sheetData.Elements<Row>().Count(r => r.RowIndex == rowIndex) != 0)
            {
                row = sheetData.Elements<Row>().First(r => r.RowIndex == rowIndex);
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }
            if (row.Elements<Cell>().Any(c => c.CellReference.Value == columnName + rowIndex))
            {
                refCell = row.Elements<Cell>().First(c => c.CellReference.Value == cellReference);
            }
            else
            {
                //foreach (var cell in row.Elements<Cell>())
                //{
                //    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                //    {
                //        refCell = cell;
                //        break;
                //    }
                //}

                var newCell = new Cell() { CellReference = cellReference };
                //row.InsertBefore(newCell, refCell);
                row.AppendChild(newCell);


                refCell = newCell;
                worksheet.Save();
            }

            return refCell;
        }

        private static string GetExcelColumnName(int columnNumber)
        {
            int dividend = columnNumber;
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

        private void RecurseHelper ( object entity, SpreadsheetDocument spreadsheet, Worksheet worksheet )
        {
            try
            {
                if ( entity == null )
                {
                    return;
                }
                SharedStringTablePart shareStringPart;
                if (spreadsheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Any())
                {
                    shareStringPart = spreadsheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                }
                else
                {
                    shareStringPart = spreadsheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
                }
                var entityProperties = entity.GetType ().GetProperties ().OrderBy ( p => typeof(Entity).IsAssignableFrom ( p.PropertyType ) ? 1 : 0 );
                var column = 1;
                foreach ( var entityProperty in entityProperties )
                {
                    if ( typeof(Entity).IsAssignableFrom ( entityProperty.PropertyType ) )
                    {
                        worksheet.Save ();
                        var revisionBase = entityProperty.GetValue ( entity );
                        if (!NHibernateUtil.IsInitialized(revisionBase))
                        {
                            NHibernateUtil.Initialize ( revisionBase );
                        }
                        revisionBase = _session.GetSessionImplementation().PersistenceContext.Unproxy(revisionBase);
                        var newSheet = AddWorksheet ( spreadsheet, revisionBase.GetType ().Name );
                        RecurseHelper ( revisionBase, spreadsheet, newSheet );
                    }
                    else
                    {
                        var propertyValue = entityProperty.GetValue ( entity );
                        var nameCell = InsertCellInWorksheet ( GetExcelColumnName ( column), 1, worksheet );
                        SetCellText(nameCell, entityProperty.Name, shareStringPart);
                        var valueCell = InsertCellInWorksheet(GetExcelColumnName(column), 2, worksheet);
                        if ( propertyValue == null )
                        {
                            SetCellText(valueCell, "null", shareStringPart);
                        }
                        else if ( typeof(Lookup).IsAssignableFrom ( entityProperty.PropertyType ) )
                        {
                            SetCellText(valueCell, (propertyValue as Lookup).Name, shareStringPart);
                        }
                        else if ( entityProperty.PropertyType.IsGenericType && entityProperty.PropertyType.GetGenericTypeDefinition () == typeof(IEnumerable<>) )
                        {
                            var innerType = entityProperty.PropertyType.GetGenericArguments ().First ();
                            var line = string.Empty;
                            foreach ( var innerValue in ( propertyValue as IEnumerable ) )
                            {
                                if ( typeof(Lookup).IsAssignableFrom ( innerType ) )
                                {
                                    line += ( innerValue as Lookup ).Name + ",";
                                }
                                else
                                {
                                    line += innerValue + ",";
                                }
                            }
                            if ( line.Length > 0 )
                            {
                                line = line.Substring ( 0, line.Length - 1 );
                            }
                            SetCellText(valueCell, line, shareStringPart);
                        }
                        else if ( typeof(IPrimitive).IsAssignableFrom ( entityProperty.PropertyType )
                                  || entityProperty.PropertyType.GetCustomAttribute<ComponentAttribute> () != null )
                        {
                            var prefix = entityProperty.Name + "_";
                            var started = false;
                            foreach ( var propertyInfo in entityProperty.PropertyType.GetProperties () )
                            {
                                if ( started )
                                {
                                    column++;// = GetNextColumn ( column );
                                    nameCell = InsertCellInWorksheet(GetExcelColumnName(column), 1, worksheet);
                                    valueCell = InsertCellInWorksheet(GetExcelColumnName(column), 2, worksheet);
                                }
                                SetCellText(nameCell, prefix + propertyInfo.Name, shareStringPart);
                                var innerValue = propertyInfo.GetValue ( propertyValue );
                                SetCellText(valueCell, innerValue == null ? "null" : innerValue.ToString(), shareStringPart);
                                started = true;
                            }
                        }
                        else
                        {
                            SetCellText(valueCell, propertyValue == null ? "null" : propertyValue.ToString(), shareStringPart);
                        }
                    }
                    column++;// = GetNextColumn ( column );
                }
            }
            catch ( Exception)
            {
                
            }
        }

        #endregion
    }
}