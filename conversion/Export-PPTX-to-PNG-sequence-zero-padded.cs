using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputDir = "output";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (Presentation presentation = new Presentation(inputPath))
            {
                int slideCount = presentation.Slides.Count;
                int padding = slideCount.ToString().Length;

                for (int i = 0; i < slideCount; i++)
                {
                    ISlide slide = presentation.Slides[i];
                    using (IImage image = slide.GetImage())
                    {
                        string fileName = Path.Combine(outputDir, $"slide_{(i + 1).ToString().PadLeft(padding, '0')}.png");
                        image.Save(fileName, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save presentation before exit (no modifications made)
                presentation.Save(inputPath, SaveFormat.Pptx);
            }
        }
        catch (PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The presentation format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}