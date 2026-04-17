using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "presentation.pptx";
        string outputPath = "preview.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("The input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // Limit each slide's transition duration to 2 seconds (2000 ms)
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                slide.SlideShowTransition.Duration = 2000;
            }

            // Configure GIF export options with a 2‑second default delay per slide
            Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
            gifOptions.DefaultDelay = 2000; // 2000 ms = 2 seconds

            // Save the presentation as an animated GIF
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

            // Dispose the presentation before exiting
            pres.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified file format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}