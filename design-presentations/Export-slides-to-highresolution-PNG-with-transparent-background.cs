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
        string outputDir = "output";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                // Set transparent background for each slide
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    pres.Slides[i].Background.Type = BackgroundType.OwnBackground;
                    pres.Slides[i].Background.FillFormat.FillType = FillType.Solid;
                    pres.Slides[i].Background.FillFormat.SolidFillColor.Color = Color.Transparent;
                }

                // Export each slide as high‑resolution PNG
                float scaleX = 3f;
                float scaleY = 3f;
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    IImage image = pres.Slides[i].GetImage(scaleX, scaleY);
                    string slidePath = Path.Combine(outputDir, $"slide_{i + 1}.png");
                    image.Save(slidePath, Aspose.Slides.ImageFormat.Png);
                }

                // Save presentation before exit
                pres.Save("temp_saved.pptx", SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URLs)
        }
    }
}