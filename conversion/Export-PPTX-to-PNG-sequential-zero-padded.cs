using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                int slideCount = pres.Slides.Count;
                int padding = slideCount.ToString().Length;

                for (int i = 0; i < slideCount; i++)
                {
                    ISlide slide = pres.Slides[i];
                    using (IImage image = slide.GetImage())
                    {
                        string fileName = $"slide_{(i + 1).ToString().PadLeft(padding, '0')}.png";
                        image.Save(fileName, Aspose.Slides.ImageFormat.Png);
                    }
                }

                // Save the presentation (no modifications) before exiting
                pres.Save("output_saved.pptx", SaveFormat.Pptx);
            }
        }
        catch (PptxUnsupportedFormatException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}