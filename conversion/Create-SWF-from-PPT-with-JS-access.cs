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
            // Input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.swf");

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                // Input file not found; create a new empty presentation instead
                using (Presentation presentation = new Presentation())
                {
                    // Configure SWF options to allow JavaScript links (script access)
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.SkipJavaScriptLinks = false; // Do not skip JavaScript links

                    // Save the presentation as SWF
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                    // Presentation is disposed automatically by the using statement
                }
                return;
            }

            try
            {
                // Load the existing presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Configure SWF options to allow JavaScript links (script access)
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.SkipJavaScriptLinks = false; // Enable script access

                    // Save the presentation as SWF
                    presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                    // Presentation is disposed automatically by the using statement
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported or other error occurred
                Console.WriteLine("Error during conversion: " + ex.Message);
            }
        }
    }
}