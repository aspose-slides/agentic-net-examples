using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            Presentation presentation = new Presentation(inputPath);
            int slideCount = presentation.Slides.Count;
            for (int i = 0; i < slideCount; i++)
            {
                IBackgroundEffectiveData bgEffective = presentation.Slides[i].Background.GetEffective();
                if (bgEffective.FillFormat.FillType != FillType.Solid)
                {
                    presentation.Slides[i].Background.Type = BackgroundType.OwnBackground;
                    presentation.Slides[i].Background.FillFormat.FillType = FillType.Solid;
                    int red = (i * 50) % 256;
                    int green = (i * 80) % 256;
                    int blue = (i * 110) % 256;
                    presentation.Slides[i].Background.FillFormat.SolidFillColor.Color = Color.FromArgb(red, green, blue);
                }
            }
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}