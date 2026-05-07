using System;
using System.IO;
using Aspose.Slides.Export;

namespace BatchConversionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation files
            string[] inputFiles = new string[]
            {
                "Presentation1.pptx",
                "Presentation2.pptx"
            };

            // Prepare output directory
            string outputDir = Path.Combine(Environment.CurrentDirectory, "ConvertedPresentations");
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Retry configuration
            int maxRetries = 3;

            foreach (string sourcePath in inputFiles)
            {
                // Check if the source file exists
                if (!File.Exists(sourcePath))
                {
                    Console.WriteLine($"File not found: {sourcePath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(sourcePath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + "_converted.pptx");

                int attempt = 0;
                bool success = false;

                while (attempt < maxRetries && !success)
                {
                    try
                    {
                        // Load options for large presentations
                        Aspose.Slides.LoadOptions loadOptions = new Aspose.Slides.LoadOptions();
                        loadOptions.BlobManagementOptions = new Aspose.Slides.BlobManagementOptions
                        {
                            PresentationLockingBehavior = Aspose.Slides.PresentationLockingBehavior.KeepLocked
                        };

                        // Open the presentation
                        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath, loadOptions))
                        {
                            // Example operation: rename the first slide
                            pres.Slides[0].Name = "RenamedSlide";

                            // Save the converted presentation
                            pres.Save(outputPath, SaveFormat.Pptx);
                        }

                        // Mark as successful
                        success = true;
                    }
                    catch (IOException ioEx)
                    {
                        // Transient I/O error, retry
                        attempt++;
                        Console.WriteLine($"I/O error processing '{sourcePath}' (attempt {attempt}): {ioEx.Message}");
                        if (attempt >= maxRetries)
                        {
                            Console.WriteLine($"Failed to process '{sourcePath}' after {maxRetries} attempts.");
                        }
                    }
                    catch (NotSupportedException nsEx)
                    {
                        // Format not supported
                        Console.WriteLine($"Format not supported for file '{sourcePath}': {nsEx.Message}");
                        break;
                    }
                    catch (Exception ex)
                    {
                        // Unexpected error
                        Console.WriteLine($"Unexpected error processing '{sourcePath}': {ex.Message}");
                        break;
                    }
                }
            }
        }
    }
}