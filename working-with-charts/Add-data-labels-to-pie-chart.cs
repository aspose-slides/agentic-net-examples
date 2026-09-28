// -----------------------------------------------------------------------------
// Example: Add Data Labels to Pie Chart using Aspose.Slides for .NET
//
// Description:
// This console application creates a new PowerPoint presentation, adds a
// pie chart, populates it with sample categories and values, and enables data
// labels to show both category names and values. The result is saved as a PPTX
// file. Useful for automating chart generation in reporting or .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, pie chart, data labels
//
// Use Cases:
// - Generate sales distribution charts programmatically.
// - Create automated PowerPoint reports with labeled pie charts.
// - Integrate chart creation into a .NET backend service.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesPieChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "PieChartWithDataLabels.pptx";

            try
            {
                // Ensure the output directory exists
                string outputDirectory = Path.GetDirectoryName(Path.GetFullPath(outputPath));
                if (!String.IsNullOrEmpty(outputDirectory) && !Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a pie chart to the slide
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Pie,
                    50f, 50f, 500f, 400f);

                // Access chart data
                Aspose.Slides.Charts.IChartData chartData = chart.ChartData;

                // Clear default series and categories
                chartData.Series.Clear();
                chartData.Categories.Clear();

                // Sample data
                string[] categories = new string[] { "Apples", "Bananas", "Cherries", "Dates" };
                double[] values = new double[] { 30, 20, 25, 25 };

                // Add categories
                for (int i = 0; i < categories.Length; i++)
                {
                    Aspose.Slides.Charts.IChartCategory category = chartData.Categories.Add(
                        chartData.ChartDataWorkbook.GetCell(0, i, 0, categories[i]));
                }

                // Add a series
                Aspose.Slides.Charts.IChartSeries series = chartData.Series.Add(
                    chartData.ChartDataWorkbook.GetCell(0, 0, 1, "Series 1"),
                    chart.Type);

                // Add data points for the series
                for (int i = 0; i < values.Length; i++)
                {
                    series.DataPoints.AddDataPointForPieSeries(
                        chartData.ChartDataWorkbook.GetCell(0, i, 1, values[i]));
                }

                // Enable data labels: show category name and value
                series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;
                series.Labels.DefaultDataLabelFormat.ShowValue = true;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to: " + Path.GetFullPath(outputPath));
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
