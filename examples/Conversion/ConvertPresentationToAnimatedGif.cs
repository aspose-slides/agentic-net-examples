using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Load the source presentation
        Presentation pres = new Presentation("input.pptx");

        // Configure GIF export options
        GifOptions gifOptions = new GifOptions();
        gifOptions.FrameSize = new Size(960, 720);          // Set the size of the resulting GIF
        gifOptions.DefaultDelay = 2000;                    // Delay per slide in milliseconds
        gifOptions.TransitionFps = 35;                     // Frames per second for transitions

        // Save the presentation as an animated GIF with the custom options
        pres.Save("output.gif", SaveFormat.Gif, gifOptions);

        // Save the presentation before exiting (optional, ensures the file is saved)
        pres.Save("input_saved.pptx", SaveFormat.Pptx);
    }
}