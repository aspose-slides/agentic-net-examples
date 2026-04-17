using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.gif";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception)
        {
            // Handle unsupported format exception
            Console.WriteLine("Failed to load presentation. Format may not be supported.");
            return;
        }

        Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
        gifOptions.FrameSize = new System.Drawing.Size(960, 720);
        gifOptions.DefaultDelay = 2000;
        gifOptions.TransitionFps = 35;
        // Disposal method set to none for static frames (if supported)

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);

        // Save presentation before exit
        presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}