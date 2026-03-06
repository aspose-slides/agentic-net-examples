using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Import;
using Aspose.Slides.Charts;
using Aspose.Slides.Excel;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths to the presentation and Excel workbook
            string presentationPath = "ResultPresentation.pptx";
            string workbookPath = "ChartData.xlsx";
            string worksheetName = "Sheet1";
            string chartName = "Chart 1";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a chart from the Excel workbook to the first slide
            Aspose.Slides.Charts.IChart chart = Aspose.Slides.Import.ExcelWorkbookImporter.AddChartFromWorkbook(
                pres.Slides[0].Shapes,
                10f,
                10f,
                workbookPath,
                worksheetName,
                chartName,
                false);

            // Access the chart's data workbook
            Aspose.Slides.Charts.ChartData chartData = (Aspose.Slides.Charts.ChartData)chart.ChartData;
            Aspose.Slides.Charts.IChartDataWorkbook dataWorkbook = chartData.ChartDataWorkbook;

            // Read the embedded workbook into a memory stream
            MemoryStream workbookStream = chartData.ReadWorkbookStream();

            // Save the extracted workbook to a file (optional)
            using (FileStream fileStream = new FileStream("ExtractedWorkbook.xlsx", FileMode.Create, FileAccess.Write))
            {
                workbookStream.WriteTo(fileStream);
            }

            // Set an external workbook as the data source for the chart
            chartData.SetExternalWorkbook(workbookPath);

            // Save the presentation
            pres.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}