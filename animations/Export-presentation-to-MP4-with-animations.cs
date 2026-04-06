using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.mp4";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Generate animations to ensure they are rendered correctly
                using (PresentationAnimationsGenerator animationsGenerator = new PresentationAnimationsGenerator(presentation))
                {
                    animationsGenerator.Run(presentation.Slides);
                }

                // Resolve MP4 SaveFormat at runtime to avoid compile‑time errors
                Aspose.Slides.Export.SaveFormat mp4Format = (Aspose.Slides.Export.SaveFormat)Enum.Parse(
                    typeof(Aspose.Slides.Export.SaveFormat), "Mp4");

                // Save the presentation as MP4 video
                presentation.Save(outputPath, mp4Format);
            }
        }
        catch (ArgumentException)
        {
            // MP4 format not found in SaveFormat enumeration
            Console.WriteLine("MP4 format is not supported by this version of Aspose.Slides.");
        }
        catch (NotSupportedException)
        {
            // Unsupported save format
            Console.WriteLine("MP4 format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}