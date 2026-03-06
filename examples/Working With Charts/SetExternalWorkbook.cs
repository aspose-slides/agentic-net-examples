using System;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a directory to store the workbook and output presentation
            string dataDir = "Data";
            System.IO.Directory.CreateDirectory(dataDir);

            // Define the path for the external Excel workbook
            string workbookPath = System.IO.Path.Combine(dataDir, "workbook.xlsx");

            // Create an empty workbook file if it does not exist (placeholder)
            if (!System.IO.File.Exists(workbookPath))
            {
                System.IO.File.WriteAllBytes(workbookPath, new byte[0]);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a Pie chart to the first slide
            Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                Aspose.Slides.Charts.ChartType.Pie, 50, 50, 400, 600);

            // Access the chart data
            Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

            // Set the external workbook as the data source for the chart
            ((Aspose.Slides.Charts.ChartData)chartData).SetExternalWorkbook(workbookPath);

            // Get the workbook associated with the chart data
            Aspose.Slides.Charts.IChartDataWorkbook workbook = chartData.ChartDataWorkbook;

            // Add a series and categories using cells from the workbook
            chartData.Series.Add(workbook.GetCell(0, 0, 1, "Series 1"), Aspose.Slides.Charts.ChartType.Pie);
            chartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category 1"));
            chartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category 2"));
            chartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category 3"));

            // Add data points for the series
            chartData.Series[0].DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 1, 1, 20));
            chartData.Series[0].DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 2, 1, 30));
            chartData.Series[0].DataPoints.AddDataPointForPieSeries(workbook.GetCell(0, 3, 1, 40));

            // Save the presentation
            string outputPath = System.IO.Path.Combine(dataDir, "ExternalWorkbookChart.pptx");
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}