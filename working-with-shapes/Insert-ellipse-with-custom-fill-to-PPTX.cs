using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add an ellipse shape
            IShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 100, 100, 200, 100);

            // Set fill color to Chocolate
            shape.FillFormat.FillType = FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = Color.Chocolate;

            // Set line color to Black and line width
            shape.LineFormat.FillFormat.FillType = FillType.Solid;
            shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
            shape.LineFormat.Width = 2.0;

            // Define output file path
            string outputPath = "output.pptx";

            // Save the presentation as PPTX
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}