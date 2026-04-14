using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPresentationPath = "output.pptx";
        string outputThumbnailPath = "thumbnail.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("The input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Define the desired thumbnail dimensions (custom rectangle)
            float desiredWidth = 800f;   // pixels or points depending on scaling
            float desiredHeight = 600f;

            // Calculate scaling factors based on the slide size
            float scaleX = desiredWidth / pres.SlideSize.Size.Width;
            float scaleY = desiredHeight / pres.SlideSize.Size.Height;

            // Generate the thumbnail with custom scaling
            IImage thumbnail = slide.GetImage(scaleX, scaleY);

            // Save the thumbnail image
            thumbnail.Save(outputThumbnailPath, Aspose.Slides.ImageFormat.Png);

            // Save the presentation before exiting
            pres.Save(outputPresentationPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs or web services)
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}