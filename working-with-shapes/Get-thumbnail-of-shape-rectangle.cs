// -----------------------------------------------------------------------------
// Example: Get thumbnail of shape rectangle using C#
//
// Description:
// Demonstrates how to get thumbnail of shape rectangle using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Thumbnail, Shape, Rectangle, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate get thumbnail of shape rectangle.
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
        string outputPng = "ShapeThumbnail.png";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Access the first slide
        ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
        shape.FillFormat.FillType = FillType.NoFill;
        shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

        // Capture the shape thumbnail with precise bounds
        IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
        shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        pres.Save(outputPptx, SaveFormat.Pptx);
    }
}
