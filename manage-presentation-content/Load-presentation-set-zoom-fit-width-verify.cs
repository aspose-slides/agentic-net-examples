// -----------------------------------------------------------------------------
// Example: Load presentation set zoom fit width verify using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, configure the view to
// fit the slide width (zoom fit‑width) and verify the applied zoom scale using
// Aspose.Slides for .NET. The example loads an existing PPTX file, sets the
// VariableScale flag and an explicit Scale value, saves the modified file, and
// outputs the current zoom scale to the console.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Presentation, Zoom, Fit Width, Scale, Verify, Presentation Processing
//
// Use Cases:
// - Automate loading a presentation and setting zoom to fit‑width.
// - Build C# utilities for PowerPoint view configuration.
// - Generate or modify PPTX files with specific zoom settings in .NET applications.
// - Validate presentation view settings before distribution or further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Set zoom to fit‑to‑width (auto scaling)
            presentation.ViewProperties.SlideViewProperties.VariableScale = true;
            // Optionally set an explicit scale value (percentage)
            presentation.ViewProperties.SlideViewProperties.Scale = 100;

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Verify visual layout by outputting the current scale
            Console.WriteLine("Zoom scale set to: " + presentation.ViewProperties.SlideViewProperties.Scale);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other errors (e.g., external URL issues)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
