using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
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
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                if (pres.Masters.Count == 0)
                {
                    Console.WriteLine("No master slides found.");
                    return;
                }

                // Set gradient background on the first master slide
                pres.Masters[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                pres.Masters[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Gradient;
                pres.Masters[0].Background.FillFormat.GradientFormat.TileFlip = Aspose.Slides.TileFlip.FlipBoth;

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}