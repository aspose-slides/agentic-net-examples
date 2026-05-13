using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Path to the input presentation
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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Scaling factor of three for high‑resolution thumbnails
            int scaleX = 3;
            int scaleY = scaleX;

            // Export each slide as a JPEG image with the specified scale
            foreach (Aspose.Slides.ISlide slide in presentation.Slides)
            {
                using (Aspose.Slides.IImage thumbnail = slide.GetImage(scaleX, scaleY))
                {
                    string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
                    thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
                }
            }

            // Save the presentation before exiting (no modifications made)
            presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}