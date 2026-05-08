using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;
using Aspose.Slides.Excel;

namespace BatchChartGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string excelPath = Path.Combine(dataDir, "input.xlsx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the Excel file exists
            if (!File.Exists(excelPath))
            {
                Console.WriteLine("Excel file not found: " + excelPath);
                return;
            }

            try
            {
                // Load the Excel workbook
                ExcelDataWorkbook workbook = new ExcelDataWorkbook(excelPath);

                // Create a new presentation
                Presentation pres = new Presentation();

                // Get a blank layout slide to use for new slides
                ILayoutSlide blankLayout = pres.LayoutSlides.GetByType(SlideLayoutType.Blank);

                // Iterate through each worksheet in the workbook
                IEnumerable<string> worksheetNames = workbook.GetWorksheetNames();
                foreach (string wsName in worksheetNames)
                {
                    // Get all charts from the current worksheet
                    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(wsName);
                    foreach (KeyValuePair<int, string> chartInfo in worksheetCharts)
                    {
                        // Add a new empty slide
                        ISlide slide = pres.Slides.AddEmptySlide(blankLayout);

                        // Import the chart from the workbook onto the slide
                        ExcelWorkbookImporter.AddChartFromWorkbook(
                            slide.Shapes,
                            10f,
                            10f,
                            workbook,
                            wsName,
                            chartInfo.Key,
                            false);
                    }
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (ArgumentException ex)
            {
                // Handle unsupported format or missing chart errors
                Console.WriteLine("Argument error: " + ex.Message);
                // Format not supported
            }
            catch (InvalidOperationException ex)
            {
                // Handle external URL or web service errors
                Console.WriteLine("Invalid operation: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}