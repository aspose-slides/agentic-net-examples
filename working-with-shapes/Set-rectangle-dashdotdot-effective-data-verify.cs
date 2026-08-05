// -----------------------------------------------------------------------------
// Example: Set rectangle dashdotdot effective data verify using C#
//
// Description:
// Demonstrates how to set rectangle dashdotdot effective data verify using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Dashdotdot, 
// Effective, Data, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate set rectangle dashdotdot effective data verify.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 150, 200, 100);

        // Set line dash style to DashDotDot (dash dot dot)
        shape.LineFormat.DashStyle = Aspose.Slides.LineDashStyle.DashDotDot;

        // Set line width
        shape.LineFormat.Width = 2;

        // Retrieve effective line format data
        Aspose.Slides.ILineFormatEffectiveData effective = shape.LineFormat.GetEffective();

        // Verify the effective dash style
        Console.WriteLine("Effective Dash Style: " + effective.DashStyle);

        // Save the presentation
        string outPath = "Output.pptx";
        try
        {
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }
    }
}
