using System;
using System.IO;
using System.Threading.Tasks;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfParallelProcessing
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
            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "SwfOutput");
            Directory.CreateDirectory(outputDirectory);

            // Process each presentation in a separate task
            Task[] tasks = new Task[inputFiles.Length];
            for (int i = 0; i < inputFiles.Length; i++)
            {
                string inputPath = inputFiles[i];
                tasks[i] = Task.Run(() =>
                {
                    // Check if the input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine($"Input file not found: {inputPath}");
                        return;
                    }

                    try
                    {
                        // Load the presentation
                        Presentation presentation = new Presentation(inputPath);

                        // Create a unique SwfOptions instance for this thread
                        SwfOptions swfOptions = new SwfOptions();
                        swfOptions.Compressed = true; // example setting
                        swfOptions.ShowHiddenSlides = false;

                        // Define output file path
                        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".swf";
                        string outputPath = Path.Combine(outputDirectory, outputFileName);

                        // Save the presentation as SWF with the options
                        presentation.Save(outputPath, SaveFormat.Swf, swfOptions);

                        // Dispose the presentation
                        presentation.Dispose();

                        Console.WriteLine($"Successfully processed: {inputPath}");
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported
                        // Comment: format not supported
                        Console.WriteLine($"Format not supported for file: {inputPath}");
                    }
                    catch (Exception ex)
                    {
                        // General exception handling
                        Console.WriteLine($"Error processing file {inputPath}: {ex.Message}");
                    }
                });
            }

            // Wait for all tasks to complete
            Task.WaitAll(tasks);

            // Ensure all presentations are saved before exit (already saved in each task)
            Console.WriteLine("All processing completed.");
        }
    }
}