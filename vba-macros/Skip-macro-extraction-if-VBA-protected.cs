// -----------------------------------------------------------------------------
// Example: Skip macro extraction if VBA protected using C#
//
// Description:
// Demonstrates how to skip macro extraction when a PowerPoint presentation's
// VBA project is password protected. The example uses Aspose.Slides for .NET
// to open a PPTM file, checks the VBA project protection status, and conditionally
// proceeds with macro extraction logic. It also shows how to save the presentation
// after processing.
//
// Keywords:
// C#, PowerPoint, PPTM, VBA protection, macro extraction, Aspose.Slides for .NET,
// presentation processing, file I/O, error handling
//
// Use Cases:
// - Automate the detection of password‑protected VBA projects in PPTM files.
// - Build tools that conditionally extract macros only when allowed.
// - Integrate VBA protection checks into PowerPoint workflow automation.
// - Safely process and convert presentations while respecting security settings.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input file
        string inputFileName = "sample.pptm";
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Open the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Check if VBA project is password protected
                if (presentation.VbaProject != null && presentation.VbaProject.IsPasswordProtected)
                {
                    Console.WriteLine("VBA project is password protected. Skipping macro extraction.");
                }
                else
                {
                    // Placeholder for macro extraction logic
                    Console.WriteLine("VBA project is not password protected. Proceed with macro extraction.");
                }

                // Save the presentation before exit
                string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }
                string outputPath = Path.Combine(outputDir, "output.pptx");
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Handle unsupported file format
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
