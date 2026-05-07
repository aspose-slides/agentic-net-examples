using System;
using System.IO;
using Aspose.Slides.Export;

namespace BatchConvertPptxToTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine the directory containing PPTX files
            string inputDirectory = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();

            // Get all PPTX files in the directory
            string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx");

            foreach (string inputPath in pptxFiles)
            {
                // Build output TIFF file path
                string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(inputDirectory, fileNameWithoutExtension + ".tiff");

                try
                {
                    // Load the presentation
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                    // Set TIFF options with LZW compression (default)
                    Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();
                    tiffOptions.CompressionType = Aspose.Slides.Export.TiffCompressionTypes.LZW;

                    // Save the presentation as TIFF
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

                    // Dispose the presentation
                    presentation.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception)
                {
                    // Handle other exceptions as needed
                }
            }
        }
    }
}