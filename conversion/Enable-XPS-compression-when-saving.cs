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
            // Input PowerPoint file path
            string inputPath = "input.pptx";
            // Output XPS file path
            string outputPath = "output.xps";

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
                    // Create XPS save options
                    XpsOptions xpsOptions = new XpsOptions();

                    // NOTE: The XpsOptions class does not contain a 'Compress' property in the current API.
                    // If compression is required, use the appropriate options provided by the library.
                    // For demonstration, we enable saving metafiles as PNG.
                    xpsOptions.SaveMetafilesAsPng = true;

                    // Save the presentation as XPS with the specified options
                    presentation.Save(outputPath, SaveFormat.Xps, xpsOptions);
                }

                Console.WriteLine("Presentation saved successfully to XPS format.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., I/O errors, licensing issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}