using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideSvgExport
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define output directory
                string outputDirectory = "Output";
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add an ellipse shape
                IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 200, 100);

                // Set rotation to 30 degrees
                ellipse.Rotation = 30;

                // Apply outer shadow effect
                ellipse.EffectFormat.EnableOuterShadowEffect();

                // Save the presentation (required before exit)
                string pptxPath = Path.Combine(outputDirectory, "result.pptx");
                presentation.Save(pptxPath, SaveFormat.Pptx);

                // Export the slide as SVG
                string svgPath = Path.Combine(outputDirectory, "slide.svg");
                using (FileStream svgStream = File.Create(svgPath))
                {
                    slide.WriteAsSvg(svgStream);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., file I/O errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}