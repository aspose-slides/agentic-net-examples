using System;
using System.IO;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Determine bandwidth constraints (placeholder logic)
            bool highBandwidth = true; // Set to false for low bandwidth scenarios

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Configure SWF options based on bandwidth
                Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                swfOptions.Compressed = highBandwidth; // Enable compression for high bandwidth

                // Save the presentation as SWF with the specified options
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

                // Clean up resources
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}