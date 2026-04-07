using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlidesToJpeg
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Output directory for JPEG images
                    string outputDir = "ExportedJpeg";
                    if (!Directory.Exists(outputDir))
                    {
                        Directory.CreateDirectory(outputDir);
                    }

                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];
                        // Generate full‑scale image of the slide
                        IImage slideImage = slide.GetImage(1f, 1f);
                        // Build output file name
                        string outputFile = Path.Combine(outputDir, $"Slide_{slideIndex + 1}.jpg");
                        // Save as JPEG with quality (baseline DCT is used internally)
                        slideImage.Save(outputFile, Aspose.Slides.ImageFormat.Jpeg, 90);
                        // Dispose the image
                        slideImage.Dispose();
                    }

                    // Save the presentation (optional, as we only exported images)
                    string savedPresentationPath = Path.Combine(outputDir, "PresentationSaved.pptx");
                    presentation.Save(savedPresentationPath, SaveFormat.Pptx);
                }
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}