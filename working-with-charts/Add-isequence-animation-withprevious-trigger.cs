// -----------------------------------------------------------------------------
// Example: Add isequence animation withprevious trigger using C#
//
// Description:
// Demonstrates how to add an ISequence animation with a WithPrevious trigger
// to a chart using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts a clustered column chart, applies a category‑by‑category
// animation effect, and saves the result as a PPTX file. This pattern can be
// used to automate PowerPoint chart animations, validate presentation
// workflows, or integrate chart animation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Isequence, Animation,
// Withprevious, Trigger, Chart, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding ISequence animation with a WithPrevious trigger to charts.
// - Build C# tools for PowerPoint chart animation processing.
// - Generate or transform PPTX files with animated charts in .NET applications.
// - Validate chart animation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AddChartAnimationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "AddChartAnimation_out.pptx";

            // Ensure the directory for the output file exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir) && !Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart to the slide
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50f, 50f, 400f, 300f);

                // Add a category animation effect to the chart with a WithPrevious trigger
                ISequence mainSequence = slide.Timeline.MainSequence;
                IEffect animationEffect = mainSequence.AddEffect(
                    chart,
                    EffectChartMajorGroupingType.ByCategory, // Animate by category
                    0,                                      // Index of the category (0 = first)
                    EffectType.Fly,                         // Animation type
                    EffectSubtype.None,                     // No subtype
                    EffectTriggerType.WithPrevious);        // Trigger type

                // Save the presentation (handle unsupported format exception)
                try
                {
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Format not supported or other saving error
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}
