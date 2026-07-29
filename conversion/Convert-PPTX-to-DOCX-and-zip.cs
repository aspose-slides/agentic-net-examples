// -----------------------------------------------------------------------------
// Example: Convert PPTX to PDF and zip using C#
//
// Description:
// Demonstrates how to convert a PPTX file to PDF using Aspose.Slides for .NET
// and then compress the resulting PDF into a ZIP archive. The example shows
// the required presentation-processing steps for PowerPoint files and
// produces the requested output in a standalone console application. Developers
// can use this pattern to automate PPTX to PDF workflows, validate results,
// or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, PDF, Aspose.Slides for .NET, Convert, Presentation Processing,
// Office Automation, Zip, Compression
//
// Use Cases:
// - Automate conversion of PPTX to PDF and archive the result.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using Aspose.Slides;
using Aspose.Slides.Export;
using System;
using System.IO;
using System.IO.Compression;

namespace ConvertPptxToPdfAndZip
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input.pptx";
            string outputPdf = "output.pdf";
            string zipFile = "output.zip";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist: " + inputFile);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation(inputFile))
                {
                    // Convert PPTX to PDF.
                    presentation.Save(outputPdf, SaveFormat.Pdf);
                }

                // Compress the resulting PDF using zip compression.
                if (File.Exists(outputPdf))
                {
                    if (File.Exists(zipFile))
                    {
                        File.Delete(zipFile);
                    }

                    using (FileStream zipToOpen = new FileStream(zipFile, FileMode.Create))
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile(outputPdf, Path.GetFileName(outputPdf), CompressionLevel.Optimal);
                    }

                    Console.WriteLine("Compression completed: " + zipFile);
                }
                else
                {
                    Console.WriteLine("PDF file was not created.");
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported.
                Console.WriteLine("The requested format is not supported by Aspose.Slides.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
