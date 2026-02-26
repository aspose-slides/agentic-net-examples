using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertEllipseExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add an ellipse shape to the slide
            IShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 200, 100);

            // Set solid fill color for the ellipse
            shape.FillFormat.FillType = FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.Chocolate;

            // Set solid line color and width for the ellipse border
            shape.LineFormat.FillFormat.FillType = FillType.Solid;
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
            shape.LineFormat.Width = 2;

            // Determine output file path
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "EllipseOutput.pptx");

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}