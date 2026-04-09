using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";
            // Output folder for PNG images
            string outputFolder = "SlideImages";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Create output directory if it does not exist
            if (!Directory.Exists(outputFolder))
            {
                Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // High‑resolution scaling factors (e.g., 2x)
                float scaleX = 2f;
                float scaleY = 2f;

                // Export each slide as PNG
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    using (Aspose.Slides.IImage image = slide.GetImage(scaleX, scaleY))
                    {
                        string imageFileName = Path.Combine(outputFolder,
                            string.Format("Slide_{0}.png", slide.SlideNumber));
                        image.Save(imageFileName, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save presentation (preserve any changes or embedded media references)
                string savedPresentationPath = "output_preservation.pptx";
                presentation.Save(savedPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}