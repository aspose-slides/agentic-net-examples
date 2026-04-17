using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchSwfConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output directories
            string inputDirectory;
            string outputDirectory;

            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputDirectory = args[0];
            }
            else
            {
                Console.WriteLine("Please provide input directory as first argument.");
                return;
            }

            if (args.Length > 1 && !String.IsNullOrEmpty(args[1]))
            {
                outputDirectory = args[1];
            }
            else
            {
                Console.WriteLine("Please provide output directory as second argument.");
                return;
            }

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine($"Input directory does not exist: {inputDirectory}");
                return;
            }

            // Create output directory if it does not exist
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Process each presentation file in the input directory
            string[] supportedExtensions = new string[] { ".ppt", ".pptx", ".odp", ".pot", ".potx" };
            string[] files = Directory.GetFiles(inputDirectory);

            foreach (string filePath in files)
            {
                try
                {
                    string extension = Path.GetExtension(filePath).ToLowerInvariant();
                    bool isSupported = false;
                    foreach (string ext in supportedExtensions)
                    {
                        if (extension == ext)
                        {
                            isSupported = true;
                            break;
                        }
                    }

                    if (!isSupported)
                    {
                        // Format not supported
                        Console.WriteLine($"Skipping unsupported format: {filePath}");
                        continue;
                    }

                    // Original file size
                    FileInfo inputInfo = new FileInfo(filePath);
                    long originalSize = inputInfo.Length;

                    // Destination SWF path
                    string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(filePath) + ".swf");

                    // Load presentation and save as SWF
                    using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(filePath))
                    {
                        Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
                        // Default options are sufficient for this example
                        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);
                    }

                    // Resulting SWF file size
                    FileInfo outputInfo = new FileInfo(outputPath);
                    long swfSize = outputInfo.Length;

                    // Log conversion details
                    Console.WriteLine($"Converted: {filePath} ({originalSize} bytes) -> {outputPath} ({swfSize} bytes)");
                }
                catch (NotSupportedException)
                {
                    // Format not supported exception handling
                    Console.WriteLine($"Format not supported for file: {filePath}");
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., file access issues)
                    Console.WriteLine($"Error processing file {filePath}: {ex.Message}");
                }
            }
        }
    }
}