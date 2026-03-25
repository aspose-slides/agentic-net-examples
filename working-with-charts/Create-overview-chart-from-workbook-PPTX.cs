using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Import;
using Aspose.Slides.Excel;
using Aspose.Slides.Charts;

namespace CreateOverviewChartFromWorkbook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the Excel workbook that contains chart data
            string workbookPath = "data.xlsx";

            // Verify that the workbook file exists
            if (!File.Exists(workbookPath))
            {
                Console.WriteLine("Error: The workbook file \"{0}\" was not found.", workbookPath);
                return;
            }

            // Name of the worksheet that holds the chart(s)
            string worksheetName = "Sheet1";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Load the Excel workbook
                IExcelDataWorkbook excelWorkbook = new ExcelDataWorkbook(workbookPath);

                // Retrieve all charts from the specified worksheet
                IDictionary<int, string> chartsInWorksheet = excelWorkbook.GetChartsFromWorksheet(worksheetName);

                // Add each chart from the workbook to the first slide
                foreach (KeyValuePair<int, string> chartEntry in chartsInWorksheet)
                {
                    int chartIndex = chartEntry.Key;
                    // Add the chart to the slide at position (50,50)
                    IChart chart = ExcelWorkbookImporter.AddChartFromWorkbook(
                        pres.Slides[0].Shapes,
                        50f,
                        50f,
                        excelWorkbook,
                        worksheetName,
                        chartIndex,
                        false);
                    // Optional: set chart title to the original chart name
                    chart.HasTitle = true;
                    chart.ChartTitle.AddTextFrameForOverriding(chartEntry.Value);
                }

                // Save the presentation
                pres.Save("OverviewChart.pptx", SaveFormat.Pptx);
            }
        }
    }
}