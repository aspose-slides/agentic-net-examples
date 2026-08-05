// -----------------------------------------------------------------------------
// Example: Validate VBA project has modules using C#
//
// Description:
// Demonstrates how to validate that a PowerPoint presentation's VBA project
// contains at least one module using C# and Aspose.Slides for .NET. The example
// loads a PPTM file, checks the VBA project for modules, optionally adds a new
// empty module, and saves the presentation. This pattern can be used to
// automate VBA validation and manipulation in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTM, Aspose.Slides for .NET, VBA, Validate, Modules, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Verify VBA projects contain modules before processing.
// - Add or modify VBA modules programmatically.
// - Build .NET tools for PowerPoint VBA automation.
// - Ensure presentation integrity in CI pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptm");
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptm");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);

            // Validate that the VBA project contains at least one module
            if (presentation.VbaProject != null && presentation.VbaProject.Modules != null && presentation.VbaProject.Modules.Count > 0)
            {
                Console.WriteLine("VBA project contains modules. Proceeding with modifications.");
                // Example modification: add a new empty module
                presentation.VbaProject.Modules.AddEmptyModule("NewModule");
            }
            else
            {
                Console.WriteLine("VBA project does not contain any modules. No modifications performed.");
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, SaveFormat.Pptm);
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
