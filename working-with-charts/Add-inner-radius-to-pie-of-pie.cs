// -----------------------------------------------------------------------------
// Example: Add inner radius to pie of pie using C#
//
// Description:
// Demonstrates how to set the inner radius (second pie size) of a Pie of Pie
// chart using C# and Aspose.Slides for .NET. The example creates a new
// presentation, adds a Pie of Pie chart, populates it with data, configures
// the secondary pie size, and saves the file as a PPTX. This pattern can be
// used to automate chart customization in PowerPoint files.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Pie of Pie, Inner Radius,
// Chart Customization, Presentation Processing
//
// Use Cases:
// - Automate setting inner radius for Pie of Pie charts.
// - Build C# tools for PowerPoint chart manipulation.
// - Generate or modify PPTX files with customized chart layouts.
// - Validate chart configurations before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddInnerRadiusToPieOfPie
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "PieOfPieChart.pptx";

            // Delete existing file if it exists
            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a Pie of Pie chart (float literals for position and size)
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.PieOfPie,
                    50f, 50f, 500f, 400f);

                // Get the chart data workbook
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;

                // Clear default series and categories
                chart.ChartData.Series.Clear();
                chart.ChartData.Categories.Clear();

                // Add categories
                chart.ChartData.Categories.Add(workbook.GetCell(0, 1, 0, "Category A"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 2, 0, "Category B"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 3, 0, "Category C"));
                chart.ChartData.Categories.Add(workbook.GetCell(0, 4, 0, "Category D"));

                // Add a series for the Pie of Pie chart
                Aspose.Slides.Charts.IChartSeries series = chart.ChartData.Series.Add(
                    workbook.GetCell(0, 0, 1, "Series 1"),
                    Aspose.Slides.Charts.ChartType.PieOfPie);

                // Configure the series to accept double literals
                series.DataPoints.DataSourceTypeForValues = Aspose.Slides.Charts.DataSourceType.DoubleLiterals;

                // Add data points (double literals)
                series.DataPoints.AddDataPointForPieSeries(40.0);
                series.DataPoints.AddDataPointForPieSeries(30.0);
                series.DataPoints.AddDataPointForPieSeries(20.0);
                series.DataPoints.AddDataPointForPieSeries(10.0);

                // Customize the inner radius of the secondary pie (percentage of the first pie)
                // SecondPieSize is a value between 5 and 200 (percent)
                series.ParentSeriesGroup.SecondPieSize = 150; // 150% of the first pie size

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (ArgumentException ex) when (ex.Message.Contains("DataSourceTypeForValues"))
            {
                // Handle the specific data source type exception
                Console.WriteLine("Data source type configuration error: " + ex.Message);
            }
            catch (NotSupportedException ex)
            {
                // Format not supported
                // Format not supported.
                Console.WriteLine("The requested file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL or web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
