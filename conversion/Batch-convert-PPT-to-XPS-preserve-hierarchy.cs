using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertPptToXps
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input directory (network share) and output directory can be passed as arguments
            string inputRoot;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputRoot = args[0];
            }
            else
            {
                inputRoot = @"\\networkshare\presentations";
            }

            string outputRoot;
            if (args.Length > 1 && !String.IsNullOrEmpty(args[1]))
            {
                outputRoot = args[1];
            }
            else
            {
                outputRoot = @"C:\ConvertedXps";
            }

            // Verify that the input directory exists
            if (!Directory.Exists(inputRoot))
            {
                Console.WriteLine("Input directory does not exist: " + inputRoot);
                return;
            }

            // Ensure the output root directory exists
            if (!Directory.Exists(outputRoot))
            {
                Directory.CreateDirectory(outputRoot);
            }

            // Collect all .ppt and .pptx files recursively
            List<string> allFiles = new List<string>();
            allFiles.AddRange(Directory.GetFiles(inputRoot, "*.ppt", SearchOption.AllDirectories));
            allFiles.AddRange(Directory.GetFiles(inputRoot, "*.pptx", SearchOption.AllDirectories));

            foreach (string inputFilePath in allFiles)
            {
                // Compute relative path to preserve folder hierarchy
                string relativePath = Path.GetRelativePath(inputRoot, inputFilePath);
                string outputFilePath = Path.Combine(outputRoot, Path.ChangeExtension(relativePath, ".xps"));
                string outputDirectory = Path.GetDirectoryName(outputFilePath);

                // Ensure the output subdirectory exists
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                try
                {
                    // Load the presentation and save as XPS
                    using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputFilePath))
                    {
                        pres.Save(outputFilePath, SaveFormat.Xps);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported – skip this file
                    Console.WriteLine("File format not supported for: " + inputFilePath);
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., file access issues)
                    Console.WriteLine("Error processing file: " + inputFilePath);
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }

            // All presentations have been saved before exiting
        }
    }
}