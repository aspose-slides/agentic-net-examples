// -----------------------------------------------------------------------------
// Example: Load PPTX and list slide masters using C#
//
// Description:
// Demonstrates how to load a PPTX file and enumerate its master slides using
// Aspose.Slides for .NET. The example opens a presentation, retrieves the
// master slide collection, prints each master slide's name, and saves the
// presentation unchanged. This pattern is useful for inspecting or validating
// slide masters in automated workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, List, Slide Masters,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Retrieve and display master slide information from a PPTX file.
// - Build tools that analyze or validate slide master structures.
// - Integrate slide master enumeration into .NET applications.
// - Automate reporting on presentation templates before further processing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input PPTX file
        string inputPath = "input.pptx";

        // Verify that the file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Get the collection of master slides
            IMasterSlideCollection masters = presentation.Masters;

            // Output the number of master slides
            Console.WriteLine("Number of master slides: " + masters.Count);

            // Enumerate each master slide
            for (int i = 0; i < masters.Count; i++)
            {
                IMasterSlide master = masters[i];
                Console.WriteLine("Master " + i + " Name: " + master.Name);
            }

            // Save the presentation (no modifications made)
            presentation.Save(inputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
            // Format not supported
        }
    }
}
