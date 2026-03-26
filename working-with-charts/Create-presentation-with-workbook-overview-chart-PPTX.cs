using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Import;
using Aspose.Slides.Excel;
using Aspose.Slides.Export;

namespace WorkbookChartDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the Excel workbook that contains chart data
            string workbookPath = "workbook.xlsx";

            // Verify that the workbook file exists
            if (!File.Exists(workbookPath))
            {
                Console.WriteLine("Error: The workbook file was not found at path: " + workbookPath);
                return;
            }

            // Load the Excel workbook
            IExcelDataWorkbook excelWorkbook = new ExcelDataWorkbook(workbookPath);

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide (created by default)
                ISlide slide = presentation.Slides[0];

                // Name of the worksheet that contains the charts
                string worksheetName = "Sheet1";

                // Retrieve all charts from the specified worksheet
                IDictionary<int, string> chartDictionary = excelWorkbook.GetChartsFromWorksheet(worksheetName);

                // Iterate through each chart in the worksheet and add it to the slide
                foreach (KeyValuePair<int, string> chartEntry in chartDictionary)
                {
                    // Add the chart from the workbook to the slide
                    IChart chart = ExcelWorkbookImporter.AddChartFromWorkbook(
                        slide.Shapes,
                        10,
                        10,
                        excelWorkbook,
                        worksheetName,
                        chartEntry.Key,
                        false);

                    // Set a title for the added chart using the chart name from the workbook
                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding(chartEntry.Value);
                }

                // Save the presentation to disk
                presentation.Save("WorkbookOverviewChart.pptx", SaveFormat.Pptx);
            }
        }
    }
}