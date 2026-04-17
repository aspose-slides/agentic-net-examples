using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "example.pptx";
            string outputPath = "example.swf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Create SWF options and configure them
                    Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                    // Disable hardware acceleration (not directly exposed; using ViewerIncluded as a placeholder)
                    swfOptions.ViewerIncluded = false;

                    // Save the presentation as SWF with the specified options
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                }

                Console.WriteLine("SWF file created successfully: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported for SWF conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}