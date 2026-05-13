using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "RotatedTriangle.pptx";

        // Ensure output directory exists
        string outDir = System.IO.Path.GetDirectoryName(System.IO.Path.GetFullPath(outputPath));
        if (!System.IO.Directory.Exists(outDir))
        {
            System.IO.Directory.CreateDirectory(outDir);
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a triangle shape
        float triX = 100f;
        float triY = 100f;
        float triWidth = 200f;
        float triHeight = 150f;
        Aspose.Slides.IAutoShape triangle = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Triangle, triX, triY, triWidth, triHeight);

        // Rotate the triangle 45 degrees clockwise
        triangle.Rotation = 45f;

        // Verify new bounding box coordinates
        float newX = triangle.X;
        float newY = triangle.Y;
        float newWidth = triangle.Width;
        float newHeight = triangle.Height;

        Console.WriteLine("New Bounding Box:");
        Console.WriteLine("X: " + newX);
        Console.WriteLine("Y: " + newY);
        Console.WriteLine("Width: " + newWidth);
        Console.WriteLine("Height: " + newHeight);

        // Save the presentation (handle unsupported format)
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}