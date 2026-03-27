using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        var outputPath = "SmartArtMapping.json";
        var pres = new Aspose.Slides.Presentation();
        var slide = pres.Slides[0];
        var smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);
        var mapping = new Dictionary<int, string>();
        for (int i = 0; i < smartArt.AllNodes.Count; i++)
        {
            var node = smartArt.AllNodes[i];
            var shape = node.Shapes[0];
            var tag = "Tag" + i;
            shape.AlternativeText = tag;
            mapping[i] = tag;
        }
        pres.Save("SmartArtPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        var json = JsonSerializer.Serialize(mapping, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(outputPath, json);
        pres.Dispose();
    }
}