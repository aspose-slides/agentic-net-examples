using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        System.String inputPath = "animated.pptx";
        if (!System.IO.File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                System.String outputDir = "Frames";
                System.IO.Directory.CreateDirectory(outputDir);
                const System.Double fps = 33;

                using (Aspose.Slides.Export.PresentationAnimationsGenerator generator = new Aspose.Slides.Export.PresentationAnimationsGenerator(pres))
                using (Aspose.Slides.Export.PresentationPlayer player = new Aspose.Slides.Export.PresentationPlayer(generator, fps))
                {
                    player.FrameTick += (sender, args) =>
                    {
                        System.String filePath = System.IO.Path.Combine(outputDir, $"frame_{sender.FrameIndex}.png");
                        args.GetFrame().Save(filePath, Aspose.Slides.ImageFormat.Png);
                    };

                    generator.Run(pres.Slides);
                }

                // Save the presentation before exit
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., external URLs)
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}