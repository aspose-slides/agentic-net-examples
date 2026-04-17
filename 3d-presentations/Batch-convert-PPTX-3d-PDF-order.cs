using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine the input folder: use first argument if provided, otherwise current directory
        string inputFolder;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputFolder = args[0];
        }
        else
        {
            inputFolder = Environment.CurrentDirectory;
        }

        // Verify that the input folder exists
        if (!Directory.Exists(inputFolder))
        {
            Console.WriteLine("Input folder does not exist: " + inputFolder);
            return;
        }

        // Create an output folder for the PDFs
        string outputFolder = Path.Combine(Environment.CurrentDirectory, "PdfOutput");
        if (!Directory.Exists(outputFolder))
        {
            Directory.CreateDirectory(outputFolder);
        }

        // Get all PPTX files in the input folder
        string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx");
        foreach (string pptxPath in pptxFiles)
        {
            // Process each PPTX file
            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(pptxPath);

                // Build the output PDF file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);
                string pdfPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Save the presentation as PDF (preserves slide order)
                pres.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf);

                // Dispose the presentation before moving to the next file
                pres.Dispose();

                Console.WriteLine("Converted: " + pptxPath + " -> " + pdfPath);
            }
            catch (NotSupportedException)
            {
                // Handle unsupported file format
                Console.WriteLine("File format not supported: " + pptxPath);
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