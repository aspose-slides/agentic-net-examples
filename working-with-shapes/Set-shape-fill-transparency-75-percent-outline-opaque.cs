using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

                // Set solid fill type
                shape.FillFormat.FillType = FillType.Solid;

                // Set fill color with 75% transparency (alpha = 64)
                shape.FillFormat.SolidFillColor.Color = Color.FromArgb(64, Color.Blue);

                // Ensure outline (line) is fully opaque (black)
                shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;

                // Save the presentation
                try
                {
                    presentation.Save("TransparentShape.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other save errors
                    Console.WriteLine("Error saving presentation: " + ex.Message);
                }
            }
        }
    }
}