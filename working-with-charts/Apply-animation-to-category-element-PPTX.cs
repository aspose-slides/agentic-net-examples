using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;
using Aspose.Slides.Charts;

namespace ApplyChartCategoryAnimation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation; can be passed as a command‑line argument
            string inputPath = "input.pptx";
            if (args.Length > 0)
            {
                inputPath = args[0];
            }

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Assume the first shape on the slide is a chart
                IChart chart = (IChart)slide.Shapes[0];

                // Apply an animation effect to the first category (index 0) of the chart
                IEffect effect = presentation.Slides[0].Timeline.MainSequence.AddEffect(
                    chart,
                    EffectChartMajorGroupingType.ByCategory,
                    0,
                    EffectType.Fade,
                    EffectSubtype.None,
                    EffectTriggerType.AfterPrevious);

                // Save the modified presentation
                string outputPath = "output.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}