// -----------------------------------------------------------------------------
// Example: Export shape thumbnails to JPEG preserve aspect using C#
//
// Description:
// Demonstrates how to export shape thumbnails to JPEG preserve aspect using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Export, Shape, 
// Thumbnails, Jpeg, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate export shape thumbnails to JPEG preserve aspect.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

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

        // Add a rectangle shape to the slide
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Preserve the original aspect ratio by using equal scaling factors for X and Y
        float scale = 1f; // Full size (no scaling)
        IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, scale, scale);

        // Save the shape thumbnail as JPEG
        shapeImage.Save(outputJpeg, Aspose.Slides.ImageFormat.Jpeg);

        // Save the presentation before exiting
        pres.Save(outputPptx, SaveFormat.Pptx);
    }
}
