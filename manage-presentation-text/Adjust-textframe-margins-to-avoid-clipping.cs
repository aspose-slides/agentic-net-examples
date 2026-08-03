// -----------------------------------------------------------------------------
// Example: Adjust textframe margins to avoid clipping using C#
//
// Description:
// Demonstrates how to adjust textframe margins to avoid clipping using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Adjust, Textframe, Margins, 
// Avoid, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adjust textframe margins to avoid clipping.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TextWrapExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file path
            string outputPath = "WrappedTextPresentation.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

                // Add a text frame with sample text
                shape.AddTextFrame("Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                                   "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.");

                // Access the text frame format
                Aspose.Slides.ITextFrameFormat textFrameFormat = shape.TextFrame.TextFrameFormat;

                // Enable text wrapping
                textFrameFormat.WrapText = Aspose.Slides.NullableBool.True;

                // Adjust margins to prevent clipping
                textFrameFormat.MarginLeft = 10;
                textFrameFormat.MarginRight = 10;
                textFrameFormat.MarginTop = 10;
                textFrameFormat.MarginBottom = 10;

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
