using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "largePresentation.pptx";
            string outputDir = "Thumbnails";
            Directory.CreateDirectory(outputDir);

            // Load the presentation. Using 'using' ensures resources are released promptly.
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Process each slide individually to keep memory footprint low.
                for (int i = 0; i < presentation.Slides.Count; i++)
                {
                    ISlide slide = presentation.Slides[i];

                    // Generate a scaled-down thumbnail (50% size) to reduce memory usage.
                    using (IImage image = slide.GetImage(0.5f, 0.5f))
                    {
                        string imagePath = Path.Combine(outputDir, $"slide_{i + 1}.png");
                        image.Save(imagePath, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the (potentially modified) presentation before exiting.
                presentation.Save("processedPresentation.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}