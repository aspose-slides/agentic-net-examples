using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "AnimationFrames";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }
        Directory.CreateDirectory(outputDir);
        const double fps = 33;
        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                using (Aspose.Slides.Export.PresentationAnimationsGenerator generator = new Aspose.Slides.Export.PresentationAnimationsGenerator(pres))
                {
                    using (Aspose.Slides.Export.PresentationPlayer player = new Aspose.Slides.Export.PresentationPlayer(generator, fps))
                    {
                        player.FrameTick += (sender, args) =>
                        {
                            string filePath = Path.Combine(outputDir, $"frame_{sender.FrameIndex}.png");
                            args.GetFrame().Save(filePath, Aspose.Slides.ImageFormat.Png);
                        };
                        generator.Run(pres.Slides);
                    }
                }
                // Save presentation before exit
                pres.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}