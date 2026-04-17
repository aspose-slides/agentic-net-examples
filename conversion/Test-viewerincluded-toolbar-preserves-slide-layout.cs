using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesSwfExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Validate arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: AsposeSlidesSwfExample <input-pptx> <output-swf>");
                return;
            }

            // Input and output file paths
            string inputPath = args[0];
            string outputPath = args[1];

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure SWF options to include the viewer (toolbar)
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.ViewerIncluded = true; // Enable viewer toolbar

                    // Save as SWF while preserving original slide layout
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }

                Console.WriteLine("Presentation saved as SWF with viewer included: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}