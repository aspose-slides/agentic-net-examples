using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
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
            Presentation pres = new Presentation(inputPath);
            ISlideCollection slides = pres.Slides;
            ISlide clonedSlide = slides.AddClone(slides[0]);

            clonedSlide.Background.Type = BackgroundType.OwnBackground;
            clonedSlide.Background.FillFormat.FillType = FillType.Solid;
            clonedSlide.Background.FillFormat.SolidFillColor.Color = Color.Yellow;

            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Format not supported.
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}