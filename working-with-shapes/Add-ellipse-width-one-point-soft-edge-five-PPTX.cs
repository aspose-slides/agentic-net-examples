using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputFileName = "EllipseWithSoftEdge.pptx";
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);

            try
            {
                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Get the first slide
                    Aspose.Slides.ISlide slide = presentation.Slides[0];

                    // Add an ellipse shape
                    Aspose.Slides.IAutoShape ellipse = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Ellipse, 100, 100, 300, 200);

                    // Set line width to one point
                    ellipse.LineFormat.Width = 1.0;

                    // Enable soft edge effect and set radius to five points
                    ellipse.EffectFormat.EnableSoftEdgeEffect();
                    ellipse.EffectFormat.SoftEdgeEffect.Radius = 5.0;

                    // Save the presentation
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}