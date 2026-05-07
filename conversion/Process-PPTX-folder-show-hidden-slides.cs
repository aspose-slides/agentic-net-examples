using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ProcessPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine the directory to process
            string inputDirectory;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputDirectory = args[0];
            }
            else
            {
                inputDirectory = Directory.GetCurrentDirectory();
            }

            // Verify that the directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("The specified directory does not exist: " + inputDirectory);
                return;
            }

            // Get all PPTX files in the directory
            string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx");

            foreach (string pptxPath in pptxFiles)
            {
                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(pptxPath))
                    {
                        // Set PDF options to include hidden slides
                        PdfOptions pdfOptions = new PdfOptions();
                        pdfOptions.ShowHiddenSlides = true;

                        // Determine output PDF path
                        string outputPdfPath = Path.Combine(
                            inputDirectory,
                            Path.GetFileNameWithoutExtension(pptxPath) + ".pdf");

                        // Save as PDF with hidden slides included
                        presentation.Save(outputPdfPath, SaveFormat.Pdf, pdfOptions);
                    }

                    Console.WriteLine("Converted: " + pptxPath);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format or other errors
                    Console.WriteLine("Failed to process file: " + pptxPath);
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}