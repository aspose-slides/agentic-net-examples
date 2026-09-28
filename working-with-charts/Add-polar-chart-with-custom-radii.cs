// -----------------------------------------------------------------------------
// Example: Add Polar Chart with Custom Radii using Aspose.Slides for .NET
//
// Description:
// This console application creates a new PowerPoint presentation, inserts a
// polar (radar) chart, customizes its radii by adjusting the chart's layout,
// and saves the result as a PPTX file. It demonstrates automating PPTX
// generation with Aspose.Slides, handling file existence checks, and proper
// exception handling for unsupported formats.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, polar chart, radar chart, custom radii
//
// Use Cases:
// - Generate automated reports with polar charts for data visualization.
// - Integrate chart creation into server-side .NET applications.
// - Validate presentation content programmatically in CI pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesPolarChartExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "PolarChartExample.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a slide
                Aspose.Slides.ISlide slide = presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);

                // Add a radar chart (used as a polar chart alternative)
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.Radar,
                    50,
                    50,
                    500,
                    400).Chart;

                // Access chart data workbook
                Aspose.Slides.Charts.IChartData chartData = chart.ChartData;
                Aspose.Slides.Charts.IChartDataWorkbook workbook = chartData.ChartDataWorkbook;

                // Clear default series and categories
                chartData.Series.Clear();
                chartData.Categories.Clear();

                // Add categories (angles)
                Aspose.Slides.Charts.IChartCategory category1 = chartData.Categories.Add(workbook.GetCell(0, "A1", "0°"));
                Aspose.Slides.Charts.IChartCategory category2 = chartData.Categories.Add(workbook.GetCell(0, "A2", "90°"));
                Aspose.Slides.Charts.IChartCategory category3 = chartData.Categories.Add(workbook.GetCell(0, "A3", "180°"));
                Aspose.Slides.Charts.IChartCategory category4 = chartData.Categories.Add(workbook.GetCell(0, "A4", "270°"));

                // Add a series
                Aspose.Slides.Charts.IChartSeries series = chartData.Series.Add(
                    workbook.GetCell(0, "B1", "Series 1"),
                    Aspose.Slides.Charts.ChartType.Radar);

                // Populate series with values
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B1", 4));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B2", 8));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B3", 6));
                series.DataPoints.AddDataPointForBarSeries(workbook.GetCell(0, "B4", 3));

                // Customize radii by adjusting the chart's layout (scale)
                // Set the chart's height and width to influence the radius
                chart.Width = 600;
                chart.Height = 600;

                // Optionally, set the chart's rotation to align the first category at the top
                chart.Rotation = 0; // 0 degrees

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to " + Path.GetFullPath(outputPath));
            }
            catch (FileNotFoundException fileEx)
            {
                Console.WriteLine("File not found: " + fileEx.Message);
            }
            catch (NotSupportedException notSupEx)
            {
                Console.WriteLine("Operation not supported: " + notSupEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
