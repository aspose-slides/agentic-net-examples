// -----------------------------------------------------------------------------
// Example: Store previous tag values for rollback using C#
//
// Description:
// Demonstrates how to store the previous value of a custom data tag in a PowerPoint
// presentation before updating it, enabling rollback capabilities. The example uses
// Aspose.Slides for .NET to load a PPTX file, read a tag, archive its current value
// in a hidden tag with a timestamp, update the tag with a new value, and save the
// presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Custom Data, Tags, Store, Previous,
// Values, Rollback, Presentation Processing, Office Automation
//
// Use Cases:
// - Preserve historical tag values before modification for audit or rollback.
// - Implement versioning of custom data within PowerPoint files.
// - Build .NET tools that manage tag-based metadata in presentations.
// - Automate safe updates of presentation custom data in CI/CD pipelines.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace VersionedCustomData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
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
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // TODO: Add handling for unsupported file format
                return;
            }

            // Access the tag collection for custom data
            Aspose.Slides.ITagCollection tags = presentation.CustomData.Tags;

            // Define the key for the custom data we want to version
            string dataKey = "MyCustomData";

            // Retrieve the current value if it exists
            string currentValue = null;
            if (tags.Contains(dataKey))
            {
                currentValue = tags[dataKey];
            }

            // Store the previous value in a hidden tag (prefixed with an underscore)
            if (currentValue != null)
            {
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string hiddenKey = "_" + dataKey + "_Prev_" + timestamp;
                tags.Add(hiddenKey, currentValue);
            }

            // Update the current value
            string newValue = "UpdatedValue_" + DateTime.Now.Ticks;
            if (tags.Contains(dataKey))
            {
                tags[dataKey] = newValue;
            }
            else
            {
                tags.Add(dataKey, newValue);
            }

            // Save the presentation before exiting
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved successfully to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
            finally
            {
                // Ensure resources are released
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
