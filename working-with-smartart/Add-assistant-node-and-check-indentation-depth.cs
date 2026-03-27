using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        var outputPath = "AssistantNodeDemo.pptx";
        var pres = new Aspose.Slides.Presentation();
        var slide = pres.Slides[0];
        var smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);
        var newNode = smartArt.AllNodes.AddNode();
        int levelBefore = newNode.Level;
        newNode.IsAssistant = true;
        int levelAfter = newNode.Level;
        Console.WriteLine("Level before setting IsAssistant: " + levelBefore);
        Console.WriteLine("Level after setting IsAssistant: " + levelAfter);
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}