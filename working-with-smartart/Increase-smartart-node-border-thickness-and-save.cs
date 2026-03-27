using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
        {
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.SmartArt.ISmartArt smartArt = null;

            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                smartArt = shape as Aspose.Slides.SmartArt.ISmartArt;
                if (smartArt != null)
                {
                    break;
                }
            }

            if (smartArt != null)
            {
                Aspose.Slides.SmartArt.ISmartArtNodeCollection allNodes = smartArt.AllNodes;
                foreach (Aspose.Slides.SmartArt.ISmartArtNode node in allNodes)
                {
                    Aspose.Slides.SmartArt.ISmartArtShapeCollection shapes = node.Shapes;
                    foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in shapes)
                    {
                        if (shape.LineFormat != null)
                        {
                            shape.LineFormat.Width = shape.LineFormat.Width + 1f;
                        }
                    }
                }
            }

            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}