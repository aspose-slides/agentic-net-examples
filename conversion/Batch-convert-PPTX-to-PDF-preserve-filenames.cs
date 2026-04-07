using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine input folder
            string inputFolder;
            if (args.Length > 0 && !String.IsNullOrEmpty(args[0]))
            {
                inputFolder = args[0];
            }
            else
            {
                inputFolder = "InputPptx";
            }

            // Verify input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine("Input folder does not exist: " + inputFolder);
                return;
            }

            // Prepare output folder
            string outputFolder = Path.Combine(inputFolder, "PdfOutput");
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            // Get all PPTX files in the input folder
            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");
            foreach (string pptxPath in pptxFiles)
            {
                try
                {
                    // Load presentation (load rule)
                    Presentation pres = new Presentation(pptxPath);

                    // Build output PDF path preserving original filename
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);
                    string pdfPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                    // Save as PDF (save rule)
                    pres.Save(pdfPath, SaveFormat.Pdf);

                    // Dispose presentation
                    pres.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error processing file " + pptxPath + ": " + ex.Message);
                }
            }
        }
    }
}