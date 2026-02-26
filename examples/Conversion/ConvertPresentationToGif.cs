using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        // Path to the source presentation
        string inputPath = "input.pptx";
        // Path where the animated GIF will be saved
        string outputPath = "output.gif";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Configure GIF export options
        Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
        gifOptions.FrameSize = new Size(960, 720);          // Size of the resulting GIF
        gifOptions.DefaultDelay = 2000;                    // Delay per slide in milliseconds
        gifOptions.TransitionFps = 35;                     // Frames per second for transitions

        // Save the presentation as an animated GIF
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

        // Release resources
        presentation.Dispose();
    }
}