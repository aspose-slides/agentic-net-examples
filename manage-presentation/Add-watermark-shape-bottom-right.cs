// -----------------------------------------------------------------------------
// Example: Add watermark shape bottom right using C#
//
// Description:
// Demonstrates how to add a watermark shape positioned at the bottom right
// corner of each slide using C# and Aspose.Slides for .NET. The example shows
// the required presentation-processing steps for PowerPoint files and
// produces the requested output in a standalone console application. Developers
// can use this pattern to automate PPTX workflows, validate results, or
// integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Watermark, Shape, Bottom,
// Right, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a watermark shape to the bottom right of slides.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            // Create a new presentation if the input file does not exist
            using (var pres = new Presentation())
            {
                AddWatermarkToAllSlides(pres);
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            return;
        }

        try
        {
            using (var pres = new Presentation(inputPath))
            {
                AddWatermarkToAllSlides(pres);
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format exception
            // Format not supported: ex.Message
        }
    }

    static void AddWatermarkToAllSlides(Presentation pres)
    {
        foreach (var slide in pres.Slides)
        {
            // Determine bottom‑right position with a small margin
            var slideSize = pres.SlideSize.Size;
            float shapeWidth = 150f;
            float shapeHeight = 50f;
            float margin = 10f;
            float x = slideSize.Width - shapeWidth - margin;
            float y = slideSize.Height - shapeHeight - margin;

            var watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, shapeWidth, shapeHeight);
            watermarkShape.AddTextFrame("Watermark");
            watermarkShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;
            watermarkShape.FillFormat.FillType = FillType.NoFill;
            watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
        }
    }
}
