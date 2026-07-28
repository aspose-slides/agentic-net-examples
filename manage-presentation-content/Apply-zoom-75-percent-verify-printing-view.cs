// -----------------------------------------------------------------------------
// Example: Apply zoom 75 percent verify printing view using C#
//
// Description:
// Demonstrates how to apply a 75 percent zoom for both slide and notes printing
// view using C# and Aspose.Slides for .NET. The example shows the required
// presentation-processing steps for PowerPoint files, verifies the applied
// scaling, and saves the result in a standalone console application. Developers
// can use this pattern to automate PPTX workflows, validate view settings, or
// integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Zoom, Percent, Verify,
// Printing View, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a 75% zoom for printing view in PowerPoint presentations.
// - Build C# tools for PowerPoint presentation processing with specific view scaling.
// - Generate or transform PPTX files while controlling slide and notes view scales.
// - Validate presentation view settings before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Apply a custom zoom preset of 75 percent for printing view
        presentation.ViewProperties.SlideViewProperties.Scale = 75;
        presentation.ViewProperties.NotesViewProperties.Scale = 75;

        // Verify scaling by reading back the values
        int slideScale = presentation.ViewProperties.SlideViewProperties.Scale;
        int notesScale = presentation.ViewProperties.NotesViewProperties.Scale;
        Console.WriteLine("Slide view scale: " + slideScale + "%");
        Console.WriteLine("Notes view scale: " + notesScale + "%");

        // Save the presentation before exiting
        string outputPath = "Zoom75.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
