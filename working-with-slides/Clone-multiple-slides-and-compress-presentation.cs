// -----------------------------------------------------------------------------
// Example: Clone all slides and compress presentation using C#
//
// Description:
// Demonstrates cloning every slide from a source PPTX file into a new presentation
// and then compressing the resulting PPTX into a ZIP archive using Aspose.Slides for .NET.
// The program creates a sample source file if it does not exist, handles errors, and
// ensures proper disposal of resources.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Clone Slides, Compress Presentation, ZIP Archive
//
// Use Cases:
// - Automate duplication of slide decks for backup or distribution.
// - Generate compressed archives of generated presentations.
// - Integrate slide cloning and archiving into batch processing pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.IO.Compression;

namespace SlideCloneAndCompress
{
    class Program
    {
        static int Main(string[] args)
        {
            int exitCode = 0;
            string sourcePath = "SourcePresentation.pptx";
            string destinationPath = "ClonedPresentation.pptx";
            string zipPath = "ClonedPresentation.zip";

            // Ensure source presentation exists; create a simple one if missing
            if (!File.Exists(sourcePath))
            {
                Aspose.Slides.Presentation samplePres = null;
                try
                {
                    samplePres = new Aspose.Slides.Presentation();
                    Aspose.Slides.ILayoutSlide layout = samplePres.Slides[0].LayoutSlide;
                    // Add an additional slide to have more than one
                    samplePres.Slides.AddEmptySlide(layout);
                    samplePres.Save(sourcePath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample source presentation: " + ex.Message);
                    exitCode = 1;
                    return exitCode;
                }
                finally
                {
                    if (samplePres != null)
                    {
                        samplePres.Dispose();
                    }
                }
            }

            Aspose.Slides.Presentation srcPres = null;
            Aspose.Slides.Presentation destPres = null;

            try
            {
                srcPres = new Aspose.Slides.Presentation(sourcePath);
                destPres = new Aspose.Slides.Presentation();

                Aspose.Slides.ISlideCollection srcSlides = srcPres.Slides;
                Aspose.Slides.ISlideCollection destSlides = destPres.Slides;

                for (int i = 0; i < srcSlides.Count; i++)
                {
                    destSlides.AddClone(srcSlides[i]);
                }

                destPres.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Slides cloned successfully to: " + destinationPath);
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("The file format is not supported.");
                exitCode = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during cloning: " + ex.Message);
                exitCode = 1;
            }
            finally
            {
                if (srcPres != null)
                {
                    srcPres.Dispose();
                }
                if (destPres != null)
                {
                    destPres.Dispose();
                }
            }

            if (exitCode != 0)
            {
                return exitCode;
            }

            // Compress the resulting PPTX file into a ZIP archive
            try
            {
                if (File.Exists(destinationPath))
                {
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
                    exitCode = 1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Compression failed: " + ex.Message);
                exitCode = 1;
            }

            return exitCode;
        }
    }
}
