using System;
using System.Drawing;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx"))
            {
                // Configure GIF export options
                Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
                gifOptions.FrameSize = new Size(960, 720); // Resulting GIF size
                gifOptions.DefaultDelay = 2000; // Delay per slide in milliseconds
                gifOptions.TransitionFps = 35; // Transition frames per second

                // Save as animated GIF with custom settings
                pres.Save("output.gif", Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

                // Save the presentation before exiting (optional)
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}