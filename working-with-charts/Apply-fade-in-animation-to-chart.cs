// -----------------------------------------------------------------------------
// Example: Apply Fade-In Animation to a Clustered Column Chart using Aspose.Slides
//
// Description:
// This console application creates a new PowerPoint presentation, adds a
// clustered column chart to the first slide, and applies a fade‑in animation
// effect to the chart. It demonstrates the use of Aspose.Slides for .NET to
// generate PPTX files with animated chart content.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, chart animation, fade effect, clustered column chart
//
// Use Cases:
// - Automatically generate presentation reports with animated charts.
// - Create marketing decks where chart data appears progressively.
// - Build educational slides that emphasize data visualization through animation.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace ChartAnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            string outputFile = Path.Combine(outputDirectory, "AnimatedChart.pptx");

            try
            {
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a clustered column chart to the first slide
                Aspose.Slides.Charts.IChart chart = presentation.Slides[0].Shapes.AddChart(
                    Aspose.Slides.Charts.ChartType.ClusteredColumn,
                    50,
                    50,
                    500,
                    400);

                // Apply a fade‑in animation effect to the chart
                presentation.Slides[0].Timeline.MainSequence.AddEffect(
                    chart,
                    Aspose.Slides.Animation.EffectType.Fade,
                    Aspose.Slides.Animation.EffectSubtype.None,
                    Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                // Save the presentation
                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);

                Console.WriteLine("Presentation created successfully: " + outputFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
