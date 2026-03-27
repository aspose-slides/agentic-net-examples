using System;
using System.IO;
using System.Drawing;
using Aspose.Slides.Export;

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

        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

        foreach (Aspose.Slides.ISlide slide in pres.Slides)
        {
            foreach (Aspose.Slides.IShape shape in slide.Shapes)
            {
                Aspose.Slides.SmartArt.ISmartArt smartArt = shape as Aspose.Slides.SmartArt.ISmartArt;
                if (smartArt != null)
                {
                    foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                    {
                        foreach (Aspose.Slides.SmartArt.ISmartArtShape nodeShape in node.Shapes)
                        {
                            if (nodeShape.FillFormat != null && nodeShape.FillFormat.FillType == Aspose.Slides.FillType.Solid)
                            {
                                Color existing = nodeShape.FillFormat.SolidFillColor.Color;
                                int increasedAlpha = Math.Min(255, existing.A + 25);
                                Color updated = Color.FromArgb(increasedAlpha, existing.R, existing.G, existing.B);
                                nodeShape.FillFormat.SolidFillColor.Color = updated;
                            }
                        }
                    }
                }
            }
        }

        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}