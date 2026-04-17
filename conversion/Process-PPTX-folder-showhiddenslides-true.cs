using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Determine the folder to process
        string inputDirectory;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputDirectory = args[0];
        }
        else
        {
            inputDirectory = Directory.GetCurrentDirectory();
        }

        // Verify the folder exists
        if (!Directory.Exists(inputDirectory))
        {
            Console.WriteLine("Input directory does not exist: " + inputDirectory);
            return;
        }

        // Get all PPTX files in the folder
        string[] pptxFiles = Directory.GetFiles(inputDirectory, "*.pptx", SearchOption.TopDirectoryOnly);

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

                    // Build the output PDF file path
                    string directory = Path.GetDirectoryName(pptxPath);
                    string filenameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);
                    string pdfPath = Path.Combine(directory, filenameWithoutExt + ".pdf");

                    // Save the presentation as PDF with hidden slides
                    presentation.Save(pdfPath, SaveFormat.Pdf, pdfOptions);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error processing file " + pptxPath + ": " + ex.Message);
            }
        }
    }
}