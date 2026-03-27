using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LargePresentationExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "large_presentation.pptx";
            string outputPdfPath = "large_presentation.pdf";
            string copyPptxPath = "large_presentation_copy.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Configure load options to handle large BLOBs efficiently
            LoadOptions loadOptions = new LoadOptions
            {
                BlobManagementOptions = new BlobManagementOptions
                {
                    PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked
                }
            };

            // Load the presentation with the specified options
            using (Presentation presentation = new Presentation(inputPath, loadOptions))
            {
                // Save a copy of the presentation (optional, satisfies "save presentation before exit")
                presentation.Save(copyPptxPath, SaveFormat.Pptx);

                // Export the presentation to PDF using a memory stream (BLOB stream)
                using (MemoryStream pdfStream = new MemoryStream())
                {
                    presentation.Save(pdfStream, SaveFormat.Pdf);
                    // Write the PDF stream to the output file
                    File.WriteAllBytes(outputPdfPath, pdfStream.ToArray());
                }
            }

            Console.WriteLine("Export completed successfully.");
        }
    }
}