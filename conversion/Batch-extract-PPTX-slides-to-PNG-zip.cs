using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides.Export;

namespace BatchExtractSlides
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input directory containing PPTX files
            string inputDirectory = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Input");
            // Output zip file path
            string zipPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "SlidesArchive.zip");

            // Verify input directory exists
            if (!System.IO.Directory.Exists(inputDirectory))
            {
                System.Console.WriteLine("Input directory does not exist: " + inputDirectory);
                return;
            }

            // Create or overwrite zip archive
            using (System.IO.FileStream zipToOpen = new System.IO.FileStream(zipPath, System.IO.FileMode.Create))
            {
                using (System.IO.Compression.ZipArchive archive = new System.IO.Compression.ZipArchive(zipToOpen, System.IO.Compression.ZipArchiveMode.Update))
                {
                    // Process each PPTX file in the directory
                    string[] pptxFiles = System.IO.Directory.GetFiles(inputDirectory, "*.pptx");
                    foreach (string pptxFile in pptxFiles)
                    {
                        try
                        {
                            // Load presentation
                            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(pptxFile))
                            {
                                // Iterate slides
                                for (int i = 0; i < pres.Slides.Count; i++)
                                {
                                    // Get slide image
                                    Aspose.Slides.IImage slideImage = pres.Slides[i].GetImage();

                                    // Prepare entry name
                                    string entryName = System.IO.Path.GetFileNameWithoutExtension(pptxFile) + "_Slide_" + (i + 1) + ".png";

                                    // Create zip entry
                                    System.IO.Compression.ZipArchiveEntry entry = archive.CreateEntry(entryName);

                                    // Save image to zip entry stream
                                    using (System.IO.Stream entryStream = entry.Open())
                                    {
                                        slideImage.Save(entryStream, Aspose.Slides.ImageFormat.Png);
                                    }

                                    // Dispose image
                                    slideImage.Dispose();
                                }
                            }
                        }
                        catch (Aspose.Slides.PptxUnsupportedFormatException)
                        {
                            // Handle unsupported PPTX format
                            System.Console.WriteLine("Unsupported PPTX format: " + pptxFile);
                        }
                        catch (Aspose.Slides.PptUnsupportedFormatException)
                        {
                            // Handle unsupported PPT format (if any)
                            System.Console.WriteLine("Unsupported PPT format: " + pptxFile);
                        }
                        catch (System.Exception ex)
                        {
                            // General exception handling
                            System.Console.WriteLine("Error processing file " + pptxFile + ": " + ex.Message);
                        }
                    }
                }
            }

            System.Console.WriteLine("Slide extraction completed. Archive created at: " + zipPath);
        }
    }
}