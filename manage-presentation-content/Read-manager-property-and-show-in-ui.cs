// -----------------------------------------------------------------------------
// Example: Read manager property and show in UI using C#
//
// Description:
// Demonstrates how to read the built‑in Manager document property from a PowerPoint
// presentation, display it in a simple console UI, allow the user to modify the
// value, and save the updated presentation using Aspose.Slides for .NET.
// The example includes loading, property access, user interaction, and saving
// steps suitable for standalone console applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Read, Manager, Property, UI, 
// Presentation Processing, Document Properties, Console Interaction
//
// Use Cases:
// - Retrieve and display the Manager property from a PPTX file.
// - Provide a simple UI for editing document properties.
// - Automate updating presentation metadata in .NET tools.
// - Validate and persist changes to PowerPoint files programmatically.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            // Load the presentation
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Failed to load presentation. Possibly unsupported format.");
            Console.WriteLine(ex.Message);
            return;
        }

        // Access built‑in document properties
        Aspose.Slides.IDocumentProperties documentProperties = presentation.DocumentProperties;

        // Read the Manager property
        string manager = documentProperties.Manager;
        Console.WriteLine("Current Manager: " + manager);

        // Simple UI panel for editing the Manager property
        Console.Write("Enter new Manager value (or press Enter to keep current): ");
        string newManager = Console.ReadLine();
        if (!string.IsNullOrEmpty(newManager))
        {
            documentProperties.Manager = newManager;
        }

        try
        {
            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle save errors (e.g., format not supported)
            Console.WriteLine("Failed to save presentation.");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            // Release resources
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}
