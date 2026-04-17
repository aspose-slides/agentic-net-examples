using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "output.pptx";
        string outputPng = "shape_thumbnail.png";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle auto shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 150);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Generate shape thumbnail with error handling
        IImage shapeImage = null;
        try
        {
            shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
        }
        catch (Exception ex)
        {
            // Handle unsupported shape types or other errors gracefully
            Console.WriteLine("Error generating shape thumbnail: " + ex.Message);
        }

        if (shapeImage != null)
        {
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);
        }

        // Save the presentation before exiting
        pres.Save(outputPptx, SaveFormat.Pptx);
    }
}