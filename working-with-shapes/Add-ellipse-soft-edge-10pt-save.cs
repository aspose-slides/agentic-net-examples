// -----------------------------------------------------------------------------
// Example: Add ellipse soft edge 10pt save using C#
//
// Description:
// Demonstrates how to add an ellipse shape with a 10‑point soft edge effect
// and save the presentation using C# and Aspose.Slides for .NET. The example
// shows the required steps to create a new PPTX file, insert an ellipse,
// apply a soft‑edge visual effect, and persist the result to disk in a
// standalone console application. Developers can use this pattern to automate
// PowerPoint shape styling, generate presentations programmatically, or
// integrate visual enhancements into .NET workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ellipse, Soft Edge, 10Pt,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding an ellipse with a 10‑point soft edge to a presentation.
// - Build C# tools for PowerPoint shape creation and styling.
// - Generate or transform PPTX files with visual effects in .NET applications.
// - Validate presentation rendering before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define output directory and file
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }
        string outputPath = Path.Combine(outputDir, "SoftEdgeEllipse.pptx");

        // Create a new presentation
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add an ellipse shape
        IAutoShape ellipse = slide.Shapes.AddAutoShape(
            ShapeType.Ellipse,
            100,   // X position
            100,   // Y position
            300,   // Width
            200    // Height
        );

        // Apply soft edge effect with radius 10 points
        ellipse.EffectFormat.EnableSoftEdgeEffect();
        ellipse.EffectFormat.SoftEdgeEffect.Radius = 10;

        // Save the presentation
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Handle format not supported or other save errors
        }
    }
}
