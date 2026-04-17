using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TiffExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.tiff");

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

                // Configure TIFF options with LZW compression
                TiffOptions tiffOptions = new TiffOptions();
                tiffOptions.CompressionType = TiffCompressionTypes.LZW;

                // Save the presentation as a multi‑page TIFF (notes are excluded by default)
                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);

                // Dispose the presentation to release resources
                presentation.Dispose();

                Console.WriteLine("TIFF file created successfully at: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: The provided file format is not supported for conversion.
                Console.WriteLine("The file format is not supported for TIFF conversion.");
            }
            catch (Exception ex)
            {
                // Handle other unexpected exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}