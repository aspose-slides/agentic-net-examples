// -----------------------------------------------------------------------------
// Example: Move Chart Legend to Top-Left Corner in PowerPoint using C#
// 
// Description:
// This console application creates a new PowerPoint presentation, adds a
// clustered column chart, and moves the chart legend to the top‑left corner
// by setting custom X and Y coordinates. It demonstrates Aspose.Slides for
// .NET chart legend positioning and saves the result as a PPTX file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart legend position, clustered column chart
// 
// Use Cases:
// - Automating legend placement in generated slide decks
// - Customizing chart appearance for corporate templates
// - Programmatic generation of PowerPoint reports with precise layout
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ChartLegendPositionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "ChartLegendTopLeft.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f,   // X position of chart
                    50f,   // Y position of chart
                    500f,  // Width of chart
                    400f   // Height of chart
                );

                // Move the legend to the top-left corner
                chart.Legend.X = 0f;          // X coordinate (points)
                chart.Legend.Y = 0f;          // Y coordinate (points)
                chart.Legend.Width = 200f;    // Optional: set legend width
                chart.Legend.Height = 50f;    // Optional: set legend height

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
