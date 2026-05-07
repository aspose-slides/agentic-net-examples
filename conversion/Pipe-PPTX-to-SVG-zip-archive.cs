using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Check if any input files are provided
        if (args == null || args.Length == 0)
        {
            Console.WriteLine("Please provide at least one PPTX file path as an argument.");
            return;
        }

        // Process each input file
        for (int argIndex = 0; argIndex < args.Length; argIndex++)
        {
            string inputPath = args[argIndex];

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"File not found: {inputPath}");
                continue;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                // Determine the output ZIP file path
                string zipPath = Path.Combine(
                    Path.GetDirectoryName(inputPath),
                    Path.GetFileNameWithoutExtension(inputPath) + ".zip");

                // Create ZIP archive and add each slide as an SVG entry
                using (FileStream zipFileStream = new FileStream(zipPath, FileMode.Create))
                using (ZipArchive zipArchive = new ZipArchive(zipFileStream, ZipArchiveMode.Create))
                {
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                        string entryName = $"slide_{slideIndex + 1}.svg";

                        ZipArchiveEntry entry = zipArchive.CreateEntry(entryName);
                        using (Stream entryStream = entry.Open())
                        {
                            // Write slide content as SVG directly into the ZIP entry
                            slide.WriteAsSvg(entryStream);
                        }
                    }
                }

                // Save the presentation (no modifications) using ZIP64 mode as required by the rule
                string savedPath = Path.Combine(
                    Path.GetDirectoryName(inputPath),
                    Path.GetFileNameWithoutExtension(inputPath) + "_saved.pptx");

                pres.Save(
                    savedPath,
                    Aspose.Slides.Export.SaveFormat.Pptx,
                    new Aspose.Slides.Export.PptxOptions()
                    {
                        Zip64Mode = Aspose.Slides.Export.Zip64Mode.Always
                    });

                // Dispose the presentation
                pres.Dispose();

                Console.WriteLine($"Processed '{inputPath}' successfully. SVG ZIP: '{zipPath}'");
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine($"The file format of '{inputPath}' is not supported for conversion.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine($"An error occurred while processing '{inputPath}': {ex.Message}");
            }
        }
    }
}