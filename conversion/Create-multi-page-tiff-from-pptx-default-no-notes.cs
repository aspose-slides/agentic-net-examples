using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";
            // Output TIFF file path
            string outputPath = "output.tiff";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Create TiffOptions with default compression (LZW)
                Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

                // Save the presentation as a multi‑page TIFF without notes
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

                // Dispose the presentation object
                presentation.Dispose();

                Console.WriteLine("TIFF file created successfully.");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}