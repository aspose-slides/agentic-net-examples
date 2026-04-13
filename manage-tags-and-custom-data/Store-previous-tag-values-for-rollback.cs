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