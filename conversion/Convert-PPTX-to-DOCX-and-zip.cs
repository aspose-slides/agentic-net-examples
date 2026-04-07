using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToDocx
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string docxPath = "output.docx";
            string zipPath = "output.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the PPTX presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Aspose.Slides does not support saving to DOCX format.
                    // The following line is intentionally commented out because SaveFormat.Docx does not exist.
                    // presentation.Save(docxPath, Aspose.Slides.Export.SaveFormat.Docx);

                    Console.WriteLine("DOCX format is not supported by Aspose.Slides.");
                    return;
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                // Handle unsupported input file format
                Console.WriteLine("Unsupported input format: " + ex.Message);
                return;
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error: " + ex.Message);
                return;
            }

            // If DOCX were created, compress it into a ZIP archive
            if (File.Exists(docxPath))
            {
                // Remove existing ZIP if present
                if (File.Exists(zipPath))
                {
                    File.Delete(zipPath);
                }

                using (FileStream zipStream = new FileStream(zipPath, FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile(docxPath, Path.GetFileName(docxPath));
                    }
                }

                Console.WriteLine("DOCX compressed to ZIP successfully.");
            }
        }
    }
}