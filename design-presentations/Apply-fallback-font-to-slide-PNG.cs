using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input directory
            string inputDirectory = args.Length > 0 ? args[0] : string.Empty;
            if (string.IsNullOrEmpty(inputDirectory) || !Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory is missing or does not exist.");
                return;
            }

            // Determine output directory
            string outputDirectory = args.Length > 1 ? args[1] : Path.Combine(inputDirectory, "output");
            if (!Directory.Exists(outputDirectory))
                Directory.CreateDirectory(outputDirectory);

            // Load external fonts if a 'fonts' subfolder exists
            string fontsDirectory = Path.Combine(inputDirectory, "fonts");
            if (Directory.Exists(fontsDirectory))
            {
                string[] fontFolders = new string[] { fontsDirectory };
                FontsLoader.LoadExternalFonts(fontFolders);
            }

            // Process each PPTX file in the input directory
            string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx");
            foreach (string filePath in pptxFiles)
            {
                try
                {
                    using (Presentation presentation = new Presentation(filePath))
                    {
                        // Save the presentation to the output directory
                        string fileName = Path.GetFileName(filePath);
                        string outputPath = Path.Combine(outputDirectory, fileName);
                        presentation.Save(outputPath, SaveFormat.Pptx);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing '{filePath}': {ex.Message}");
                }
            }
        }
    }
}