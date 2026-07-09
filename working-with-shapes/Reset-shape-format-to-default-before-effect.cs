using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ResetShapeFormatting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation inside a try-catch to handle unsupported formats
            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Format not supported or other loading error
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Comment: format not supported
                return;
            }

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Reset formatting of all shapes on the slide to default values
            slide.Reset();

            // Select a shape to apply new visual effects (example: first shape)
            IAutoShape shape = slide.Shapes[0] as IAutoShape;
            if (shape == null)
            {
                Console.WriteLine("No autoshape found on the slide.");
                pres.Dispose();
                return;
            }

            // Apply new visual effects to the selected shape
            shape.FillFormat.FillType = FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.Blue;

            // Enable outer shadow effect and configure it
            shape.EffectFormat.EnableOuterShadowEffect();
            shape.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
            shape.EffectFormat.OuterShadowEffect.Distance = 3.0;
            shape.EffectFormat.OuterShadowEffect.ShadowColor.Color = Color.Gray;

            // Save the presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Dispose the presentation object
            pres.Dispose();
        }
    }
}