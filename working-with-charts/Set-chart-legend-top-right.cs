// -----------------------------------------------------------------------------
// Example: Set chart legend top right using C#
//
// Description:
// Demonstrates how to set the legend of a chart to the top‑right position in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a new presentation, adds a clustered column chart, enables the
// legend, moves it to the top‑right corner, and saves the file as a PPTX.
// This pattern can be used to automate chart formatting in PPTX files.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Chart, Legend, TopRight, Presentation
// Automation, Office Automation
//
// Use Cases:
// - Programmatically position chart legends in generated presentations.
// - Build .NET tools that customize chart appearance in PPTX files.
// - Automate report generation with specific chart layout requirements.
// - Validate chart formatting before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Charts;

namespace ChartLegendExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                Aspose.Slides.Charts.IChart chart = slide.Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50f, 50f, 500f, 400f);

                // Ensure the chart has a legend
                chart.HasLegend = true;

                // Position the legend at the top right corner
                chart.Legend.Position = Aspose.Slides.Charts.LegendPositionType.TopRight;

                // Save the presentation
                presentation.Save("ChartLegendTopRight.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., format not supported)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
