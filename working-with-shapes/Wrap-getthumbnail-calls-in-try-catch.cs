// -----------------------------------------------------------------------------
// Example: Wrap getthumbnail calls in try catch using C#
//
// Description:
// Demonstrates how to wrap shape thumbnail generation calls in a try-catch
// block using C# and Aspose.Slides for .NET. The example creates a presentation,
// adds a rectangle shape, attempts to retrieve its thumbnail image, and handles
// any exceptions that may occur during the GetImage operation. The resulting
// thumbnail is saved as a PNG file and the presentation is saved as PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Wrap, GetImage, Thumbnail, 
// Try-Catch, Exception Handling, Shape Processing, Office Automation
//
// Use Cases:
// - Safely generate shape thumbnails in automated PowerPoint workflows.
// - Implement robust error handling for unsupported shape types.
// - Build .NET tools that process and export slide content as images.
// - Integrate thumbnail generation into larger presentation processing pipelines.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file paths
        string outputPptx = "output.pptx";
        string outputPng = "shape.png";

        // Create a new presentation
        Presentation pres = new Presentation();
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 300, 150);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Generate thumbnail for the shape with error handling
        IImage shapeImage = null;
        try
        {
            shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
            shapeImage.Save(outputPng, ImageFormat.Png);
        }
        catch (Exception ex)
        {
            // Handle unsupported shape types or other errors gracefully
            Console.WriteLine("Failed to generate shape thumbnail: " + ex.Message);
        }

        // Save the presentation
        pres.Save(outputPptx, SaveFormat.Pptx);
    }
}
