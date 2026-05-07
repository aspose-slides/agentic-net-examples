using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
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
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Set each slide background to transparent
                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];
                    slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                    slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                    slide.Background.FillFormat.SolidFillColor.Color = System.Drawing.Color.Transparent;
                }

                // Scale factor for 300 DPI (assuming 96 DPI base)
                float scale = 300f / 96f;

                for (int i = 0; i < pres.Slides.Count; i++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[i];
                    Aspose.Slides.IImage image = slide.GetImage(scale, scale);
                    string outputPath = Path.Combine(outputDir, $"slide_{i + 1}.png");
                    image.Save(outputPath, Aspose.Slides.ImageFormat.Png);
                    image.Dispose();
                }

                // Save the modified presentation
                string savedPath = Path.Combine(outputDir, "modified.pptx");
                pres.Save(savedPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}