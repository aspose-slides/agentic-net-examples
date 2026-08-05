// -----------------------------------------------------------------------------
// Example: Export shape thumbnails to BMP legacy using C#
//
// Description:
// Demonstrates how to export a shape thumbnail to a BMP file using C# and 
// Aspose.Slides for .NET. The example creates a presentation, adds a rectangle 
// shape, generates a thumbnail image of the shape, and saves it in BMP legacy 
// format. It also saves the presentation as PPTX. This pattern can be used for 
// automating shape thumbnail extraction in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Shape, Thumbnail, 
// BMP, Legacy, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of shape thumbnails to BMP legacy format.
// - Build C# utilities for PowerPoint shape image generation.
// - Integrate shape thumbnail creation into .NET workflows.
// - Validate and preview shapes before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ShapeThumbnailExport
{
    class Program
    {
        static void Main()
        {
            // Output file paths
            string outputPptx = "ShapeThumbnailDemo.pptx";
            string outputBmp = "ShapeThumbnail.bmp";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a rectangle shape to the slide
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
            shape.FillFormat.FillType = FillType.NoFill;
            shape.LineFormat.SketchFormat.SketchType = LineSketchType.Scribble;

            // Generate a thumbnail image of the shape with scaling factors
            float scaleX = 1f;
            float scaleY = 1f;
            IImage shapeImage = shape.GetImage(ShapeThumbnailBounds.Shape, scaleX, scaleY);

            // Save the shape thumbnail as BMP
            shapeImage.Save(outputBmp, Aspose.Slides.ImageFormat.Bmp);

            // Save the presentation
            pres.Save(outputPptx, SaveFormat.Pptx);
        }
    }
}
