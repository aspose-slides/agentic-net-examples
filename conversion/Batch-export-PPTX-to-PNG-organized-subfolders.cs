using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchExportPptToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine source directory (first argument or current directory)
            string sourceDirectory = args.Length > 0 ? args[0] : Directory.GetCurrentDirectory();
            // Determine output base directory (second argument or a folder named "Exported" in current directory)
            string outputBaseDirectory = args.Length > 1 ? args[1] : Path.Combine(Directory.GetCurrentDirectory(), "Exported");

            // Ensure output base directory exists
            if (!Directory.Exists(outputBaseDirectory))
            {
                Directory.CreateDirectory(outputBaseDirectory);
            }

            // Get all PPT and PPTX files in the source directory
            string[] presentationFiles = Directory.GetFiles(sourceDirectory, "*.ppt*");

            foreach (string presentationPath in presentationFiles)
            {
                // Verify the file exists (important)
                if (!File.Exists(presentationPath))
                {
                    Console.WriteLine($"File not found: {presentationPath}");
                    continue;
                }

                try
                {
                    // Load the presentation
                    using (Presentation presentation = new Presentation(presentationPath))
                    {
                        // Create a subfolder named after the presentation (without extension)
                        string presentationName = Path.GetFileNameWithoutExtension(presentationPath);
                        string presentationOutputFolder = Path.Combine(outputBaseDirectory, presentationName);
                        if (!Directory.Exists(presentationOutputFolder))
                        {
                            Directory.CreateDirectory(presentationOutputFolder);
                        }

                        // Export each slide to PNG
                        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                        {
                            ISlide slide = presentation.Slides[slideIndex];
                            // Use GetImage inside a using block as per compiler‑fix rule
                            using (IImage slideImage = slide.GetImage())
                            {
                                string outputPath = Path.Combine(presentationOutputFolder, $"slide_{slideIndex + 1}.png");
                                slideImage.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                            }
                        }

                        // Save the presentation (even if unchanged) before exiting
                        presentation.Save(presentationPath, SaveFormat.Pptx);
                    }
                }
                catch (PptxUnsupportedFormatException)
                {
                    // Format not supported – write a comment and continue
                    Console.WriteLine($"Unsupported format for file: {presentationPath}");
                }
                catch (Exception ex)
                {
                    // General exception handling (e.g., I/O errors)
                    Console.WriteLine($"Error processing file {presentationPath}: {ex.Message}");
                }
            }
        }
    }
}