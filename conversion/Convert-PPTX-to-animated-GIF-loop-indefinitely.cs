using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        System.String inputPath = "input.pptx";
        System.String outputPath = "output.gif";

        // Verify that the input file exists
        if (!System.IO.File.Exists(inputPath))
        {
            System.Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Configure GIF export options
            Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
            gifOptions.FrameSize = new System.Drawing.Size(960, 720); // Desired GIF size
            gifOptions.DefaultDelay = 1000; // Delay per frame in milliseconds
            gifOptions.TransitionFps = 25; // Frames per second for transitions
            // By default, the generated GIF loops indefinitely

            // Save the presentation as an animated GIF
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}