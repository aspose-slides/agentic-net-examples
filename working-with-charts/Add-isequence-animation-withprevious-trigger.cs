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