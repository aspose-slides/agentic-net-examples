using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesRasterExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input PPTX file and output directory
            string inputPath = "SamplePresentation.pptx";
            string outputDir = "SlideImages";

            try
            {
                // Ensure output directory exists
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through each slide and export as a raster image (JPEG)
                    foreach (ISlide slide in pres.Slides)
                    {
                        // Get full‑scale image of the slide
                        using (IImage image = slide.GetImage(1f, 1f))
                        {
                            // Build output file name
                            string imagePath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}.jpg");
                            // Save the image in JPEG format
                            image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                        }
                    }

                    // Save the presentation (no changes made, but required by the task)
                    pres.Save(inputPath, SaveFormat.Pptx);
                }

                Console.WriteLine("All slides have been exported successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}