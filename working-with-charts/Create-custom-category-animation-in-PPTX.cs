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
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = @"C:\Data\";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Assume the first shape on the slide is a chart
                Aspose.Slides.IShape shape = slide.Shapes[0];
                Aspose.Slides.Charts.IChart chart = shape as Aspose.Slides.Charts.IChart;

                if (chart != null)
                {
                    // Add a custom animation effect to the first category (index 0) of the chart
                    Aspose.Slides.Animation.ISequence mainSequence = slide.Timeline.MainSequence;
                    Aspose.Slides.Animation.IEffect effect = mainSequence.AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectChartMajorGroupingType.ByCategory,
                        0, // category index
                        Aspose.Slides.Animation.EffectType.Fly,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}