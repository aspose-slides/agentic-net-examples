using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var outputDir = "Output";
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            var pres = new Presentation();
            var slide = pres.Slides[0];
            var smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            var nodeMappings = new Dictionary<int, Aspose.Slides.SmartArt.ISmartArtNode>();

            var node1 = smartArt.AllNodes.AddNode();
            nodeMappings.Add(1, node1);
            var node2 = smartArt.AllNodes.AddNode();
            nodeMappings.Add(2, node2);
            var node3 = smartArt.AllNodes.AddNode();
            nodeMappings.Add(3, node3);

            node1.TextFrame.Text = "Node 1";
            node2.TextFrame.Text = "Node 2";
            node3.TextFrame.Text = "Node 3";

            var outputPath = Path.Combine(outputDir, "SmartArtDemo.pptx");
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, external resources)
        }
    }
}