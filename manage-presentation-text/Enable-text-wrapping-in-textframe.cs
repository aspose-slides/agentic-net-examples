// -----------------------------------------------------------------------------
// Example: Enable text wrapping in textframe using C#
//
// Description:
// Demonstrates how to enable text wrapping in a text frame of a shape using
// C# and Aspose.Slides for .NET. The example creates a new presentation,
// adds a rectangle shape with a text frame, enables text wrapping, and saves
// the result as a PPTX file. This pattern can be used to automate PowerPoint
// presentation processing, validate layout behavior, or integrate presentation
// logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, Text, Wrapping,
// Textframe, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enabling text wrapping in text frames.
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
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

            // Add a text frame with sample text
            shape.AddTextFrame("This is a sample text that will be wrapped inside the text frame.");

            // Enable text wrapping inside the text frame
            shape.TextFrame.TextFrameFormat.WrapText = Aspose.Slides.NullableBool.True;

            // Save the presentation
            presentation.Save("WrappedText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
