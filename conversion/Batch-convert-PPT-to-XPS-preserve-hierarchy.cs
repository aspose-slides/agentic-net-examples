using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertPptToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source and destination directories
            string sourceRoot;
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                sourceRoot = args[0];
            }
            else
            {
                // Placeholder for source directory
                sourceRoot = @"\\NetworkShare\Presentations";
            }

            string outputRoot;
            if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
            {
                outputRoot = args[1];
            }
            else
            {
                // Placeholder for output directory
                outputRoot = @"C:\ConvertedXps";
            }

            // Verify source directory exists
            if (!Directory.Exists(sourceRoot))
            {
                Console.WriteLine("Source directory does not exist: " + sourceRoot);
                return;
            }

            // Create output root if not exists
            if (!Directory.Exists(outputRoot))
            {
                Directory.CreateDirectory(outputRoot);
            }

            // Get all .ppt and .pptx files recursively
            string[] pptFiles = Directory.GetFiles(sourceRoot, "*.ppt", SearchOption.AllDirectories);
            string[] pptxFiles = Directory.GetFiles(sourceRoot, "*.pptx", SearchOption.AllDirectories);
            string[] allFiles = new string[pptFiles.Length + pptxFiles.Length];
            pptFiles.CopyTo(allFiles, 0);
            pptxFiles.CopyTo(allFiles, pptFiles.Length);

            foreach (string inputPath in allFiles)
            {
                try
                {
                    // Ensure file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine("File not found: " + inputPath);
                        continue;
                    }

                    // Compute relative path
                    string relativePath = Path.GetRelativePath(sourceRoot, inputPath);
                    string outputDir = Path.Combine(outputRoot, Path.GetDirectoryName(relativePath));
                    if (!Directory.Exists(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    string outputFileName = Path.GetFileNameWithoutExtension(relativePath) + ".xps";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Load presentation
                    using (Presentation pres = new Presentation(inputPath))
                    {
                        // Save as XPS
                        pres.Save(outputPath, SaveFormat.Xps);
                    }

                    Console.WriteLine("Converted: " + inputPath + " -> " + outputPath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., network issues)
                    Console.WriteLine("Error processing file " + inputPath + ": " + ex.Message);
                }
            }
        }
    }
}