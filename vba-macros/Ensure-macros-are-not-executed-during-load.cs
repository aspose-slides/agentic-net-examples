// -----------------------------------------------------------------------------
// Example: Ensure macros are not executed during load using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation while preventing the
// execution of embedded VBA macros using Aspose.Slides for .NET. The example
// disables embedded binary objects (including macros) during load, verifies
// that the VBA project is absent, and saves the presentation as a macro‑free
// PPTX file. This pattern is useful for safely processing potentially unsafe
// PPTM files in automated workflows.
//
// Keywords:
// C#, PowerPoint, PPTM, PPTX, Aspose.Slides for .NET, Macros, VBA, Ensure,
// Not Executed, Load Options, Presentation Processing, Office Automation
//
// Use Cases:
// - Safely import PPTM files without executing macros.
// - Convert macro‑enabled presentations to macro‑free formats.
// - Validate that presentations do not contain VBA projects after loading.
// - Integrate secure PowerPoint handling into .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VerifyMacros
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptm");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation with option to delete embedded binary objects (including macros)
                Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                loadOptions.DeleteEmbeddedBinaryObjects = true;

                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath, loadOptions))
                {
                    // Verify that macros (VBA project) are not present after loading
                    if (presentation.VbaProject == null)
                    {
                        Console.WriteLine("Macros are not present after loading.");
                    }
                    else
                    {
                        Console.WriteLine("Macros are still present after loading.");
                    }

                    // Save the presentation (macros will not be executed during save)
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
