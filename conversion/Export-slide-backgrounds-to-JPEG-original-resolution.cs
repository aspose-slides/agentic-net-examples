using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ExportSlideBackgrounds
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input presentation path and output directory
            string inputPath = "input.pptx";
            string outputDir = "output";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Use full scale to preserve original resolution
                    float scaleX = 1f;
                    float scaleY = 1f;

                    // Iterate through each slide and export its image
                    foreach (ISlide slide in presentation.Slides)
                    {
                        using (IImage image = slide.GetImage(scaleX, scaleY))
                        {
                            string imagePath = Path.Combine(outputDir, string.Format("Slide_{0}.jpg", slide.SlideNumber));
                            image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                        }
                    }

                    // Save the presentation before exiting (no modifications made)
                    presentation.Save("output_pres.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}