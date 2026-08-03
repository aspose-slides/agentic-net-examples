// -----------------------------------------------------------------------------
// Example: Clean presentation remove all custom data using C#
//
// Description:
// Demonstrates how to clean a PowerPoint presentation by removing all custom
// XML parts and VBA macros using C# and Aspose.Slides for .NET. The example
// shows the required steps to load a presentation, strip custom data, and
// save the cleaned file in a standalone console application. Developers can
// use this pattern to automate PPTX cleanup, prepare files for distribution,
// or integrate presentation sanitization into .NET workflows.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clean, Presentation, Remove,
// Custom, Data, VBA, Tags, Office Automation
//
// Use Cases:
// - Automate removal of custom XML parts and VBA macros from presentations.
// - Build C# tools for sanitizing PowerPoint files before publishing.
// - Integrate presentation cleanup into document processing pipelines.
// - Ensure compliance by stripping embedded custom data from PPTX files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace CleanPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: CleanPresentation <inputPath> <outputPath>");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Remove all custom XML parts
                foreach (ICustomXmlPart customPart in presentation.AllCustomXmlParts)
                {
                    customPart.Remove();
                }

                // Remove VBA macros if present
                if (presentation.VbaProject != null && presentation.VbaProject.Modules.Count > 0)
                {
                    // Remove all modules from the VBA project
                    while (presentation.VbaProject.Modules.Count > 0)
                    {
                        presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);
                    }
                }

                // Save the cleaned presentation
                presentation.Save(outputPath, SaveFormat.Pptx);

                // Release resources
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // TODO: Add handling for specific unsupported format exceptions if needed
            }
        }
    }
}
