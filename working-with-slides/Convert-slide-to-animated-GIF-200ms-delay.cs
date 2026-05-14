using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

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

        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
            Aspose.Slides.Export.GifOptions gifOptions = new Aspose.Slides.Export.GifOptions();
            gifOptions.FrameSize = new Size(960, 720);
            gifOptions.DefaultDelay = 200; // 200 ms frame delay
            gifOptions.TransitionFps = 25;
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Gif, gifOptions);
            presentation.Dispose();
        }
        catch (Exception ex) when (ex.Message.Contains("format"))
        {
            // Format not supported.
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}