// -----------------------------------------------------------------------------
// Example: Configure Linear Trendline Forward and Backward Lengths in PowerPoint Chart
//
// Description:
// This console application creates a PPTX file with a clustered column chart,
// adds a linear trendline to the first data series, and sets the trendline's
// forward and backward lengths to five categories. It demonstrates using
// Aspose.Slides for .NET to automate trendline configuration in PowerPoint.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart trendline, linear trendline, forward length, backward length
//
// Use Cases:
// - Automating chart analysis in financial reports
// - Generating presentations with customized trendlines for sales data
// - Programmatically adjusting trendline spans for data visualization
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.Drawing;

namespace TrendlineDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "TrendlineDemo.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a clustered column chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50, 50, 600, 400);

                // Ensure there is at least one series; use default series if present
                if (chart.ChartData.Series.Count == 0)
                {
                    // Add a default series with sample data if none exist
                    Aspose.Slides.Charts.IChartDataWorkbook workbook = chart.ChartData.ChartDataWorkbook;
                    chart.ChartData.Series.Add(workbook.GetCell(0, "A1", "Series 1"), chart.Type);
                    chart.ChartData.Categories.Add(workbook.GetCell(0, "B1", "Category 1"));
                    chart.ChartData.Series[0].DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B2", 10));
                }

                // Add a linear trendline to the first series
                Aspose.Slides.Charts.ITrendline trendline = chart.ChartData.Series[0].TrendLines.Add(
                    Aspose.Slides.Charts.TrendlineType.Linear);

                // Set forward and backward lengths to 5 categories
                trendline.Forward = 5;
                trendline.Backward = 5;

                // Optional: customize trendline appearance
                trendline.Format.Line.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                trendline.Format.Line.FillFormat.SolidFillColor.Color = Color.Red;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved successfully to '{outputPath}'.");
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
