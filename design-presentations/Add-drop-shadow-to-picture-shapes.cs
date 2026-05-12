using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyDropShadowToPictures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: ApplyDropShadowToPictures <input.pptx> <output.pptx>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Presentation presentation = new Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IPictureFrame pictureFrame = slide.Shapes[shapeIndex] as IPictureFrame;
                        if (pictureFrame != null)
                        {
                            // Apply preset drop shadow effect
                            pictureFrame.EffectFormat.EnablePresetShadowEffect();
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // If the format is not supported, comment accordingly
                // Format not supported.
            }
        }
    }
}