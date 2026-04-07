using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SwfConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output paths
            string[] inputFiles = new string[]
            {
                "Presentation1.pptx",
                "Presentation2.pptx"
            };
            string outputDirectory = "SwfOutput";

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            foreach (string inputPath in inputFiles)
            {
                // Check if input file exists
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Input file not found: {inputPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".swf");

                try
                {
                    // Log start timestamp
                    DateTime startTime = DateTime.Now;
                    Console.WriteLine($"Starting conversion of '{inputPath}' at {startTime:O}");

                    // Load presentation
                    Presentation pres = new Presentation(inputPath);

                    // Create SWF options (default)
                    SwfOptions swfOptions = new SwfOptions();

                    // Save as SWF
                    pres.Save(outputPath, SaveFormat.Swf, swfOptions);

                    // Log end timestamp
                    DateTime endTime = DateTime.Now;
                    Console.WriteLine($"Finished conversion of '{inputPath}' at {endTime:O}");
                    Console.WriteLine($"Duration: {(endTime - startTime).TotalSeconds} seconds");
                    
                    // Dispose presentation
                    pres.Dispose();
                }
                catch (NotSupportedException ex)
                {
                    // Format not supported
                    Console.WriteLine($"Format not supported for file '{inputPath}': {ex.Message}");
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine($"Error converting file '{inputPath}': {ex.Message}");
                }
            }
        }
    }
}