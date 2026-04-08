using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input directory containing presentations to import
        string inputDir = Path.Combine(Environment.CurrentDirectory, "InputPresentations");
        // Output directory where updated presentations will be saved
        string outputDir = Path.Combine(Environment.CurrentDirectory, "OutputPresentations");

        if (!Directory.Exists(inputDir))
        {
            Console.WriteLine("Input directory does not exist: " + inputDir);
            return;
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Supported PowerPoint file extensions
        string[] supportedExtensions = new string[] { ".ppt", ".pptx", ".odp", ".pot", ".potx", ".pptm", ".pptb" };
        string[] allFiles = Directory.GetFiles(inputDir, "*.*", SearchOption.AllDirectories);

        foreach (string filePath in allFiles)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();
            if (Array.IndexOf(supportedExtensions, extension) < 0)
            {
                // Skip files with unsupported formats
                Console.WriteLine("Skipping unsupported file format: " + filePath);
                continue;
            }

            if (!File.Exists(filePath))
            {
                Console.WriteLine("File does not exist: " + filePath);
                continue;
            }

            try
            {
                // Load the presentation
                Presentation pres = new Presentation(filePath);

                // Determine category from the immediate parent folder name
                string parentFolder = Path.GetFileName(Path.GetDirectoryName(filePath));
                IDocumentProperties docProps = pres.DocumentProperties;
                docProps.Category = parentFolder;

                // Preserve relative folder structure in the output directory
                string relativePath = Path.GetRelativePath(inputDir, filePath);
                string outputPath = Path.Combine(outputDir, relativePath);
                string outputFolder = Path.GetDirectoryName(outputPath);
                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                // Save the updated presentation (always save before exit)
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Processed: " + filePath);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other processing errors
                Console.WriteLine("Error processing file: " + filePath);
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}