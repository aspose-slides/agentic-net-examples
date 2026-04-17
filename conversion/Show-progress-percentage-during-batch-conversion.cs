using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDirectory = @"D:\InputPresentations";
            string outputDirectory = @"D:\ConvertedPresentations";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all supported presentation files
            string[] supportedExtensions = new string[] { ".ppt", ".pptx", ".odp", ".pptm", ".ppsx", ".ppsm", ".potx", ".potm", ".pps", ".pot", ".otp", ".fodp", ".xml" };
            string[] inputFiles = Directory.GetFiles(inputDirectory);
            var presentationFiles = new System.Collections.Generic.List<string>();
            foreach (string filePath in inputFiles)
            {
                if (Array.Exists(supportedExtensions, ext => ext.Equals(Path.GetExtension(filePath), StringComparison.OrdinalIgnoreCase)))
                {
                    presentationFiles.Add(filePath);
                }
            }

            int totalFiles = presentationFiles.Count;
            if (totalFiles == 0)
            {
                Console.WriteLine("No supported presentation files found in the input directory.");
                return;
            }

            // Process each file
            for (int i = 0; i < totalFiles; i++)
            {
                string sourcePath = presentationFiles[i];
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                string destinationPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pdf");

                try
                {
                    using (Presentation presentation = new Presentation(sourcePath))
                    {
                        // Optional: set up a progress callback for saving (if needed)
                        // Here we simply save as PDF; SaveFormat.Pdf is supported.
                        presentation.Save(destinationPath, SaveFormat.Pdf);
                    }

                    // Display progress percentage
                    int percentComplete = (int)(((i + 1) / (double)totalFiles) * 100);
                    Console.WriteLine($"Converted {Path.GetFileName(sourcePath)} ({percentComplete}% completed)");
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine($"Format not supported for file: {sourcePath}");
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., file access issues)
                    Console.WriteLine($"Error processing file {sourcePath}: {ex.Message}");
                }
            }

            Console.WriteLine("Batch conversion completed.");
        }
    }
}