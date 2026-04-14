using System;
using System.IO;
using Aspose.Slides.Export;

namespace ChartAnimationRepeat
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Get the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Assume the first shape is a chart
                    Aspose.Slides.Charts.IChart chart = slide.Shapes[0] as Aspose.Slides.Charts.IChart;
                    if (chart == null)
                    {
                        Console.WriteLine("No chart found on the first slide.");
                        return;
                    }

                    // Add a fade effect to the chart
                    Aspose.Slides.Animation.IEffect effect = slide.Timeline.MainSequence.AddEffect(
                        chart,
                        Aspose.Slides.Animation.EffectType.Fade,
                        Aspose.Slides.Animation.EffectSubtype.None,
                        Aspose.Slides.Animation.EffectTriggerType.AfterPrevious);

                    // Set the effect to repeat three times
                    effect.Timing.RepeatCount = 3;

                    // Save the modified presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., unsupported format, I/O issues)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}