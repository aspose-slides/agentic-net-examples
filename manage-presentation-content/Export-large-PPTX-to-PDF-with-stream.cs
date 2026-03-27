using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportLargePresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "large_presentation.pptx";
            // Output PDF file path
            string outputPath = "large_presentation.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Configure load options for BLOB streaming with KeepLocked behavior
            LoadOptions loadOptions = new LoadOptions();
            loadOptions.BlobManagementOptions = new BlobManagementOptions();
            loadOptions.BlobManagementOptions.IsTemporaryFilesAllowed = true;
            loadOptions.BlobManagementOptions.PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked;

            // Open input file stream
            FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            // Load presentation using the stream and load options
            Presentation presentation = new Presentation(inputStream, loadOptions);

            // Create output file stream for PDF
            FileStream outputStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);
            // Save presentation to PDF using the output stream
            presentation.Save(outputStream, SaveFormat.Pdf);

            // Clean up resources
            outputStream.Close();
            inputStream.Close();
            presentation.Dispose();

            Console.WriteLine("Export completed successfully.");
        }
    }
}