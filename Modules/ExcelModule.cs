using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExcelProcessor
{
    public static class ExcelModule
    {
        // Чтение листов из Excel-файла
        public static List<Excel.Worksheet> ReadSheets(string filePath)
        {
            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Open(filePath);
            var sheets = new List<Excel.Worksheet>();

            foreach (Excel.Worksheet sheet in workbook.Sheets)
            {
                if (SettingsModule.IncludeHiddenSheets || sheet.Visible == Excel.XlSheetVisibility.xlSheetVisible)
                {
                    sheets.Add(sheet);
                }
            }

            workbook.Close(false);
            excelApp.Quit();

            return sheets;
        }

        // Запись листов в новый Excel-файл
        public static void WriteSheets(string filePath, List<Excel.Worksheet> sheets)
        {
            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Add();

            foreach (var sheet in sheets)
            {
                var newSheet = (Excel.Worksheet)workbook.Sheets.Add();
                newSheet.Name = sheet.Name;

                // Копирование данных из исходного листа в новый лист
                var sourceRange = sheet.UsedRange;
                var destRange = newSheet.Range[sourceRange.Address];
                destRange.Value2 = sourceRange.Value2;
            }

            workbook.SaveAs(filePath);
            workbook.Close(false);
            excelApp.Quit();
        }
    }
}