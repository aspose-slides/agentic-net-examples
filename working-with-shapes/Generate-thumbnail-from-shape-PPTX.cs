using System;
using Aspose.Slides;
using Aspose.Slides.Export;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Output file paths
            string outputPptx = "output.pptx";
            string outputPng = "shape.png";

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle,
                50f,   // X position
                50f,   // Y position
                200f,  // Width
                100f   // Height
            );

            // Set shape formatting
            shape.FillFormat.FillType = Aspose.Slides.FillType.NoFill;
            shape.LineFormat.SketchFormat.SketchType = Aspose.Slides.LineSketchType.Scribble;

            // Define scaling factors for the thumbnail
            float scaleX = 1f;
            float scaleY = 1f;

            // Generate shape thumbnail image
            Aspose.Slides.IImage shapeImage = shape.GetImage(
                Aspose.Slides.ShapeThumbnailBounds.Shape,
                scaleX,
                scaleY
            );

            // Save the shape thumbnail as PNG
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

            // Save the presentation
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}