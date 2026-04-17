using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
            shape.FillFormat.FillType = FillType.NoFill;
            shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

            // Define scaling factor
            float scaleFactor = 1.5f;

            // Generate shape thumbnail with scaling
            IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, scaleFactor, scaleFactor);

            // Save thumbnail as PNG
            string outputPng = "shape_thumbnail.png";
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

            // Save the presentation
            string outputPptx = "output.pptx";
            pres.Save(outputPptx, SaveFormat.Pptx);
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}