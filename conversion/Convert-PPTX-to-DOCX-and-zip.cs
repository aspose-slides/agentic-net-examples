// -----------------------------------------------------------------------------
// Example: Convert PPTX to PDF and ZIP Archive using Aspose.Slides for .NET
//
// Description:
// This console application demonstrates how to load a PowerPoint PPTX file,
// convert it to a PDF document using Aspose.Slides for .NET, and then compress
// the resulting PDF into a ZIP archive. It includes file existence checks,
// handles unsupported format exceptions, and ensures the presentation is saved
// before the application exits.
//
// Keywords:
// C#, PowerPoint, PPTX, PDF, ZIP, Aspose.Slides for .NET, presentation conversion, automation
//
// Use Cases:
// - Automate batch conversion of PPTX presentations to PDF for archival.
// - Integrate PPTX to PDF workflow into a CI/CD pipeline.
// - Provide downloadable PDF packages of slide decks in web applications.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.IO.Compression;

namespace AsposeSlidesPptxToPdfZip
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath;
            if (args.Length > 0)
            {
                inputPath = args[0];
            }
            else
            {
                Console.WriteLine("Please provide the full path to the PPTX file as the first argument.");
                return;
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            string pdfPath = Path.ChangeExtension(inputPath, ".pdf");
            string zipPath = Path.ChangeExtension(inputPath, ".zip");

            try
            {
                // Load the PPTX presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Convert and save as PDF
                presentation.Save(pdfPath, Aspose.Slides.Export.SaveFormat.Pdf);

                // Ensure the presentation resources are released
                presentation.Dispose();

                // Create ZIP archive containing the PDF
                using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile(pdfPath, Path.GetFileName(pdfPath));
                    }
                }

                Console.WriteLine($"Conversion successful. PDF saved to: {pdfPath}");
                Console.WriteLine($"ZIP archive created at: {zipPath}");
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine($"The provided file is not a supported PPTX format: {ex.Message}");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException ex)
            {
                Console.WriteLine($"The provided file is not a supported PPT format: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
