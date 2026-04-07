using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Define input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.gif";

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

            // Configure GIF export options
            Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
            gifOptions.FrameSize = new Size(960, 720); // Set desired frame size
            gifOptions.DefaultDelay = 50; // Set frame delay to 50 milliseconds
            gifOptions.TransitionFps = 25; // Optional: set transition FPS

            // Save the presentation as an animated GIF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

            // Dispose the presentation object
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}