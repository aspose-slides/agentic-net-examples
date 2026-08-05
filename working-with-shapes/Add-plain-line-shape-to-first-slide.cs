// -----------------------------------------------------------------------------
// Example: Add plain line shape to first slide using C#
//
// Description:
// Demonstrates how to add a plain line shape to the first slide using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Plain, Line, Shape, First, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate add plain line shape to first slide.
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
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Add a plain line shape to the slide
            slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

            // Define output file path
            string outputPath = "PlainLine.pptx";

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
