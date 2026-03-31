using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Ink;

namespace PresentationInkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Use the first slide (created by default)
            ISlide slide = presentation.Slides[0];

            // Add a line shape that will act as an ink stroke
            Aspose.Slides.IAutoShape inkShape = slide.Shapes.AddAutoShape(
                ShapeType.Line,
                100,   // X position
                100,   // Y position
                200,   // Width
                0);    // Height (line)

            // Configure the line to look like an ink scribble
            inkShape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

            // Set a transparent brush to simulate erasing
            inkShape.LineFormat.FillFormat.FillType = FillType.Solid;
            inkShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Transparent;

            // Optional: set line width
            inkShape.LineFormat.Width = 5;

            // Save the presentation
            try
            {
                presentation.Save("InkErasingExample.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}