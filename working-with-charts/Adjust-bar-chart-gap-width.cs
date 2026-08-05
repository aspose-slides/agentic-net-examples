// -----------------------------------------------------------------------------
// Example: Adjust bar chart gap width using C#
//
// Description:
// Demonstrates how to adjust the gap width between bar clusters in a
// clustered column chart using Aspose.Slides for .NET. The example creates a
// new presentation, adds a clustered column chart, modifies the series group
// gap width, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Adjust, Chart, Gap Width,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically change bar chart spacing in generated presentations.
// - Build .NET utilities that customize chart appearance.
// - Automate PPTX creation with specific visual styling requirements.
// - Validate chart layout adjustments before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AdjustBarChartGapWidth
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a clustered column chart (bar chart) to the slide
                    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0f, 0f, 500f, 400f);

                    // Access the first series in the chart
                    IChartSeries series = chart.ChartData.Series[0];

                    // Adjust the gap width between bar clusters (value is a percentage of bar width)
                    series.ParentSeriesGroup.GapWidth = (ushort)150; // 150% gap width

                    // Save the presentation
                    presentation.Save("AdjustedGapWidth.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format, file I/O errors)
                // Format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
