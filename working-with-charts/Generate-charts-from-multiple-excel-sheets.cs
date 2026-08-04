// -----------------------------------------------------------------------------
// Example: Generate charts from multiple Excel sheets using C#
//
// Description:
// Demonstrates how to import charts from each worksheet of an Excel workbook
// into a PowerPoint presentation using Aspose.Slides for .NET. The example
// iterates through all worksheets, extracts each chart, adds a new slide per
// chart, and saves the resulting presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Generate, Charts, Multiple,
// Excel, Workbook, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of PowerPoint decks from Excel chart data.
// - Build C# utilities that convert Excel worksheets into slide decks.
// - Integrate chart extraction into .NET reporting pipelines.
// - Validate and preview Excel chart content in presentations.
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        string excelPath = "data.xlsx";
        string outputPath = "result.pptx";

        // Check if the Excel file exists
        if (!File.Exists(excelPath))
        {
            Console.WriteLine("Excel file not found: " + excelPath);
            return;
        }

        try
        {
            // Load the Excel workbook
            Aspose.Slides.Excel.IExcelDataWorkbook excelWorkbook = new Aspose.Slides.Excel.ExcelDataWorkbook(excelPath);
            IList<string> sheetNames = excelWorkbook.GetWorksheetNames();

            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Iterate through each worksheet
                foreach (string sheetName in sheetNames)
                {
                    // Retrieve charts from the current worksheet
                    IDictionary<int, string> chartMap = excelWorkbook.GetChartsFromWorksheet(sheetName);

                    // Iterate through each chart in the worksheet
                    foreach (KeyValuePair<int, string> chartInfo in chartMap)
                    {
                        // Add a new slide for the chart
                        Aspose.Slides.ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

                        // Import the chart from the Excel workbook onto the slide
                        Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
                            slide.Shapes,
                            10f,
                            10f,
                            excelWorkbook,
                            sheetName,
                            chartInfo.Key,
                            false);
                    }
                }

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (ArgumentException ex)
        {
            // Handle unsupported format or missing chart
            Console.WriteLine("Error: " + ex.Message);
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., web service errors)
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }
}
