using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace AddLineShapeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Define line position and length
                float x = 100f;      // X coordinate
                float y = 100f;      // Y coordinate
                float length = 300f; // Length of the line
                float height = 0f;   // Height (0 for a straight horizontal line)

                // Add a straight line shape
                Aspose.Slides.IShape lineShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Line,
                    x,
                    y,
                    length,
                    height);

                // Set line styling properties
                lineShape.LineFormat.Width = 5.0; // Line width
                lineShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue; // Line color

                // Optional: apply a sketch effect (e.g., Scribble)
                lineShape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

                // Save the presentation
                presentation.Save("LineShapePresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}