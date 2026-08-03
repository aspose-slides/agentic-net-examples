// -----------------------------------------------------------------------------
// Example: Extract text from ZIP archive and summarize using C#
//
// Description:
// Demonstrates how to extract text from PowerPoint presentations stored in a ZIP
// archive and summarize statistics such as total presentations, slides, and
// characters using C# and Aspose.Slides for .NET. The example shows the required
// presentation-processing steps for PPTX, PPT, and ODP files and produces the
// requested output in a standalone console application. Developers can use this
// pattern to automate PPTX workflows, validate results, or integrate presentation
// logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, PPT, ODP, Aspose.Slides for .NET, Extract, Text, Archive,
// Summarize, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of text from presentations inside a ZIP archive and
//   generate summary statistics.
// - Build C# tools for PowerPoint, PPT, and ODP presentation processing.
// - Generate or transform presentation files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

namespace PresentationTextExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the zip archive containing presentations
            string zipPath = "presentations.zip";

            // Verify zip file exists
            if (!File.Exists(zipPath))
            {
                Console.WriteLine("Zip file not found: " + zipPath);
                return;
            }

            // Summary statistics
            int totalPresentations = 0;
            int totalSlides = 0;
            int totalCharacters = 0;

            try
            {
                using (FileStream zipStream = new FileStream(zipPath, FileMode.Open, FileAccess.Read))
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
                {
                    foreach (ZipArchiveEntry entry in archive.Entries)
                    {
                        // Process only supported presentation files
                        string entryExtension = Path.GetExtension(entry.Name).ToLowerInvariant();
                        bool isSupported = entryExtension == ".pptx" || entryExtension == ".ppt" || entryExtension == ".odp";

                        if (!isSupported)
                        {
                            // Unsupported format; skip entry
                            continue;
                        }

                        // Extract entry to a temporary file
                        string tempFilePath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + entryExtension);
                        using (Stream entryStream = entry.Open())
                        using (FileStream tempFileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write))
                        {
                            entryStream.CopyTo(tempFileStream);
                        }

                        // Load presentation and extract text
                        try
                        {
                            using (Presentation pres = new Presentation(tempFilePath))
                            {
                                // Count slides
                                int slideCount = pres.Slides.Count;
                                totalSlides += slideCount;

                                // Extract all text frames (including masters)
                                ITextFrame[] textFrames = SlideUtil.GetAllTextFrames(pres, true);
                                int charCount = 0;
                                foreach (ITextFrame frame in textFrames)
                                {
                                    if (frame != null && frame.Text != null)
                                    {
                                        charCount += frame.Text.Length;
                                    }
                                }

                                totalCharacters += charCount;
                                totalPresentations++;

                                Console.WriteLine($"File: {entry.Name}, Slides: {slideCount}, Characters: {charCount}");

                                // Save presentation before exit (no modifications, just to satisfy rule)
                                string savePath = Path.Combine(Path.GetTempPath(), "saved_" + entry.Name);
                                pres.Save(savePath, SaveFormat.Pptx);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Handle format not supported or other loading errors
                            Console.WriteLine($"Failed to process {entry.Name}: {ex.Message}");
                        }
                        finally
                        {
                            // Clean up temporary file
                            if (File.Exists(tempFilePath))
                            {
                                File.Delete(tempFilePath);
                            }
                        }
                    }
                }

                // Output summary statistics
                Console.WriteLine("=== Summary ===");
                Console.WriteLine("Total presentations processed: " + totalPresentations);
                Console.WriteLine("Total slides: " + totalSlides);
                Console.WriteLine("Total characters extracted: " + totalCharacters);
            }
            catch (Exception ex)
            {
                // Handle unexpected errors (e.g., zip file corrupted)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
