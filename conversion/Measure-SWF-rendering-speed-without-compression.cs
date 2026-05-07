using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputSwfPath = "output.swf";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Set SWF options with compression disabled
            Aspose.Slides.Export.SwfOptions swfOptions = new Aspose.Slides.Export.SwfOptions();
            swfOptions.Compressed = false;

            // Save as SWF
            presentation.Save(outputSwfPath, Aspose.Slides.Export.SaveFormat.Swf, swfOptions);

            // Create animations generator for speed comparison
            Aspose.Slides.Export.PresentationAnimationsGenerator animationsGenerator = new Aspose.Slides.Export.PresentationAnimationsGenerator(presentation);

            // Generate frames at 30 FPS
            using (Aspose.Slides.Export.PresentationPlayer player30 = new Aspose.Slides.Export.PresentationPlayer(animationsGenerator, 30))
            {
                player30.FrameTick += (sender, e) =>
                {
                    string frameDir = "Frames30";
                    Directory.CreateDirectory(frameDir);
                    string framePath = Path.Combine(frameDir, $"frame_{((Aspose.Slides.Export.PresentationPlayer)sender).FrameIndex}.png");
                    e.GetFrame().Save(framePath, Aspose.Slides.ImageFormat.Png);
                };
                animationsGenerator.Run(presentation.Slides);
            }

            // Generate frames at 60 FPS
            using (Aspose.Slides.Export.PresentationPlayer player60 = new Aspose.Slides.Export.PresentationPlayer(animationsGenerator, 60))
            {
                player60.FrameTick += (sender, e) =>
                {
                    string frameDir = "Frames60";
                    Directory.CreateDirectory(frameDir);
                    string framePath = Path.Combine(frameDir, $"frame_{((Aspose.Slides.Export.PresentationPlayer)sender).FrameIndex}.png");
                    e.GetFrame().Save(framePath, Aspose.Slides.ImageFormat.Png);
                };
                animationsGenerator.Run(presentation.Slides);
            }

            // Dispose presentation
            presentation.Dispose();
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file access)
            Console.WriteLine(ex.Message);
        }
    }
}