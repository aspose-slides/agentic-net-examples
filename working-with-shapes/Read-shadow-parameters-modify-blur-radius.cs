using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShadowEffectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
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
                Presentation pres = new Presentation(inputPath);

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Access the first shape on the slide (assumed to be an AutoShape)
                IAutoShape shape = slide.Shapes[0] as IAutoShape;
                if (shape == null)
                {
                    Console.WriteLine("The first shape is not an AutoShape.");
                    pres.Dispose();
                    return;
                }

                // Enable outer shadow effect if not already enabled
                shape.EffectFormat.EnableOuterShadowEffect();

                // Get the outer shadow effect
                Aspose.Slides.Effects.IOuterShadow outerShadow = shape.EffectFormat.OuterShadowEffect;

                // Read the current blur radius
                double currentBlurRadius = outerShadow.BlurRadius;

                // Modify the blur radius (increase by 5 points)
                outerShadow.BlurRadius = currentBlurRadius + 5.0;

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);

                // Clean up
                pres.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // Note: If the exception is due to an unsupported file format, handle accordingly.
            }
        }
    }
}