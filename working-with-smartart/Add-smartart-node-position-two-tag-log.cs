using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }
        string outputPath = Path.Combine(outputDir, "SmartArtNodeExample.pptx");

        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.StackedList);

        Aspose.Slides.SmartArt.ISmartArtNode newNode = ((Aspose.Slides.SmartArt.SmartArtNodeCollection)smartArt.Nodes).AddNodeByPosition(2);
        newNode.TextFrame.Text = "UniqueTag_001";

        Console.WriteLine("Added SmartArt node at position: " + newNode.Position);
        Console.WriteLine("Node tag: " + newNode.TextFrame.Text);

        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}