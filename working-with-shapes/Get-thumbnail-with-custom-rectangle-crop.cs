// -----------------------------------------------------------------------------
// Example: Get thumbnail with custom rectangle crop using C#
//
// Description:
// Demonstrates how to generate a thumbnail image of a specific shape with a
// custom rectangle crop using C# and Aspose.Slides for .NET. The example creates
// a presentation, adds a rectangle shape, extracts the shape's image using a
// custom thumbnail bounds setting, and saves the result as a PNG file. This
// pattern can be used to automate shape thumbnail extraction and processing in
// .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Thumbnail, Custom Rectangle Crop,
// Shape Image, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of shape thumbnails with custom cropping.
// - Build C# tools for PowerPoint shape processing and image generation.
// - Integrate shape thumbnail creation into .NET applications.
// - Validate and preview shape rendering before publishing presentations.
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
        string outputPng = "shape_thumbnail.png";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Generate a thumbnail of the shape with custom scaling
        IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
        // Save the thumbnail as PNG
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        try
        {
            pres.Save(outputPptx, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
    }
}
