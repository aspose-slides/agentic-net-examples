// -----------------------------------------------------------------------------
// Example: Add category animation withprevious to isequence using C#
//
// Description:
// Demonstrates how to add a category animation effect with a WithPrevious trigger
// to a chart in a PowerPoint presentation using Aspose.Slides for .NET. The
// example loads an existing presentation (or creates a new one), inserts a
// clustered column chart, applies the animation, and saves the result.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Chart, Animation, WithPrevious,
// Category, Timeline, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding category-based animations to charts in PPTX files.
// - Build .NET tools for enhancing PowerPoint presentations with custom effects.
// - Generate or modify PPTX files programmatically for reporting or dashboards.
// - Validate animation sequences before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            var inputPath = "input.pptx";
            var outputPath = "output.pptx";

            try
            {
                // Load existing presentation if it exists, otherwise create a new one
                using (var presentation = File.Exists(inputPath) ? new Presentation(inputPath) : new Presentation())
                {
                    var slide = presentation.Slides[0];

                    // Add a chart to the slide
                    var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 400, 300);

                    // Add a category animation effect with WithPrevious trigger
                    slide.Timeline.MainSequence.AddEffect(
                        chart,
                        EffectChartMajorGroupingType.ByCategory,
                        0,
                        EffectType.Fly,
                        EffectSubtype.None,
                        EffectTriggerType.WithPrevious);

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.FileName}");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
