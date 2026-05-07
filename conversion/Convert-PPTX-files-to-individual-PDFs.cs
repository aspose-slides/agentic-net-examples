using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine the input folder: from args or current directory
            string inputFolder;
            if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                inputFolder = args[0];
            }
            else
            {
                inputFolder = Directory.GetCurrentDirectory();
            }

            // Verify that the folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }

            // Get all PPTX files in the folder
            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");

            // Convert each PPTX to PDF
            foreach (string pptxPath in pptxFiles)
            {
                try
                {
                    // Load the presentation
                    Presentation pres = new Presentation(pptxPath);

                    // Build the output PDF path
                    string pdfPath = Path.Combine(inputFolder, Path.GetFileNameWithoutExtension(pptxPath) + ".pdf");

                    // Save the presentation as PDF
                    pres.Save(pdfPath, SaveFormat.Pdf);

                    // Release resources
                    pres.Dispose();

                    Console.WriteLine("Converted: " + pptxPath + " -> " + pdfPath);
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    Console.WriteLine("File format not supported for file: " + pptxPath);
                }
                catch (Exception ex)
                {
                    // General error handling
                    Console.WriteLine("Error processing file: " + pptxPath);
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}