using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main()
        {
            // Define input and output file paths
            var inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.swf");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Configure SWF options to exclude the integrated viewer
                    SwfOptions swfOptions = new SwfOptions();
                    swfOptions.ViewerIncluded = false;

                    // Save the presentation as SWF with the specified options
                    pres.Save(outputPath, SaveFormat.Swf, swfOptions);
                }

                Console.WriteLine("Presentation saved successfully without viewer: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle errors such as unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}