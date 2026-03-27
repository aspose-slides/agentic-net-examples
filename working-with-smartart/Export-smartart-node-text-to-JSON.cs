using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Text.Json;

namespace SmartArtExport
{
    class Program
    {
        // Class representing a node for JSON serialization
        private class NodeInfo
        {
            public int Position { get; set; }
            public string Text { get; set; }
            public List<NodeInfo> Children { get; set; }

            public NodeInfo()
            {
                Children = new List<NodeInfo>();
            }
        }

        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string jsonOutputPath = "smartart.json";
            string presentationOutputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

            // List to hold all SmartArt node hierarchies
            List<NodeInfo> smartArtData = new List<NodeInfo>();

            // Iterate through slides and shapes to find SmartArt objects
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape is Aspose.Slides.SmartArt.SmartArt)
                    {
                        Aspose.Slides.SmartArt.SmartArt smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;

                        // Process each root node
                        foreach (Aspose.Slides.SmartArt.ISmartArtNode rootNode in smartArt.Nodes)
                        {
                            NodeInfo nodeInfo = ProcessNode(rootNode);
                            smartArtData.Add(nodeInfo);
                        }
                    }
                }
            }

            // Serialize hierarchy to JSON
            string jsonString = JsonSerializer.Serialize(smartArtData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonOutputPath, jsonString);

            // Save presentation before exit
            pres.Save(presentationOutputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();

            Console.WriteLine("SmartArt text exported to JSON file: " + jsonOutputPath);
        }

        // Recursive method to convert SmartArt node to NodeInfo
        private static NodeInfo ProcessNode(Aspose.Slides.SmartArt.ISmartArtNode smartNode)
        {
            NodeInfo info = new NodeInfo();

            // Use Position as identifier
            info.Position = smartNode.Position;

            // Extract text if available
            if (smartNode.TextFrame != null && smartNode.TextFrame.Text != null)
            {
                info.Text = smartNode.TextFrame.Text;
            }
            else
            {
                info.Text = string.Empty;
            }

            // Process child nodes recursively
            foreach (Aspose.Slides.SmartArt.ISmartArtNode child in smartNode.ChildNodes)
            {
                NodeInfo childInfo = ProcessNode(child);
                info.Children.Add(childInfo);
            }

            return info;
        }
    }
}