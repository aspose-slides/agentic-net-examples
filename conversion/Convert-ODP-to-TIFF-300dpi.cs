using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input folder
        string inputFolder;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputFolder = args[0];
        }
        else
        {
            inputFolder = Directory.GetCurrentDirectory();
        }

        // Verify folder exists
        if (!Directory.Exists(inputFolder))
        {
            Console.WriteLine("Input folder does not exist: " + inputFolder);
            return;
        }

        // Get all ODP files in the folder
        string[] odpFiles = Directory.GetFiles(inputFolder, "*.odp", SearchOption.TopDirectoryOnly);

        foreach (string inputPath in odpFiles)
        {
            try
            {
                // Load the ODP presentation
                Presentation presentation = new Presentation(inputPath);

                // Set TIFF options with 300 DPI
                TiffOptions tiffOptions = new TiffOptions();
                tiffOptions.DpiX = 300;
                tiffOptions.DpiY = 300;

                // Prepare output path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".tiff";
                string outputPath = Path.Combine(inputFolder, outputFileName);

                // Save as high‑quality TIFF
                presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);
                presentation.Dispose();

                Console.WriteLine("Converted: " + inputPath + " -> " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Format not supported for file: " + inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file: " + inputPath);
                Console.WriteLine(ex.Message);
            }
        }
    }
}