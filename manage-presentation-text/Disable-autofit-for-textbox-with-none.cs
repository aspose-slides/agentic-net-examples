// -----------------------------------------------------------------------------
// Example: Disable autofit for textbox with none using C#
//
// Description:
// Demonstrates how to disable autofit for a textbox (text frame) by setting
// the AutofitType to None using C# and Aspose.Slides for .NET. The example
// creates a new presentation, adds a rectangle shape with a text frame, and
// configures the text frame to prevent automatic resizing. The resulting PPTX
// file is saved to the current directory.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Disable, Autofit, Textbox,
// None, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate disabling autofit for textboxes in PowerPoint files.
// - Build C# utilities for precise text layout control in presentations.
// - Generate or modify PPTX files where text scaling must be prevented.
// - Validate presentation formatting before distribution or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);

        // Add a text frame with sample text
        shape.AddTextFrame("Sample text");

        // Disable autofit for the text frame
        shape.TextFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.None;

        // Define output file path
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "DisableAutofit.pptx");

        // Save the presentation
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
