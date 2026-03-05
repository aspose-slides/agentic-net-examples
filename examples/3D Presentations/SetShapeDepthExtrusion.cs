using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetShapeDepthExtrusion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a rectangle shape to the first slide
            Aspose.Slides.IAutoShape rectangle = presentation.Slides[0].Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, // shape type
                50,   // X position
                50,   // Y position
                200,  // Width
                100   // Height
            );

            // Set the 3‑D depth of the shape
            rectangle.ThreeDFormat.Depth = 5.0;

            // Set the extrusion height of the shape
            rectangle.ThreeDFormat.ExtrusionHeight = 10.0;

            // Save the presentation to a PPTX file
            presentation.Save("SetDepthExtrusion.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
    }
}