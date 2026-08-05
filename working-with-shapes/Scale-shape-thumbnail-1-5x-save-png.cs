// -----------------------------------------------------------------------------
// Example: Scale shape thumbnail 1 5x save png using C#
//
// Description:
// Demonstrates how to generate a 1.5x scaled thumbnail of a shape and save it as a PNG file using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a rectangle shape, extracts its thumbnail 
// with a scaling factor of 1.5, and writes the image to disk. It also saves the presentation file.
// Developers can use this pattern to create high‑resolution shape previews, automate thumbnail generation, 
// or integrate shape imaging into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PNG, Scale, Shape, Thumbnail, 
// Save, Presentation Processing, Office Automation
//
// Use Cases:
// - Generate scaled shape thumbnails for documentation or UI previews.
// - Build C# tools that extract and resize shape images from PowerPoint files.
// - Automate PNG export of specific shapes with custom scaling.
// - Validate shape rendering and scaling in .NET applications.
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

        // Add a rectangle shape to the slide
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Scaling factor for the thumbnail (1.5x)
        float scaleFactor = 1.5f;

        // Generate the shape thumbnail with the scaling factor
        IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, scaleFactor, scaleFactor);

        // Save the thumbnail as PNG
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation before exiting
        pres.Save(outputPptx, SaveFormat.Pptx);
    }
}
