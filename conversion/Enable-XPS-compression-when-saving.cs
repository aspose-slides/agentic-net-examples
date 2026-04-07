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
                Presentation presentation = new Presentation(inputPath);

                // Create XPS save options
                XpsOptions xpsOptions = new XpsOptions();

                // Note: The XpsOptions class does not expose a 'Compress' property in this version.
                // Compression for XPS is handled internally; if a 'Compress' property becomes available,
                // it can be set here (e.g., xpsOptions.Compress = true;).

                // Save the presentation as XPS with the specified options
                presentation.Save(outputPath, SaveFormat.Xps, xpsOptions);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file access issues, Aspose.Slides errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}