using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SoftEdgeEllipseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory and file
            string outputDir = "Output";
            string outputPath = Path.Combine(outputDir, "EllipseWithSoftEdge.pptx");

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add an ellipse shape
                IAutoShape ellipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 300, 200);

                // Enable soft edge effect and set radius to 10 points
                ellipse.EffectFormat.EnableSoftEdgeEffect();
                if (ellipse.EffectFormat.SoftEdgeEffect != null)
                {
                    ellipse.EffectFormat.SoftEdgeEffect.Radius = 10.0;
                }

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}