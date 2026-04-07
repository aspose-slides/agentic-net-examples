using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace TiffConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation files
            string[] inputFiles = new string[]
            {
                "Presentation1.pptx",
                "Presentation2.pptx",
                "Presentation3.pptx"
            };

            // Reuse a single TiffOptions instance
            Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
            tiffOptions.DpiX = 200U;
            tiffOptions.DpiY = 200U;

            foreach (string inputPath in inputFiles)
            {
                // Check if the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Input file not found: {inputPath}");
                    continue;
                }

                // Determine output file path
                string outputPath = Path.ChangeExtension(inputPath, ".tiff");

                try
                {
                    // Load the presentation
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                    // Save as TIFF using the shared TiffOptions instance
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

                    // Save presentation before exit (already saved as TIFF)
                    // If additional saving of the original presentation is needed:
                    // pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"The format of the file '{inputPath}' is not supported for TIFF conversion.");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., file access issues)
                    Console.WriteLine($"Error processing file '{inputPath}': {ex.Message}");
                }
            }
        }
    }
}