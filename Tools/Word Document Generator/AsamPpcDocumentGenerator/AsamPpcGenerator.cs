using System;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using WordDocumentGenerator.Library;

namespace AsamPpcDocumentGenerator
{
    public class AsamPpcGenerator : DocumentGenerator
    {
        private const string SectionGroupPlaceHolder = "SectionGroup";
        private const string SubSectionGroupPlaceHolder = "SubSectionGroup";
        private const string PropertyGroupPlaceHolder = "PropertyGroup";
        private const string SectionPlaceHolder = "Section";
        private const string QuestionPlaceHolder = "Question";
        private const string EntityPlaceHolder = "Entity";
        private const string PropertyPlaceHolder = "Property";
        private const string TypePlaceHolder = "Type";
        private const string LookupGroupPlaceHolder = "LookupGroup";
        private const string LookupPlaceHolder = "Lookup";
        private const string LookupNameGroupPlaceHolder = "LookupNameGroup";
        private const string LookupNamePlaceHolder = "LookupName";
        private const string LookupCodePlaceHolder = "LookupCode";
        private const string LookupValuePlaceHolder = "LookupValue";
        private const string LookupSortOrderPlaceHolder = "LookupSortOrder";

        private readonly Dictionary<string, string> _indexMap = new Dictionary<string, string>
                                                                {
                                                                    {SectionPlaceHolder, "a"},
                                                                    {QuestionPlaceHolder, "d"},
                                                                    {EntityPlaceHolder, "j"},
                                                                    {PropertyPlaceHolder, "k"},
                                                                    {TypePlaceHolder, "l"},
                                                                    {LookupPlaceHolder, "a"},
                                                                    {LookupNamePlaceHolder, "c"},
                                                                    {LookupCodePlaceHolder, "b"},
                                                                    {LookupValuePlaceHolder, "d"},
                                                                    {LookupSortOrderPlaceHolder, "e"}
                                                                };

        private int _curRow = 2;
        private int _curLookupRow = 2;

        private readonly IEnumerable<Row> _worksheetRows;
        private readonly IEnumerable<Row> _lookupRows;
        private SharedStringTable _sharedStrings;
        private readonly Dictionary<string, string> _lookupPaths = new Dictionary<string, string>();

        public AsamPpcGenerator(DocumentGenerationInfo generationInfo)
            : base(generationInfo)
        {
            var excelDoc = SpreadsheetDocument.Open("ASAM PPC Assessment.xlsx", false);
            //var worksheet = excelDoc.WorkbookPart.Workbook.Sheets.First();
            var sheetId = excelDoc.WorkbookPart.Workbook.Descendants<Sheet>().First(s => s.Name == @"Sheet1").Id;
            var lookupSheetId = excelDoc.WorkbookPart.Workbook.Descendants<Sheet>().First(s => s.Name == @"Sheet2").Id;
            var worksheet = (WorksheetPart)excelDoc.WorkbookPart.GetPartById(sheetId);
            var lookupWorkSheet = (WorksheetPart)excelDoc.WorkbookPart.GetPartById(lookupSheetId);

            _worksheetRows = worksheet.Worksheet.Descendants<Row>();
            _lookupRows = lookupWorkSheet.Worksheet.Descendants<Row>();
            _sharedStrings =
              excelDoc.WorkbookPart.SharedStringTablePart.SharedStringTable;
        }


        protected override Dictionary<string, PlaceHolderType> GetPlaceHolderTagToTypeCollection()
        {
            var tagToTypeCollection = new Dictionary<string, PlaceHolderType>();
            tagToTypeCollection.Add(SectionGroupPlaceHolder, PlaceHolderType.Recursive);
            tagToTypeCollection.Add(SubSectionGroupPlaceHolder, PlaceHolderType.Recursive);
            tagToTypeCollection.Add(PropertyGroupPlaceHolder, PlaceHolderType.Recursive);
            tagToTypeCollection.Add(SectionPlaceHolder, PlaceHolderType.NonRecursive);
            tagToTypeCollection.Add(QuestionPlaceHolder, PlaceHolderType.NonRecursive);
            tagToTypeCollection.Add(EntityPlaceHolder, PlaceHolderType.NonRecursive);
            tagToTypeCollection.Add(PropertyPlaceHolder, PlaceHolderType.NonRecursive);
            tagToTypeCollection.Add(TypePlaceHolder, PlaceHolderType.NonRecursive);


            tagToTypeCollection.Add(LookupCodePlaceHolder, PlaceHolderType.NonRecursive);
            tagToTypeCollection.Add(LookupGroupPlaceHolder, PlaceHolderType.Recursive);
            tagToTypeCollection.Add(LookupNameGroupPlaceHolder, PlaceHolderType.Recursive);
            tagToTypeCollection.Add(LookupNamePlaceHolder, PlaceHolderType.NonRecursive);
            tagToTypeCollection.Add(LookupPlaceHolder, PlaceHolderType.NonRecursive);
            tagToTypeCollection.Add(LookupSortOrderPlaceHolder, PlaceHolderType.NonRecursive);
            tagToTypeCollection.Add(LookupValuePlaceHolder, PlaceHolderType.NonRecursive);
            return tagToTypeCollection;
        }

        protected override void IgnorePlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
            throw new NotImplementedException();
        }

        private string GetCell(string placeholderTag, Row row)
        {
            var cell = row.Descendants<Cell>().FirstOrDefault(c =>
                string.Compare((c as Cell).CellReference.Value.First().ToString(), _indexMap[placeholderTag], true) == 0);

            if (cell == null || cell.CellValue == null)
            {
                return string.Empty;
            }

            var value = cell.DataType != null
                        && cell.DataType.HasValue
                        && cell.DataType == CellValues.SharedString
                            ? _sharedStrings.ChildElements[
                                int.Parse(cell.CellValue.InnerText)].InnerText
                            : cell.CellValue.InnerText;
            return value;
        }

        protected override void NonRecursivePlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
            var row = openXmlElementDataContext.DataContext as Row;

            var value = GetCell(placeholderTag, row);

            SetContentOfContentControl(openXmlElementDataContext.Element as SdtElement, value);

            if(placeholderTag == TypePlaceHolder)
            {
                if(_lookupPaths.ContainsKey(value))
                {
                    var path = _lookupPaths[value];
                    MakeContentHyperlink(openXmlElementDataContext.Element as SdtElement, path);
                }
            }
            if(placeholderTag == LookupPlaceHolder)
            {
                var lookup = value;
                var element = (openXmlElementDataContext.Element as SdtRun).SdtContentRun.FirstChild;
                var bookmark = "_" + lookup;
                _lookupPaths.Add(lookup, bookmark);
                var bookMarkStart = new BookmarkStart {Id = bookmark, Name = bookmark};
                element.FirstChild.InsertBeforeSelf(bookMarkStart);
                bookMarkStart.InsertAfterSelf(new BookmarkEnd { Id = bookmark });
            }
        }

        protected override void RecursivePlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
            if (placeholderTag == SectionGroupPlaceHolder)
            {
                var row = _worksheetRows.First(r => r.RowIndex == _curRow);
                while (_curRow < _worksheetRows.Count())
                {
                    CloneElementAndSetContentInPlaceholders(new OpenXmlElementDataContext() { Element = openXmlElementDataContext.Element, DataContext = row });
                    if (_curRow >= _worksheetRows.Count())
                    {
                        break;
                    }
                    row = _worksheetRows.First(r => r.RowIndex == _curRow);
                    _curRow++;
                }
            }
            else if (placeholderTag == SubSectionGroupPlaceHolder)
            {
                var row = openXmlElementDataContext.DataContext as Row;
                var section = GetCell(SectionPlaceHolder, row);
                while (_curRow < _worksheetRows.Count())
                {
                    CloneElementAndSetContentInPlaceholders(new OpenXmlElementDataContext() { Element = openXmlElementDataContext.Element, DataContext = row });
                    if (_curRow >= _worksheetRows.Count())
                    {
                        break;
                    }
                    row = _worksheetRows.First(r => r.RowIndex == _curRow);
                    var curSection = GetCell(SectionPlaceHolder, row);
                    if (curSection != section)
                    {
                        break;
                    }
                }
            }
            else if (placeholderTag == PropertyGroupPlaceHolder)
            {
                var row = openXmlElementDataContext.DataContext as Row;
                var subSection = GetCell(EntityPlaceHolder, row);
                while (_curRow < _worksheetRows.Count())
                {
                    CloneElementAndSetContentInPlaceholders(new OpenXmlElementDataContext() { Element = openXmlElementDataContext.Element, DataContext = row });
                    do
                    {
                        _curRow++;
                        if (_curRow >= _worksheetRows.Count())
                        {
                            break;
                        }
                        row = _worksheetRows.First(r => r.RowIndex == _curRow);

                    } while (GetCell(PropertyPlaceHolder, row) == string.Empty);
                    var curSubSection = GetCell(EntityPlaceHolder, row);
                    if (curSubSection != subSection)
                    {
                        break;
                    }
                }
            }
            else if (placeholderTag == LookupGroupPlaceHolder)
            {
                var row = _lookupRows.First(r => r.RowIndex == _curLookupRow);
                while (_curLookupRow < _lookupRows.Count())
                {
                    CloneElementAndSetContentInPlaceholders(new OpenXmlElementDataContext() { Element = openXmlElementDataContext.Element, DataContext = row });
                    if (_curLookupRow >= _lookupRows.Count())
                    {
                        break;
                    }
                    row = _lookupRows.First(r => r.RowIndex == _curLookupRow);
                    _curLookupRow++;
                }
            }
            else if (placeholderTag == LookupNameGroupPlaceHolder)
            {
                var row = openXmlElementDataContext.DataContext as Row;
                var lookup = GetCell(LookupPlaceHolder, row);
                while (_curLookupRow < _lookupRows.Count())
                {
                    CloneElementAndSetContentInPlaceholders(new OpenXmlElementDataContext() { Element = openXmlElementDataContext.Element, DataContext = row });
                    _curLookupRow++;
                    if (_curLookupRow >= _lookupRows.Count())
                    {
                        break;
                    }
                    row = _lookupRows.First(r => r.RowIndex == _curLookupRow);

                    var curLookup = GetCell(LookupPlaceHolder, row);
                    if (curLookup != lookup)
                    {
                        break;
                    }
                }
            }

            openXmlElementDataContext.Element.Remove();
        }

        protected override void ContainerPlaceholderFound(string placeholderTag, OpenXmlElementDataContext openXmlElementDataContext)
        {
        }

    }
}
