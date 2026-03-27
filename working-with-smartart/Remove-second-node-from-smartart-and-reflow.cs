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

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);
        foreach (Aspose.Slides.IShape shape in pres.Slides[0].Shapes)
        {
            if (shape is Aspose.Slides.SmartArt.SmartArt)
            {
                Aspose.Slides.SmartArt.SmartArt smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;
                if (smartArt.AllNodes.Count > 1)
                {
                    Aspose.Slides.SmartArt.ISmartArtNode secondNode = smartArt.AllNodes[1];
                    smartArt.AllNodes.RemoveNode(secondNode);
                }
                break;
            }
        }
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}