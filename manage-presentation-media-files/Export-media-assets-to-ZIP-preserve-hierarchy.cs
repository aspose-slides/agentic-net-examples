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