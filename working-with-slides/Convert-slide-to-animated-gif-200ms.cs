using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

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
            gifOptions.FrameSize = new System.Drawing.Size(960, 720); // optional frame size
            gifOptions.DefaultDelay = 200; // 200 ms frame delay
            gifOptions.TransitionFps = 25; // default FPS

            // Save as animated GIF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

            // Clean up
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}