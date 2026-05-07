using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ParallelTiffConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input file paths are taken from command‑line arguments
            string[] inputFiles = args;

            if (inputFiles == null || inputFiles.Length == 0)
            {
                Console.WriteLine("Please provide presentation file paths as arguments.");
                return;
            }

            // Limit concurrency to the number of logical processors
            ParallelOptions parallelOptions = new ParallelOptions
            {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            Parallel.ForEach(inputFiles, parallelOptions, (inputPath) =>
            {
                try
                {
                    // Verify that the source file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Load the presentation
                    using (Presentation presentation = new Presentation(inputPath))
                    {
                        // Prepare TIFF options (default options are sufficient for basic conversion)
                        TiffOptions tiffOptions = new TiffOptions();

                        // Determine output file path (same folder, same name with .tiff extension)
                        string outputPath = Path.ChangeExtension(inputPath, ".tiff");

                        // Save the presentation as a multi‑page TIFF
                        presentation.Save(outputPath, SaveFormat.Tiff, tiffOptions);
                        Console.WriteLine($"Converted '{inputPath}' to TIFF successfully.");
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"The format of '{inputPath}' is not supported for conversion.");
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine($"Error processing '{inputPath}': {ex.Message}");
                }
            });
        }
    }
}