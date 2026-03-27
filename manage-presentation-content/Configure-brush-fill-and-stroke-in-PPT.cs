using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outPptx = "BrushAttributesDemo.pptx";
        string outPng = "SlideThumbnail.png";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a rectangle shape to the first slide
        IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 300, 150);

        // Configure fill (no fill) and stroke (scribble line)
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Export the slide as a PNG image
        pres.Slides[0].GetImage(4f / 3f, 4f / 3f).Save(outPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        pres.Save(outPptx, SaveFormat.Pptx);
    }
}