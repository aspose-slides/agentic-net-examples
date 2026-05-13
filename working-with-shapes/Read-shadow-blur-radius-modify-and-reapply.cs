using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace ShadowEffectDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Get the first shape (assumed to be an AutoShape)
                Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes[0];

                // Access the effect format of the shape
                Aspose.Slides.IEffectFormat effectFormat = shape.EffectFormat;

                // Ensure outer shadow effect is enabled
                effectFormat.EnableOuterShadowEffect();

                // Get the outer shadow effect
                Aspose.Slides.Effects.IOuterShadow outerShadow = effectFormat.OuterShadowEffect;

                // Read current blur radius
                double currentBlur = outerShadow.BlurRadius;

                // Modify blur radius (increase by 5 points)
                outerShadow.BlurRadius = currentBlur + 5.0;

                // Save the updated presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                pres.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}