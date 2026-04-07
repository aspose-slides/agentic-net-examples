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

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Save the presentation before exiting (as per requirement)
                presentation.Save(inputPath, SaveFormat.Pptx);

                // Define scaling factors for high‑resolution output
                float scaleX = 2f;
                float scaleY = 2f;

                // Export each slide to a PNG image
                for (int index = 0; index < presentation.Slides.Count; index++)
                {
                    ISlide slide = presentation.Slides[index];
                    IImage image = slide.GetImage(scaleX, scaleY);
                    string outputFile = string.Format("slide_{0}.png", slide.SlideNumber);
                    image.Save(outputFile, Aspose.Slides.ImageFormat.Png);
                    image.Dispose();
                }

                // Clean up
                presentation.Dispose();
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported for this operation.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}