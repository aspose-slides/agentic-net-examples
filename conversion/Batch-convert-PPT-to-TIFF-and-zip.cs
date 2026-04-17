using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchTiffConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output directory for TIFF files and the final ZIP archive
            var outputDir = Path.Combine(Directory.GetCurrentDirectory(), "output");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            // Process each presentation file passed as argument
            foreach (var inputPath in args)
            {
                try
                {
                    if (!File.Exists(inputPath))
                        continue; // Skip non‑existent files

                    // Load the presentation
                    using (var presentation = new Presentation(inputPath))
                    {
                        // Define TIFF output path
                        var tiffFileName = Path.GetFileNameWithoutExtension(inputPath) + ".tiff";
                        var tiffPath = Path.Combine(outputDir, tiffFileName);

                        // Convert to TIFF using default options
                        var tiffOptions = new TiffOptions();
                        presentation.Save(tiffPath, SaveFormat.Tiff, tiffOptions);
                    }
                }
                catch (NotSupportedException)
                {
                    // Format not supported – skip this file
                }
                catch (Exception)
                {
                    // Handle other unexpected errors if needed
                }
            }

            // Create ZIP archive containing all generated TIFF files
            var zipPath = Path.Combine(outputDir, "tiff_archive.zip");
            using (var zipStream = new FileStream(zipPath, FileMode.Create))
            using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Create))
            {
                var tiffFiles = Directory.GetFiles(outputDir, "*.tiff");
                foreach (var tiffFile in tiffFiles)
                {
                    var entryName = Path.GetFileName(tiffFile);
                    archive.CreateEntryFromFile(tiffFile, entryName);
                }
            }
        }
    }
}