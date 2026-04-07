using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath;
        if (args.Length > 0 && !string.IsNullOrEmpty(args[0]))
        {
            inputPath = args[0];
        }
        else
        {
            inputPath = "input.pptx"; // default input
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Create temporary directory for SVG files
            string tempDir = Path.Combine(Path.GetTempPath(), "SvgExport_" + Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);

            // Convert each slide to SVG
            for (int i = 0; i < pres.Slides.Count; i++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[i];
                string svgPath = Path.Combine(tempDir, $"slide_{i + 1}.svg");
                using (FileStream stream = new FileStream(svgPath, FileMode.Create, FileAccess.Write))
                {
                    slide.WriteAsSvg(stream);
                }
            }

            // Create zip archive containing SVG files
            string zipPath = Path.Combine(Path.GetDirectoryName(inputPath) ?? Directory.GetCurrentDirectory(), "slides_svg.zip");
            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                {
                    string[] files = Directory.GetFiles(tempDir, "*.svg");
                    foreach (string file in files)
                    {
                        string entryName = Path.GetFileName(file);
                        archive.CreateEntryFromFile(file, entryName);
                    }
                }
            }

            // Cleanup temporary SVG files
            Directory.Delete(tempDir, true);

            // Save presentation before exit (no modifications)
            string dummySavePath = Path.Combine(Path.GetDirectoryName(inputPath) ?? Directory.GetCurrentDirectory(), "dummy_save.pptx");
            pres.Save(dummySavePath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();

            Console.WriteLine("SVG files have been zipped to: " + zipPath);
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}