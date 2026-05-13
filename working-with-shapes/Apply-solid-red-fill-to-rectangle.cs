using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();
            // Get the first slide
            ISlide slide = presentation.Slides[0];
            // Add a rectangle shape
            IShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
            // Apply solid fill type
            shape.FillFormat.FillType = FillType.Solid;
            // Set fill color to red
            shape.FillFormat.SolidFillColor.Color = Color.Red;
            // Save the presentation
            string outputPath = "SolidRedRectangle.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
            // Dispose the presentation
            presentation.Dispose();
        }
    }
}