using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchSwfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please provide at least one presentation file path as an argument.");
                return;
            }

            foreach (var arg in args)
            {
                try
                {
                    var inputPath = arg;
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    var fileInfo = new FileInfo(inputPath);
                    const long maxSizeBytes = 100L * 1024 * 1024; // 100 MB
                    if (fileInfo.Length > maxSizeBytes)
                    {
                        Console.WriteLine($"Skipping file larger than 100 MB: {inputPath}");
                        continue;
                    }

                    var outputPath = Path.Combine(
                        Path.GetDirectoryName(inputPath) ?? string.Empty,
                        Path.GetFileNameWithoutExtension(inputPath) + ".swf");

                    using (var presentation = new Presentation(inputPath))
                    {
                        var swfOptions = new SwfOptions();
                        // Example option: include viewer
                        swfOptions.ViewerIncluded = true;

                        presentation.Save(outputPath, SaveFormat.Swf, swfOptions);
                        Console.WriteLine($"Converted to SWF: {outputPath}");
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"The format of the file is not supported for conversion: {arg}");
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., I/O errors)
                    Console.WriteLine($"Error processing file {arg}: {ex.Message}");
                }
            }
        }
    }
}