using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchOdpToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output directories (use defaults if not provided)
            string inputDir = args.Length > 0 ? args[0] : @"Input";
            string outputDir = args.Length > 1 ? args[1] : @"Output";

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Input directory does not exist: " + inputDir);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all ODP files in the input directory
            string[] odpFiles = Directory.GetFiles(inputDir, "*.odp", SearchOption.TopDirectoryOnly);

            foreach (string odpPath in odpFiles)
            {
                // Verify the file exists (redundant but safe)
                if (!File.Exists(odpPath))
                {
                    Console.WriteLine("File not found: " + odpPath);
                    continue;
                }

                try
                {
                    // Load the ODP presentation
                    using (Presentation presentation = new Presentation(odpPath))
                    {
                        // Set custom slide dimensions: 1024 x 768 points
                        presentation.SlideSize.SetSize(1024f, 768f, SlideSizeScaleType.DoNotScale);

                        // Prepare output PDF path
                        string pdfFileName = Path.GetFileNameWithoutExtension(odpPath) + ".pdf";
                        string pdfPath = Path.Combine(outputDir, pdfFileName);

                        // Save as PDF
                        presentation.Save(pdfPath, SaveFormat.Pdf);
                    }

                    Console.WriteLine("Converted: " + Path.GetFileName(odpPath));
                }
                catch (NotSupportedException)
                {
                    // Format not supported – comment as required
                    Console.WriteLine("Conversion not supported for file: " + odpPath);
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., I/O errors)
                    Console.WriteLine("Error processing file " + odpPath + ": " + ex.Message);
                }
            }

            Console.WriteLine("Batch conversion completed.");
        }
    }
}