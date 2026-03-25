using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine source presentation path (optional)
            string sourcePath = null;
            if (args.Length > 0)
            {
                sourcePath = args[0];
                if (!File.Exists(sourcePath))
                {
                    Console.WriteLine("Error: Input file not found - " + sourcePath);
                    return;
                }
            }

            // Create or load presentation
            Presentation presentation = null;
            try
            {
                if (sourcePath != null)
                {
                    presentation = new Presentation(sourcePath);
                }
                else
                {
                    presentation = new Presentation();
                }

                // Access first slide
                ISlide slide = presentation.Slides[0];

                // Add a clustered column chart
                IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 0, 0, 500, 500);

                // Add a simple Fly animation effect to the chart
                slide.Timeline.MainSequence.AddEffect(
                    chart,
                    EffectType.Fly,
                    EffectSubtype.Left,
                    EffectTriggerType.OnClick);

                // Save the presentation
                string outputPath = "ResultPresentation.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}