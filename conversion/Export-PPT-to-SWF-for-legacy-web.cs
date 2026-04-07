using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";
            string outputPath = args.Length > 1 ? args[1] : "output.swf";

            // Verify that the input file exists
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
                    // Configure SWF export options
                    SwfOptions swfOptions = new SwfOptions();
                    // Example: disable the integrated viewer if not needed
                    swfOptions.ViewerIncluded = false;

                    // Save the presentation as SWF
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                }

                Console.WriteLine("Presentation successfully exported to SWF: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}