using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine input folder (first argument or default)
        string inputFolder;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputFolder = args[0];
        }
        else
        {
            inputFolder = "InputPptx"; // default folder
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
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(pptxPath);

                // Build output PDF path preserving original filename
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);
                string pdfPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Save as PDF
                pres.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf);

                // Dispose presentation before moving to next file
                pres.Dispose();

                Console.WriteLine("Converted: " + pptxPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Format not supported for file: " + pptxPath);
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