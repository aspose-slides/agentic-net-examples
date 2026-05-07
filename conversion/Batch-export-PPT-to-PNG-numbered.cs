using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BatchExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output directories
            string inputDir = Path.Combine(Environment.CurrentDirectory, "InputPpts");
            string outputDir = Path.Combine(Environment.CurrentDirectory, "OutputImages");

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.WriteLine("Input directory does not exist: " + inputDir);
                return;
            }

            // Ensure output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Get all files in the input directory
            string[] pptFiles = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);
            foreach (string filePath in pptFiles)
            {
                // Process only supported PowerPoint formats
                string extension = Path.GetExtension(filePath).ToLowerInvariant();
                if (extension != ".ppt" && extension != ".pptx" && extension != ".odp" && extension != ".pptm")
                {
                    continue; // Skip unsupported formats
                }

                // Check file existence (important)
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    continue;
                }

                try
                {
                    // Load the presentation
                    Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(filePath);

                    // Prepare output file name format (slide number prefix)
                    string formatString = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(filePath) + "_slide_{0}.png");

                    // Export each slide to PNG (using provided rule structure)
                    for (int index = 0; index < pres.Slides.Count; index++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[index];
                        using (Aspose.Slides.IImage image = slide.GetImage())
                        {
                            string outputPath = string.Format(formatString, index + 1);
                            image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                        }
                    }

                    // Save presentation before exit (no modifications made)
                    try
                    {
                        pres.Save(filePath, Aspose.Slides.Export.SaveFormat.Pptx);
                    }
                    catch (NotSupportedException)
                    {
                        // Format not supported for saving as PPTX
                    }

                    pres.Dispose();
                }
                catch (Exception ex)
                {
                    // Handle any processing errors
                    Console.WriteLine("Error processing file " + filePath + ": " + ex.Message);
                }
            }
        }
    }
}