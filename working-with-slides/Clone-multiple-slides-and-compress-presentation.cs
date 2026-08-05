// -----------------------------------------------------------------------------
// Example: Clone multiple slides and compress presentation using C#
//
// Description:
// Demonstrates how to clone all slides from a source PowerPoint file into a new
// presentation and then compress the resulting PPTX file into a ZIP archive using
// Aspose.Slides for .NET. The example includes file existence checks, proper
// disposal of presentation objects, and basic error handling for both cloning
// and compression steps.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slides, Multiple Slides,
// Compress Presentation, ZIP Archive, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate cloning of all slides from one presentation to another.
// - Create backup ZIP archives of generated PPTX files.
// - Build .NET tools for batch processing and distribution of PowerPoint content.
// - Integrate slide cloning and compression into larger document workflows.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideBatchClone
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define source and destination file paths
            string sourcePath = "SourcePresentation.pptx";
            string destinationPath = "ClonedPresentation.pptx";
            string zipPath = "ClonedPresentation.zip";

            // Verify source file exists
            if (!File.Exists(sourcePath))
            {
                Console.WriteLine("Source file does not exist: " + sourcePath);
                return;
            }

            // Initialize presentations
            Presentation srcPres = null;
            Presentation destPres = null;

            try
            {
                srcPres = new Presentation(sourcePath);
                destPres = new Presentation();

                // Clone each slide from source to destination
                ISlideCollection srcSlides = srcPres.Slides;
                ISlideCollection destSlides = destPres.Slides;

                for (int i = 0; i < srcSlides.Count; i++)
                {
                    destSlides.AddClone(srcSlides[i]);
                }

                // Save the destination presentation
                destPres.Save(destinationPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            finally
            {
                // Dispose presentations
                srcPres?.Dispose();
                destPres?.Dispose();
            }

            // Compress the resulting PPTX file
            try
            {
                if (File.Exists(destinationPath))
                {
                    // Delete existing zip if present
                    if (File.Exists(zipPath))
                    {
                        File.Delete(zipPath);
                    }

                    using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
                    using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                    {
                        archive.CreateEntryFromFile(destinationPath, Path.GetFileName(destinationPath));
                    }

                    Console.WriteLine("Presentation compressed to: " + zipPath);
                }
                else
                {
                    Console.WriteLine("Destination file not found for compression.");
                }
            }
            catch (Exception ex)
            {
                // Handle any compression-related exceptions
                Console.WriteLine("Compression failed: " + ex.Message);
            }
        }
    }
}
