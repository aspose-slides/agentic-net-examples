using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input presentation path
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

            // Desired thumbnail dimensions
            int desiredWidth = 150;
            int desiredHeight = 150;

            // Calculate scaling factors based on slide size
            float scaleX = (1f / presentation.SlideSize.Size.Width) * desiredWidth;
            float scaleY = (1f / presentation.SlideSize.Size.Height) * desiredHeight;

            // Export each slide as a PNG thumbnail
            foreach (ISlide slide in presentation.Slides)
            {
                using (IImage thumbnail = slide.GetImage(scaleX, scaleY))
                {
                    string outputPath = string.Format("Slide_{0}.png", slide.SlideNumber);
                    thumbnail.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                }
            }

            // Save the presentation before exiting
            string outputPresentationPath = "output.pptx";
            presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            presentation.Dispose();
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