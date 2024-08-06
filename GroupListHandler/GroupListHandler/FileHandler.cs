using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GroupListHandler
{
    public static class FileHandler
    {
        private static readonly Encoding ENCODING = Encoding.UTF8;

        public static string convertExcelFileToCSV(string inputFile)
        {
            Application application = new Application();
            application.DisplayAlerts = false;

            Microsoft.Office.Interop.Excel.Workbook workBook = application.Workbooks.Open(inputFile);
            const int EXCEL_CSV_UTF_8_ENCODING = 62;
            string tempFile = Path.GetTempFileName();
            workBook.SaveAs(tempFile, EXCEL_CSV_UTF_8_ENCODING);
            workBook.Close();
            application.Quit();

            string ret = File.ReadAllText(tempFile);
            try
            {
                File.Delete(tempFile);
            }
            catch
            {
            }
            return ret;
        }

        public static string removeLastLine(string data)
        {
            string trim = data.TrimEnd();
            return trim.Remove(trim.LastIndexOf(Environment.NewLine));
        }

        public static void memoryStreamToFile(MemoryStream ms, string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                ms.Position = 0;
                ms.CopyTo(fs);
            }
        }

        public static string memoryStreamToString(MemoryStream ms)
        {
            return ENCODING.GetString(ms.ToArray());
        }

        public static MemoryStream stringToMemoryStream(string data)
        {
            const int BUFFER_SIZE = 4096;
            MemoryStream ret = new MemoryStream();
            using (StreamWriter sw = new StreamWriter(ret, ENCODING, BUFFER_SIZE, true))
            {
                sw.Write(data);
            }

            ret.Position = 0;
            return ret;
        }

        public static bool convertCSVToXLSX(string outputFile, string workSheetName, IEnumerable<string[]> csvLine)
        {
            if (csvLine == null || csvLine.Count() <= 0)
            {
                return false;
            }

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(outputFile, SpreadsheetDocumentType.Workbook, true))
            {
                document.AddWorkbookPart();
                WorkbookPart workBookPart = document.WorkbookPart;

                DocumentFormat.OpenXml.Spreadsheet.Workbook workBook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();
                workBookPart.Workbook = workBook;

                workBookPart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                foreach (string[] line in csvLine)
                {
                    Row row = new Row();
                    foreach (string column in line)
                    {
                        Cell cell = new Cell(new InlineString(new Text(column)))
                        {
                            DataType = CellValues.InlineString
                        };
                        row.Append(cell);
                    }
                    sheetData.Append(row);
                }
                WorksheetPart workSheetPart = workBookPart.WorksheetParts.First();

                DocumentFormat.OpenXml.Spreadsheet.Worksheet workSheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);
                workSheetPart.Worksheet = workSheet;
                workSheet.Save();

                workBook.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheets());
                workBook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>().AppendChild(new Sheet()
                {
                    Id = workBookPart.GetIdOfPart(workSheetPart),
                    SheetId = 1,
                    Name = workSheetName
                });
                workBook.Save();
            }
            return true;
        }
    }
}