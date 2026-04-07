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
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    string outputPath = $"slide_{i + 1}.bmp";
                    using (IImage bmp = pres.Slides[i].GetImage())
                    {
                        bmp.Save(outputPath, Aspose.Slides.ImageFormat.Bmp);
                    }
                }

                // Save the presentation before exiting
                pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}