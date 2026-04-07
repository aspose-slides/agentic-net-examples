using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input ODP file path (can be passed as first argument)
            string inputPath = args.Length > 0 ? args[0] : "input.odp";
            // Output directory for JPG files
            string outputDir = "output";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            try
            {
                // Load the ODP presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Remove hidden slides
                    for (int i = presentation.Slides.Count - 1; i >= 0; i--)
                    {
                        Aspose.Slides.ISlide slide = presentation.Slides[i];
                        if (slide.Hidden)
                        {
                            slide.Remove();
                        }
                    }

                    // Export remaining slides to high‑resolution JPEG files
                    int scaleX = 2; // 2× scaling on X axis
                    int scaleY = 2; // 2× scaling on Y axis

                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
                        {
                            string imageFileName = String.Format(Path.Combine(outputDir, "slide_{0}.jpg"), slide.SlideNumber);
                            image.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
                        }
                    }

                    // Save the modified presentation (optional)
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Odp);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}