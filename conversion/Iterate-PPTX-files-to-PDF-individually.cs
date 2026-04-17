using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlidesToPdfConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine the input folder (first argument or default "Input")
            string inputFolder = args.Length > 0 && !String.IsNullOrEmpty(args[0]) ? args[0] : "Input";

            // Verify that the folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("The specified input folder does not exist: " + inputFolder);
                return;
            }

            // Get all PPTX files in the folder
            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");

            // Process each PPTX file
            foreach (string pptxPath in pptxFiles)
            {
                // Ensure the file still exists before processing
                if (!File.Exists(pptxPath))
                {
                    continue;
                }

                try
                {
                    // Load the presentation
                    Presentation presentation = new Presentation(pptxPath);

                    // Build the output PDF path
                    string pdfPath = Path.Combine(
                        inputFolder,
                        Path.GetFileNameWithoutExtension(pptxPath) + ".pdf");

                    // Save as PDF
                    presentation.Save(pdfPath, SaveFormat.Pdf);

                    // Release resources
                    presentation.Dispose();

                    Console.WriteLine("Converted: " + pptxPath + " -> " + pdfPath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("The file format is not supported for conversion: " + pptxPath);
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine("Error processing file " + pptxPath + ": " + ex.Message);
                }
            }
        }
    }
}