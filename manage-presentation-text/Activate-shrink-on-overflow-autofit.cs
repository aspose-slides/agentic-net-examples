// -----------------------------------------------------------------------------
// Example: Activate shrink on overflow autofit using C#
//
// Description:
// Demonstrates how to activate shrink‑on‑overflow autofit using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation‑processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Activate, Shrink, Overflow, 
// Autofit, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate activate shrink on overflow autofit.
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
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        // Add a text frame with sample text
        shape.AddTextFrame("This is a long text that should shrink on overflow if it does not fit within the shape boundaries.");
        // Access the text frame
        Aspose.Slides.ITextFrame txtFrame = shape.TextFrame;
        // Activate shrink‑on‑overflow autofit mode
        txtFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Shrink;
        // Set text color to black
        Aspose.Slides.IParagraph para = txtFrame.Paragraphs[0];
        Aspose.Slides.IPortion portion = para.Portions[0];
        portion.PortionFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
        portion.PortionFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Black;
        // Save the presentation
        presentation.Save("ShrinkOnOverflow.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Clean up
        presentation.Dispose();
    }
}
