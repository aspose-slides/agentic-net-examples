using System;
using System.IO;
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

        Presentation presentation = new Presentation(inputPath);
        ISlide slide = presentation.Slides[0];

        foreach (IShape shape in slide.Shapes)
        {
            if (shape is Aspose.Slides.SmartArt.ISmartArt)
            {
                Aspose.Slides.SmartArt.ISmartArt smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                try
                {
                    smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicProcess;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to set layout: " + ex.Message);
                }
            }
        }

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}