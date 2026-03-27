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
        int slideIndex = 0;
        int nodeIndexToRemove = 2; // zero-based index of the node to remove

        foreach (Aspose.Slides.IShape shape in pres.Slides[slideIndex].Shapes)
        {
            if (shape is Aspose.Slides.SmartArt.SmartArt)
            {
                Aspose.Slides.SmartArt.SmartArt smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;
                if (smartArt.AllNodes.Count > nodeIndexToRemove)
                {
                    Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes[nodeIndexToRemove];
                    smartArt.AllNodes.RemoveNode(node);
                }
                break;
            }
        }

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}