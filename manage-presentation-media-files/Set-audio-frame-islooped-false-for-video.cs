using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (args.Length > 0)
        {
            inputPath = args[0];
        }
        if (args.Length > 1)
        {
            outputPath = args[1];
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                foreach (ISlide slide in pres.Slides)
                {
                    bool hasVideo = false;
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is IVideoFrame)
                        {
                            hasVideo = true;
                            break;
                        }
                    }

                    if (hasVideo)
                    {
                        foreach (IShape shape in slide.Shapes)
                        {
                            if (shape is IAudioFrame)
                            {
                                IAudioFrame audioFrame = (IAudioFrame)shape;
                                audioFrame.PlayLoopMode = false;
                            }
                        }
                    }
                }

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // format not supported
        }
        catch (Aspose.Slides.PptUnsupportedFormatException)
        {
            // format not supported
        }
    }
}