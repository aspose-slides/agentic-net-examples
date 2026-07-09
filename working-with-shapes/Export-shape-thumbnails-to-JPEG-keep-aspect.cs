using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "ShapeThumbnailDemo.pptx";
        string outputJpeg = "ShapeThumbnail.jpg";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Preserve original aspect ratio by using equal scaling factors
        float scaleX = 1f;
        float scaleY = 1f;

        // Generate shape thumbnail
        IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY);

        // Save thumbnail as JPEG
        try
        {
            shapeImage.Save(outputJpeg, Aspose.Slides.ImageFormat.Jpeg);
        }
        catch (NotSupportedException)
        {
            // Image format not supported
        }

        // Save the presentation before exiting
        try
        {
            pres.Save(outputPptx, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Presentation format not supported
        }
    }
}