using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PresentationSwfProcessor
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

            // Define output directory
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "SwfOutput");
            Directory.CreateDirectory(outputDir);

            // Process each presentation in parallel
            Parallel.ForEach(inputFiles, inputPath =>
            {
                try
                {
                    // Check if the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Load the presentation
                    using (Presentation presentation = new Presentation(inputPath))
                    {
                        // Create a unique SwfOptions instance for this thread
                        SwfOptions swfOptions = new SwfOptions();
                        // Example option configuration (can be customized per thread)
                        swfOptions.Compressed = true;
                        swfOptions.ShowTopPane = true;

                        // Determine output file path
                        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".swf";
                        string outputPath = Path.Combine(outputDir, outputFileName);

                        // Save the presentation as SWF with the specified options
                        presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                        Console.WriteLine($"Successfully saved: {outputPath}");
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"Format not supported for file: {inputPath}");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., external URL issues)
                    Console.WriteLine($"Error processing file {inputPath}: {ex.Message}");
                }
            });

            // Ensure all presentations are saved before exiting
            Console.WriteLine("Processing completed.");
        }
    }
}