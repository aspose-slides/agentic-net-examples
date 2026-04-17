using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesToTiffParallel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation files
            string[] inputFiles = new string[]
            {
                "presentation1.pptx",
                "presentation2.pptx",
                "presentation3.pptx"
            };

            // Prepare output directory
            string outputDir = Path.Combine(Environment.CurrentDirectory, "TiffOutput");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Set parallel options to limit concurrency to CPU cores
            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            // Process each presentation in parallel
            Parallel.ForEach(inputFiles, parallelOptions, (inputPath) =>
            {
                try
                {
                    // Verify that the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Load the presentation
                    using (Presentation pres = new Presentation(inputPath))
                    {
                        // Determine output TIFF path
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                        string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".tiff");

                        try
                        {
                            // Save as multi‑page TIFF
                            pres.Save(outputPath, SaveFormat.Tiff);
                            Console.WriteLine($"Converted '{inputPath}' to TIFF successfully.");
                        }
                        catch (NotSupportedException)
                        {
                            // Format not supported
                            Console.WriteLine($"TIFF format not supported for file: {inputPath}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle unexpected errors (e.g., corrupted file)
                    Console.WriteLine($"Error processing '{inputPath}': {ex.Message}");
                }
            });
        }
    }
}