// -----------------------------------------------------------------------------
// Example: Add ellipse line cap square to PPTX using C#
//
// Description:
// Demonstrates how to add an ellipse shape with a square line cap to a PPTX 
// file using C# and Aspose.Slides for .NET. The example creates a new 
// presentation, inserts an ellipse, sets its line cap style to square, 
// retrieves the effective line cap style, and saves the result. This pattern 
// can be used to automate PowerPoint shape styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Line Cap, Square, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding ellipses with square line caps to PPTX files.
// - Build C# utilities for PowerPoint shape formatting.
// - Generate or modify PPTX presentations programmatically.
// - Validate line cap styling in presentation workflows.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output file path
        string outputPath = "EllipseLineCap.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add an ellipse shape
        Aspose.Slides.IAutoShape ellipse = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Ellipse, 100, 100, 200, 100);

        // Set the line cap style to square
        ellipse.LineFormat.CapStyle = Aspose.Slides.LineCapStyle.Square;

        // Verify the effective line cap style
        Aspose.Slides.ILineFormatEffectiveData effective = ellipse.LineFormat.GetEffective();
        Console.WriteLine("Effective Line Cap Style: " + effective.CapStyle);

        // Save the presentation
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
