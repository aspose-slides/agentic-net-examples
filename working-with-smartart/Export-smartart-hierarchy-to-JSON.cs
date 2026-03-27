using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtExport
{
    class Program
    {
        class NodeInfo
        {
            public int Id { get; set; }
            public int? ParentId { get; set; }
            public string Text { get; set; }
        }

        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputJsonPath = "smartart_structure.json";
            string outputPresentationPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = new Presentation(inputPath);

            Aspose.Slides.SmartArt.SmartArt smartArt = null;
            foreach (IShape shape in presentation.Slides[0].Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.SmartArt)
                {
                    smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;
                    break;
                }
            }

            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt diagram found in the presentation.");
                presentation.Dispose();
                return;
            }

            List<NodeInfo> nodeList = new List<NodeInfo>();
            int nextId = 1;

            Action<Aspose.Slides.SmartArt.ISmartArtNode, int?> traverse = null;
            traverse = (node, parentId) =>
            {
                int currentId = nextId++;
                NodeInfo info = new NodeInfo
                {
                    Id = currentId,
                    ParentId = parentId,
                    Text = node.TextFrame.Text
                };
                nodeList.Add(info);

                foreach (Aspose.Slides.SmartArt.ISmartArtNode child in node.ChildNodes)
                {
                    traverse(child, currentId);
                }
            };

            foreach (Aspose.Slides.SmartArt.ISmartArtNode rootNode in smartArt.Nodes)
            {
                traverse(rootNode, null);
            }

            string json = JsonSerializer.Serialize(nodeList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(outputJsonPath, json);

            presentation.Save(outputPresentationPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}