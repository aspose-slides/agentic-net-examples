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
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.swf";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Configure SWF options
                SwfOptions swfOptions = new SwfOptions();
                swfOptions.ShowHiddenSlides = true; // Include hidden slides

                // Save the presentation as SWF with default compression
                presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation converted to SWF successfully.");
            }
            catch (Exception ex)
            {
                // Handle format not supported or other exceptions
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}