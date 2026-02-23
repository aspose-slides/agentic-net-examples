using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides.Excel;

namespace ExcelToCsvConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = @"C:\Data";
            string excelPath = Path.Combine(dataDir, "input.xlsx");
            string csvPath = Path.Combine(dataDir, "output.csv");

            // Load the Excel workbook
            Aspose.Slides.Excel.ExcelDataWorkbook workbook = new Aspose.Slides.Excel.ExcelDataWorkbook(excelPath);

            // Get worksheet names
            IEnumerable<string> sheetNames = workbook.GetWorksheetNames();

            // Process each worksheet (example processes the first one)
            foreach (string sheetName in sheetNames)
            {
                // Determine the bounds of non‑empty cells
                int firstRow = int.MaxValue;
                int firstCol = int.MaxValue;
                int lastRow = int.MinValue;
                int lastCol = int.MinValue;

                // Define maximum rows and columns to scan (adjust as needed)
                int maxRows = 1000;
                int maxCols = 100;

                for (int r = 0; r < maxRows; r++)
                {
                    for (int c = 0; c < maxCols; c++)
                    {
                        IExcelDataCell cell = workbook.GetCell(sheetName, r, c);
                        if (cell != null && cell.Value != null)
                        {
                            string cellText = cell.Value.ToString().Trim();
                            if (cellText.Length > 0)
                            {
                                if (r < firstRow) firstRow = r;
                                if (c < firstCol) firstCol = c;
                                if (r > lastRow) lastRow = r;
                                if (c > lastCol) lastCol = c;
                            }
                        }
                    }
                }

                // If no data found, skip this sheet
                if (firstRow == int.MaxValue)
                {
                    continue;
                }

                // Write trimmed data to CSV
                using (StreamWriter writer = new StreamWriter(csvPath, false))
                {
                    for (int r = firstRow; r <= lastRow; r++)
                    {
                        List<string> rowValues = new List<string>();
                        for (int c = firstCol; c <= lastCol; c++)
                        {
                            IExcelDataCell cell = workbook.GetCell(sheetName, r, c);
                            string cellText = string.Empty;
                            if (cell != null && cell.Value != null)
                            {
                                cellText = cell.Value.ToString();
                            }

                            // Escape double quotes by doubling them
                            string escaped = cellText.Replace("\"", "\"\"");

                            // Enclose each field in double quotes
                            rowValues.Add("\"" + escaped + "\"");
                        }

                        string line = string.Join(",", rowValues);
                        writer.WriteLine(line);
                    }
                }

                // Only process the first worksheet for this example
                break;
            }
        }
    }
}