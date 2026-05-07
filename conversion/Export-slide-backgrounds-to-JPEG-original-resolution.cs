using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "output_images";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                foreach (ISlide slide in presentation.Slides)
                {
                    // Preserve original resolution by using scale factor 1.0
                    IImage image = slide.GetImage(1f, 1f);
                    string imagePath = Path.Combine(outputDir, $"Slide_{slide.SlideNumber}.jpg");
                    image.Save(imagePath, Aspose.Slides.ImageFormat.Jpeg);
                    image.Dispose();
                }

                // Save presentation before exit
                string savedPath = "saved_output.pptx";
                presentation.Save(savedPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}