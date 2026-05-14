using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];

            bool hasMedia = false;
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is IVideoFrame || shape is IAudioFrame || shape is OleObjectFrame)
                {
                    hasMedia = true;
                    break;
                }
            }

            if (!hasMedia)
            {
                pres.Slides.Remove(slide);
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            else
            {
                Console.WriteLine("Slide contains embedded media; not removed.");
            }

            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}