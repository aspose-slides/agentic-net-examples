using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "ShapeThumbnail_out.pptx";
        string outputPng = "ShapeThumbnail.png";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 200, 100);
        shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

        // Generate thumbnail image for the shape
        Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Diagnostic log entry
        Console.WriteLine(string.Format("Thumbnail generated for Shape ID {0} at {1}", shape.OfficeInteropShapeId, DateTime.Now));

        // Save the presentation
        pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}