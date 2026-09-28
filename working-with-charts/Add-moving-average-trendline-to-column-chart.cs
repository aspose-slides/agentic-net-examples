// -----------------------------------------------------------------------------
// Example: Add Moving Average Trendline to Clustered Column Chart using Aspose.Slides
//
// Description:
// This console application creates a new PowerPoint presentation, inserts a
// clustered column chart, adds a moving average trendline to the first data
// series, configures its period and name, and saves the file as PPTX. It
// demonstrates Aspose.Slides for .NET chart manipulation and trendline usage.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart trendline, moving average, clustered column
//
// Use Cases:
// - Generate analytical presentations with statistical trendlines.
// - Automate chart enhancements in reporting pipelines.
// - Add moving average visualizations to business dashboards.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesTrendlineExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "MovingAverageTrendline.pptx";

            try
            {
                // Ensure the output directory exists
                string outputDirectory = Path.GetDirectoryName(Path.GetFullPath(outputPath));
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a clustered column chart on the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50, 50, 500, 400);

                // Clear default data and add custom categories and series
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Q1"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Q2"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Q3"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Q4"));

                // Add a series with sample data
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Sales"),
                    chart.Type);
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 1, 1, 150));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 2, 1, 200));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 3, 1, 180));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, 4, 1, 220));

                // Add a moving average trendline to the first series
                Aspose.Slides.Charts.ITrendline movingAverageTrendline = chart.ChartData.Series[0].TrendLines.Add(
                    Aspose.Slides.Charts.TrendlineType.MovingAverage);
                movingAverageTrendline.Period = 3; // 3-period moving average
                movingAverageTrendline.TrendlineName = "3-Period Moving Avg";

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
