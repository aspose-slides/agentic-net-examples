// -----------------------------------------------------------------------------
// Example: Batch Convert PPTX with 3D Content to PDF Preserving Slide Order
//
// Description:
// This console application scans a specified folder for PPTX files that may
// contain 3D content, loads each presentation using Aspose.Slides for .NET, and
// saves it as a PDF while keeping the original slide order. It validates input
// and output directories, handles unsupported format exceptions, and logs the
// conversion progress.
//
// Keywords:
// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, batch conversion, 3D content
//
// Use Cases:
// - Automate conversion of a large collection of PPTX decks to PDF for archiving.
// - Preserve slide order when generating PDF reports from presentations.
// - Safely process files that might contain unsupported 3D features.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace BatchConvertPptxToPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFolder = "InputPptx";
            string outputFolder = "OutputPdf";

            if (!Directory.Exists(inputFolder))
            {
                Console.WriteLine($"Input folder '{inputFolder}' does not exist.");
                return;
            }

            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            string[] pptxFiles = Directory.GetFiles(inputFolder, "*.pptx", SearchOption.TopDirectoryOnly);
            Array.Sort(pptxFiles, StringComparer.InvariantCultureIgnoreCase);

            foreach (string pptxPath in pptxFiles)
            {
                try
                {
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(pptxPath);
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(pptxPath);
                    string pdfPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");
                    presentation.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf);
                    presentation.Dispose();
                    Console.WriteLine($"Converted '{pptxPath}' to PDF.");
                }
                catch (Aspose.Slides.PptxUnsupportedFormatException ex)
                {
                    Console.WriteLine($"Unsupported format for file '{pptxPath}': {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing file '{pptxPath}': {ex.Message}");
                }
            }

            Console.WriteLine("Batch conversion completed.");
        }
    }
}
