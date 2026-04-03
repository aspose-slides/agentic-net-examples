using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Animation;

namespace ReorderAnimations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Get the first slide
                    ISlide slide = pres.Slides[0];

                    // Get the shape collection of the slide
                    IShapeCollection shapes = slide.Shapes;

                    // Get the main animation sequence
                    ISequence mainSequence = slide.Timeline.MainSequence;

                    // Clear existing effects
                    mainSequence.Clear();

                    // Re‑add a simple fade effect for each shape in Z‑order
                    for (int i = 0; i < shapes.Count; i++)
                    {
                        IShape shape = shapes[i];
                        mainSequence.AddEffect(
                            shape,
                            EffectType.Fade,
                            EffectSubtype.None,
                            EffectTriggerType.AfterPrevious);
                    }

                    // Save the modified presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // TODO: Add specific handling for unsupported file formats if needed
            }
        }
    }
}