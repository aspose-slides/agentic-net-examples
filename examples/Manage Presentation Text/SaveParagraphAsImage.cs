using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "ParagraphImage.pptx";
        string outputPng = "ParagraphShape.png";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Define shape dimensions
        float x = 100f;
        float y = 100f;
        float width = 400f;
        float height = 200f;

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, x, y, width, height);

        // Set shape formatting
        shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

        // Add paragraph text to the shape
        shape.TextFrame.Text = "This is a paragraph saved as an image.";

        // Generate an image of the shape (including the paragraph)
        float scaleX = 1f;
        float scaleY = 1f;
        Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);

        // Save the shape image as PNG
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}