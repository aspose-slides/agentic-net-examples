using System;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchShapeThumbnails
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input directory containing PPTX files
            string inputDirectory = "InputPpts";
            // Output ZIP file path
            string outputZipPath = "ShapeThumbnails.zip";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Input directory does not exist.");
                return;
            }

            // Get all PPTX files in the directory
            string[] pptFiles = Directory.GetFiles(inputDirectory, "*.pptx");
            if (pptFiles.Length == 0)
            {
                Console.WriteLine("No PPTX files found in the input directory.");
                return;
            }

            // Create or overwrite the ZIP archive
            using (FileStream zipStream = new FileStream(outputZipPath, FileMode.Create))
            using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Update))
            {
                foreach (string pptPath in pptFiles)
                {
                    // Ensure the file exists before processing
                    if (!File.Exists(pptPath))
                    {
                        Console.WriteLine($"File not found: {pptPath}");
                        continue;
                    }

                    try
                    {
                        // Load the presentation
                        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(pptPath);

                        // Iterate through slides
                        for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                        {
                            Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                            // Iterate through shapes on the slide
                            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                            {
                                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                                // Get shape thumbnail image
                                Aspose.Slides.IImage shapeImage = shape.GetImage();

                                // Define entry name inside the ZIP
                                string entryName = $"{Path.GetFileNameWithoutExtension(pptPath)}_slide{slideIndex + 1}_shape{shapeIndex + 1}.png";

                                // Add image to ZIP archive
                                ZipArchiveEntry entry = archive.CreateEntry(entryName);
                                using (Stream entryStream = entry.Open())
                                {
                                    shapeImage.Save(entryStream, Aspose.Slides.ImageFormat.Png);
                                }
                            }
                        }

                        // Save the presentation before exiting (as required by lifecycle rule)
                        pres.Save(pptPath, Aspose.Slides.Export.SaveFormat.Pptx);
                        pres.Dispose();
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported
                        Console.WriteLine($"Format not supported for file: {pptPath}");
                    }
                    catch (Exception ex)
                    {
                        // General error handling
                        Console.WriteLine($"Error processing file {pptPath}: {ex.Message}");
                    }
                }
            }

            Console.WriteLine("Shape thumbnails have been extracted and saved to the ZIP archive.");
        }
    }
}