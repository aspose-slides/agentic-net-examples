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
            // Determine input directory from arguments or use default
            string inputDirectory;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputDirectory = args[0];
            }
            else
            {
                inputDirectory = "InputPptFiles";
            }

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Prepare output directory
            string outputDirectory = Path.Combine(inputDirectory, "ConvertedToPptx");
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Process each .ppt file in the input directory
            string[] pptFiles = Directory.GetFiles(inputDirectory, "*.ppt");
            foreach (string pptFilePath in pptFiles)
            {
                try
                {
                    // Load the PPT presentation
                    Presentation presentation = new Presentation(pptFilePath);

                    // Build output file path preserving original filename
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(pptFilePath);
                    string outputFilePath = Path.Combine(outputDirectory, fileNameWithoutExtension + ".pptx");

                    // Save as PPTX
                    presentation.Save(outputFilePath, SaveFormat.Pptx);

                    // Dispose the presentation object
                    presentation.Dispose();

                    Console.WriteLine("Converted: " + pptFilePath + " -> " + outputFilePath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    // Comment: The file format is not supported for conversion.
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., file access issues)
                    Console.WriteLine("Error processing file: " + pptFilePath);
                    Console.WriteLine("Exception: " + ex.Message);
                }
            }

            // Ensure all resources are released before exit
            Console.WriteLine("Batch conversion completed.");
        }
    }
}