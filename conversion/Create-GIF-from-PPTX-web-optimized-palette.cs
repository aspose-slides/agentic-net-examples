using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input PPTX file path
        string inputPath = "input.pptx";
        // Output GIF file path
        string outputPath = "output.gif";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation pres = new Presentation(inputPath))
            {
                // Configure GIF export options for web-optimized delivery
                GifOptions gifOptions = new GifOptions();
                gifOptions.DefaultDelay = 1000; // 1 second per slide
                gifOptions.TransitionFps = 30; // reasonable frame rate
                gifOptions.ExportHiddenSlides = false; // do not export hidden slides

                // Save the presentation as an animated GIF
                pres.Save(outputPath, SaveFormat.Gif, gifOptions);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The requested format is not supported for conversion.");
        }
        catch (Exception ex)
        {
            // General error handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}