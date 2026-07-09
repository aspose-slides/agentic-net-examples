using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Define input presentation path
        string inputPath = "input.pptx";

        // Check if the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        // Define scaling factors
        int scaleX = 1;
        int scaleY = scaleX;

        // Load the presentation
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (NotSupportedException)
        {
            // format not supported
            Console.WriteLine("The file format is not supported.");
            return;
        }

        // Iterate through each slide and generate thumbnails
        foreach (Aspose.Slides.ISlide slide in presentation.Slides)
        {
            DateTime startTime = DateTime.Now;
            Console.WriteLine($"Thumbnail generation started for slide {slide.SlideNumber} at {startTime:O}");

            using (Aspose.Slides.IImage thumbnail = slide.GetImage(scaleX, scaleY))
            {
                string imageFileName = string.Format("Slide_{0}.jpg", slide.SlideNumber);
                thumbnail.Save(imageFileName, Aspose.Slides.ImageFormat.Jpeg);
            }

            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;
            Console.WriteLine($"Thumbnail generation completed for slide {slide.SlideNumber} at {endTime:O} (Duration: {duration.TotalMilliseconds} ms)");
        }

        // Save the presentation before exiting
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}