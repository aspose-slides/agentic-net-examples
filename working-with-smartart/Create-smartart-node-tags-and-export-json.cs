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
        // Create a new presentation
        Presentation presentation = new Presentation();

        // Add a SmartArt diagram
        ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

        // Dictionary to hold node index to tag mapping
        Dictionary<int, string> nodeTagMap = new Dictionary<int, string>();

        // Assign unique tags to each node
        for (int i = 0; i < smartArt.AllNodes.Count; i++)
        {
            ISmartArtNode node = smartArt.AllNodes[i];
            if (node.Shapes.Count > 0)
            {
                ISmartArtShape shape = node.Shapes[0];
                string tag = "Tag_" + (i + 1);
                shape.Name = tag;
                nodeTagMap.Add(i, tag);
            }
        }

        // Save the presentation
        string outputPptx = "SmartArtWithTags.pptx";
        presentation.Save(outputPptx, SaveFormat.Pptx);

        // Export the mapping to a JSON file
        string jsonPath = "NodeTagMapping.json";
        string json = JsonSerializer.Serialize(nodeTagMap, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(jsonPath, json);

        // Dispose the presentation
        presentation.Dispose();
    }
}