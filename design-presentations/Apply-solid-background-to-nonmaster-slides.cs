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
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception)
        {
            // format not supported
            Console.WriteLine("File format not supported.");
            return;
        }

        for (int i = 0; i < presentation.Slides.Count; i++)
        {
            Aspose.Slides.IBackgroundEffectiveData effective = presentation.Slides[i].Background.GetEffective();
            if (effective.FillFormat.FillType != Aspose.Slides.FillType.Solid)
            {
                // Apply solid background to slide that does not inherit from master
                presentation.Slides[i].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                presentation.Slides[i].Background.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                presentation.Slides[i].Background.FillFormat.SolidFillColor.Color = Color.LightGray;
            }
        }

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}