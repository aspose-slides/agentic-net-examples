// -----------------------------------------------------------------------------
// Example: Verify no VBA macros after conversion using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, remove any embedded
// VBA macros by using LoadOptions.DeleteEmbeddedBinaryObjects, save the
// cleaned presentation, and then verify that no VBA macros remain. The example
// uses Aspose.Slides for .NET and can be run as a standalone console
// application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Verify, VBA, Macros, Removal,
// Conversion, Presentation Processing, Office Automation
//
// Use Cases:
// - Ensure PowerPoint files are free of VBA macros before distribution.
// - Automate macro removal in batch processing pipelines.
// - Validate presentations after conversion or editing steps.
// - Integrate macro‑free checks into .NET applications handling PPTX files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesMacroCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input file path
            string inputPath;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "input.pptx";
            }

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Prepare output file path
            string directory = Path.GetDirectoryName(inputPath);
            string filenameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
            string outputPath = Path.Combine(directory ?? String.Empty, filenameWithoutExt + "_noMacros.pptx");

            try
            {
                // Load presentation with option to delete embedded binary objects (including VBA macros)
                LoadOptions loadOptions = new LoadOptions();
                loadOptions.DeleteEmbeddedBinaryObjects = true;
                Presentation presentation = new Presentation(inputPath, loadOptions);

                // Save the cleaned presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                // Load the saved presentation to verify absence of VBA macros
                Presentation cleanedPresentation = new Presentation(outputPath);
                if (cleanedPresentation.VbaProject != null)
                {
                    Console.WriteLine("VBA macros are still present in the output file.");
                }
                else
                {
                    Console.WriteLine("No VBA macros found in the output file.");
                }
                cleanedPresentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
