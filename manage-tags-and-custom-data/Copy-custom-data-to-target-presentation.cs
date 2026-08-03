// -----------------------------------------------------------------------------
// Example: Copy custom data to target presentation using C#
//
// Description:
// Demonstrates how to copy custom data from a source presentation to a target
// presentation using C# and Aspose.Slides for .NET. The example loads two PPTX
// files, transfers all custom data entries while preserving their data types,
// and saves the modified target presentation. This pattern can be used to
// automate PowerPoint workflows that require custom metadata propagation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Copy, Custom Data, Target
// Presentation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate copying of custom data between PowerPoint files.
// - Build C# tools for managing presentation metadata.
// - Integrate custom data handling into .NET PowerPoint automation pipelines.
// - Validate and synchronize custom data across multiple PPTX assets.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for source and target presentations
            var sourcePath = "source.pptx";
            var targetPath = "target.pptx";
            var outputPath = "target_with_custom_data.pptx";

            // Verify source and target files exist
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine($"Source file not found: {sourcePath}");
                return;
            }

            if (!File.Exists(targetPath))
            {
                Console.WriteLine($"Target file not found: {targetPath}");
                return;
            }

            try
            {
                // Load source and target presentations
                using (var sourcePres = new Presentation(sourcePath))
                using (var targetPres = new Presentation(targetPath))
                {
                    // Access custom data collections
                    var sourceCustomData = sourcePres.CustomData;
                    var targetCustomData = targetPres.CustomData;

                    // Copy each custom data entry from source to target
                    foreach (var entry in sourceCustomData)
                    {
                        // Preserve the original data type by assigning the value directly
                        targetCustomData[entry.Name] = entry.Value;
                    }

                    // Save the modified target presentation
                    targetPres.Save(outputPath, SaveFormat.Pptx);
                    Console.WriteLine($"Custom data copied successfully. Output saved to: {outputPath}");
                }
            }
            catch (PptxEditException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URLs or web services)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
