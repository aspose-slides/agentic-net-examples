using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides.Export;

namespace BatchTiffConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine output directory
            string currentDirectory = Directory.GetCurrentDirectory();
            string outputDirectory = Path.Combine(currentDirectory, "output");
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // List to hold generated TIFF file paths
            System.Collections.Generic.List<string> tiffFiles = new System.Collections.Generic.List<string>();

            // Process each input file path provided as argument
            foreach (string inputPath in args)
            {
                // Check if file exists
                if (!File.Exists(inputPath))
                {
                    Console.WriteLine($"Input file does not exist: {inputPath}");
                    continue;
                }

                try
                {
                    // Load presentation
                    Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                    // Prepare TIFF options (default options)
                    Aspose.Slides.Export.TiffOptions tiffOptions = new Aspose.Slides.Export.TiffOptions();

                    // Determine output TIFF file name
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string tiffPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".tiff");

                    // Save as TIFF
                    presentation.Save(tiffPath, Aspose.Slides.Export.SaveFormat.Tiff, tiffOptions);

                    // Add to list for zipping
                    tiffFiles.Add(tiffPath);

                    // Dispose presentation
                    presentation.Dispose();
                }
                catch (NotSupportedException)
                {
                    // Format not supported
                    // Comment: format not supported
                    Console.WriteLine($"Format not supported for file: {inputPath}");
                }
                catch (Exception ex)
                {
                    // Handle other exceptions (e.g., external URLs)
                    Console.WriteLine($"Error processing file {inputPath}: {ex.Message}");
                }
            }

            // Create ZIP archive of all TIFF files
            if (tiffFiles.Count > 0)
            {
                string zipPath = Path.Combine(outputDirectory, "TIFFs.zip");
                try
                {
                    using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Create))
                    {
                        using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Create))
                        {
                            foreach (string tiffFile in tiffFiles)
                            {
                                string entryName = Path.GetFileName(tiffFile);
                                archive.CreateEntryFromFile(tiffFile, entryName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating ZIP archive: {ex.Message}");
                }
            }

            // Ensure presentation saved before exit (already saved during processing)
        }
    }
}