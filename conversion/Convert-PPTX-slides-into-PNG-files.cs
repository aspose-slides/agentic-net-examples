using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ConvertPptxToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source presentation
                string inputPath = "presentation.pptx";
                // Output file name pattern
                string outputFormat = "slide_{0}.png";

                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int index = 0; index < pres.Slides.Count; index++)
                    {
                        ISlide slide = pres.Slides[index];
                        // Export each slide to PNG
                        using (IImage image = slide.GetImage())
                        {
                            string outputPath = String.Format(outputFormat, index);
                            image.Save(outputPath, ImageFormat.Png);
                        }
                    }

                    // Save the presentation before exiting (optional, can overwrite original)
                    pres.Save(inputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}