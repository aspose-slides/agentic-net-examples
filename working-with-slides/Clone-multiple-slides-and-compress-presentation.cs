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
            Aspose.Slides.Presentation srcPres = null;
            Aspose.Slides.Presentation destPres = null;

            try
            {
                srcPres = new Aspose.Slides.Presentation(sourcePath);
                destPres = new Aspose.Slides.Presentation();

                // Clone each slide from source to destination
                Aspose.Slides.ISlideCollection srcSlides = srcPres.Slides;
                Aspose.Slides.ISlideCollection destSlides = destPres.Slides;

                for (int i = 0; i < srcSlides.Count; i++)
                {
                    destSlides.AddClone(srcSlides[i]);
                }

                // Save the destination presentation
                destPres.Save(destinationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            finally
            {
                // Dispose presentations
                if (srcPres != null) srcPres.Dispose();
                if (destPres != null) destPres.Dispose();
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
                    {
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                        {
                            archive.CreateEntryFromFile(destinationPath, Path.GetFileName(destinationPath));
                        }
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