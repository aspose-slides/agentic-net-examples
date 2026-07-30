// -----------------------------------------------------------------------------
// Example: Export media assets to ZIP preserve hierarchy using C#
//
// Description:
// Demonstrates how to export media assets from a PowerPoint presentation to a
// ZIP archive while preserving the original folder hierarchy. The example
// uses Aspose.Slides for .NET to load a PPTX file, saves it temporarily to
// access its internal ZIP structure, extracts the 'ppt/media' folder contents,
// and creates a new ZIP file containing those media assets with the same
// directory layout. This console application can be integrated into automated
// PPTX processing pipelines.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Export, Media, Assets,
// Preserve Hierarchy, ZIP, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of media assets from PPTX files while keeping folder
//   structure intact.
// - Build C# utilities for managing PowerPoint presentation resources.
// - Integrate media export functionality into .NET applications or CI/CD
//   workflows.
// - Validate and archive presentation assets before publishing or distribution.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportMediaAssets
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = "Data";
            string inputFile = Path.Combine(dataDir, "input.pptx");
            string tempFile = Path.Combine(dataDir, "temp_output.pptx");
            string outputZip = Path.Combine(dataDir, "media_assets.zip");

            // Ensure input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file does not exist: " + inputFile);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputFile))
                {
                    // Save a temporary PPTX to access its internal ZIP structure
                    pres.Save(tempFile, SaveFormat.Pptx);
                }

                // Create the ZIP archive for media assets
                using (FileStream zipToCreate = new FileStream(outputZip, FileMode.Create))
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Update))
                {
                    // Open the temporary PPTX as a ZIP archive
                    using (ZipArchive sourceArchive = ZipFile.OpenRead(tempFile))
                    {
                        foreach (ZipArchiveEntry entry in sourceArchive.Entries)
                        {
                            // Look for entries inside the ppt/media folder
                            if (entry.FullName.StartsWith("ppt/media/", StringComparison.OrdinalIgnoreCase))
                            {
                                // Preserve the folder hierarchy inside the new ZIP
                                ZipArchiveEntry newEntry = archive.CreateEntry(entry.FullName);
                                using (Stream sourceStream = entry.Open())
                                using (Stream destinationStream = newEntry.Open())
                                {
                                    sourceStream.CopyTo(destinationStream);
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Media assets exported to: " + outputZip);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            finally
            {
                // Clean up temporary file
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }
    }
}
