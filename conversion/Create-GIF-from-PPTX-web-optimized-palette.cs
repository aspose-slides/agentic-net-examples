using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
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
            Presentation pres = new Presentation(inputPath);
            GifOptions gifOptions = new GifOptions();
            gifOptions.FrameSize = new Size(960, 720); // optimized size for web
            gifOptions.DefaultDelay = 2000; // 2 seconds per slide
            gifOptions.TransitionFps = 35; // smoother transitions

            pres.Save(outputPath, SaveFormat.Gif, gifOptions);
            pres.Dispose();

            Console.WriteLine("GIF saved to " + outputPath);
        }
        catch (NotSupportedException)
        {
            // format not supported
            Console.WriteLine("The file format is not supported for GIF conversion.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}