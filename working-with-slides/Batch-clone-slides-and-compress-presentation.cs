using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.IO.Compression;

class Program
{
    static void Main()
    {
        // Paths for source, destination and compressed files
        string sourcePath = "source.pptx";
        string destPath = "dest.pptx";
        string zipPath = "dest.zip";

        // Verify source file exists
        if (!File.Exists(sourcePath))
        {
            Console.WriteLine("Source file does not exist.");
            return;
        }

        try
        {
            // Load source presentation
            Aspose.Slides.Presentation srcPres = new Aspose.Slides.Presentation(sourcePath);
            // Create destination presentation
            Aspose.Slides.Presentation destPres = new Aspose.Slides.Presentation();

            // Collections of slides
            Aspose.Slides.ISlideCollection srcSlides = srcPres.Slides;
            Aspose.Slides.ISlideCollection destSlides = destPres.Slides;

            // Batch clone each slide from source to destination
            for (int i = 0; i < srcSlides.Count; i++)
            {
                destSlides.AddClone(srcSlides[i]);
            }

            // Save the destination presentation
            destPres.Save(destPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Release resources
            srcPres.Dispose();
            destPres.Dispose();

            // Compress the resulting PPTX file
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }
            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    archive.CreateEntryFromFile(destPath, Path.GetFileName(destPath));
                }
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}