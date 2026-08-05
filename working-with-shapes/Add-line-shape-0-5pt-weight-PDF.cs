// -----------------------------------------------------------------------------
// Example: Add line shape 0.5pt weight PDF using C#
//
// Description:
// Demonstrates how to add a line shape with a 0.5 point line width to a
// presentation and save it as a PDF using Aspose.Slides for .NET. The example
// creates a new presentation, inserts a horizontal line on the first slide,
// sets the line thickness, and exports the result to PDF. This pattern can be
// used to automate line‑shape creation and PDF conversion in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, Line Shape, Line Width,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Programmatically add thin line shapes to PowerPoint slides.
// - Convert presentations with custom line graphics to PDF.
// - Build .NET utilities for automated slide generation and export.
// - Validate line formatting before publishing presentations.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "output.pdf";
        try
        {
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];
            IAutoShape lineShape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Line, 50f, 100f, 300f, 0f);
            lineShape.LineFormat.Width = 0.5;
            presentation.Save(outputPath, SaveFormat.Pdf);
        }
        catch (Exception ex)
        {
            // Handle exceptions such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
