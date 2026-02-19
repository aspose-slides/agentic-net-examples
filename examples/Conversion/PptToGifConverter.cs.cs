using System;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Path to the source PPT or PPTX file
        System.String inputPath = "input.pptx";
        // Path where the GIF will be saved
        System.String outputPath = "output.gif";

        // Load the presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Configure GIF export options
        Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
        gifOptions.FrameSize = new System.Drawing.Size(800, 600); // Width x Height
        gifOptions.DefaultDelay = 500; // Delay per frame in milliseconds
        gifOptions.TransitionFps = 25; // Frames per second for transitions

        // Save the presentation as an animated GIF
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

        // Release resources
        presentation.Dispose();
    }
}