using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define file paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
        string outputPptx = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
        string outputPng = Path.Combine(Directory.GetCurrentDirectory(), "shape_thumbnail.png");

        // Load existing presentation if it exists, otherwise create a new one
        Presentation pres = null;
        try
        {
            if (File.Exists(inputPath))
            {
                pres = new Presentation(inputPath);
            }
            else
            {
                pres = new Presentation();
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape that will be used for thumbnail generation
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // In a legacy COM‑based application, an ActiveX control could invoke this code.
        // Here we simulate the trigger by directly generating the thumbnail.

        // Generate thumbnail for the shape
        IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation before exiting
        try
        {
            pres.Save(outputPptx, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }

        // Clean up resources
        pres.Dispose();
    }
}