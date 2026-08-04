// -----------------------------------------------------------------------------
// Example: Add iso8601 timestamp watermark to PPTX slides using C#
//
// Description:
// Demonstrates how to add an ISO 8601 timestamp watermark to all slides of a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a new presentation, inserts a full‑slide rectangle shape on the
// master slide, writes the current UTC timestamp in ISO 8601 format, makes the
// shape transparent, and saves the result as a PPTX file. This pattern can be
// used to automate watermarking of presentations in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, ISO 8601, Timestamp, Watermark,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically add an ISO 8601 timestamp watermark to generated PPTX files.
// - Build .NET tools for securing or tracking PowerPoint presentations.
// - Integrate timestamp watermarking into CI/CD pipelines for document
//   generation.
// - Ensure presentation provenance by embedding creation time in each slide.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a blank slide
        ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);

        // Get the first master slide
        IMasterSlide master = pres.Masters[0];

        // Add a rectangle shape that covers the whole slide as a watermark
        IAutoShape watermarkShape = master.Shapes.AddAutoShape(
            ShapeType.Rectangle,
            0,
            0,
            pres.SlideSize.Size.Width,
            pres.SlideSize.Size.Height);

        // Create ISO 8601 timestamp
        string timestamp = DateTime.UtcNow.ToString("o");

        // Add the timestamp text to the shape
        watermarkShape.AddTextFrame(timestamp);
        watermarkShape.TextFrame.TextFrameFormat.CenterText = NullableBool.True;

        // Make the shape and its border transparent
        watermarkShape.FillFormat.FillType = FillType.NoFill;
        watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;

        // Save the presentation
        pres.Save("WatermarkedPresentation.pptx", SaveFormat.Pptx);
    }
}
