using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvertPptToPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input directory
            string inputDirectory;
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                inputDirectory = args[0];
            }
            else
            {
                inputDirectory = Directory.GetCurrentDirectory();
            }

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Prepare output directory
            string outputDirectory = Path.Combine(inputDirectory, "Converted");
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Get all .ppt files in the input directory
            string[] pptFiles = Directory.GetFiles(inputDirectory, "*.ppt", SearchOption.TopDirectoryOnly);
            foreach (string pptFilePath in pptFiles)
            {
                // Verify file exists (redundant as GetFiles returns existing files)
                if (!File.Exists(pptFilePath))
                {
                    Console.WriteLine("File not found: " + pptFilePath);
                    continue;
                }

                try
                {
                    // Load the PPT presentation
                    using (Presentation presentation = new Presentation(pptFilePath))
                    {
                        // Build output file path with same name but .pptx extension
                        string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptFilePath);
                        string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".pptx");

                        // Save as PPTX
                        presentation.Save(outputPath, SaveFormat.Pptx);
                    }

                    Console.WriteLine("Converted: " + pptFilePath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("Format not supported for file: " + pptFilePath);
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("Error processing file " + pptFilePath + ": " + ex.Message);
                }
            }

            // Save presentation before exit (already saved within using block)
        }
    }
}