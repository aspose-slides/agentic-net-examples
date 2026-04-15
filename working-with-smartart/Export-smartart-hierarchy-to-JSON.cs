using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides.Export;

namespace SmartArtExport
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string jsonOutputPath = "smartart_structure.json";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load presentation
                var presentation = new Aspose.Slides.Presentation(inputPath);

                // Find the first SmartArt shape
                Aspose.Slides.SmartArt.ISmartArt smartArt = null;
                foreach (var shape in presentation.Slides[0].Shapes)
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
                    presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    presentation.Dispose();
                    return;
                }

                // Helper class to hold node information
                var nodes = new List<NodeInfo>();
                int nextId = 1;

                // Recursive traversal to build hierarchy
                void Traverse(Aspose.Slides.SmartArt.ISmartArtNode node, int? parentId)
                {
                    int currentId = nextId++;
                    var nodeInfo = new NodeInfo
                    {
                        Id = currentId,
                        Text = node.TextFrame?.Text,
                        ParentId = parentId,
                        Children = new List<int>()
                    };
                    nodes.Add(nodeInfo);

                    // Process child nodes
                    foreach (var child in node.ChildNodes)
                    {
                        Traverse(child, currentId);
                        // After child is added, record its Id in parent's Children list
                        nodeInfo.Children.Add(nextId - 1);
                    }
                }

                // Start traversal from root nodes
                foreach (var rootNode in smartArt.AllNodes)
                {
                    Traverse(rootNode, null);
                }

                // Serialize hierarchy to JSON
                var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(nodes, jsonOptions);
                File.WriteAllText(jsonOutputPath, json);
                Console.WriteLine($"SmartArt hierarchy exported to {jsonOutputPath}");

                // Save presentation before exit
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine($"Error processing presentation: {ex.Message}");
                // Format not supported comment
                // The provided file format is not supported by Aspose.Slides.
            }
        }

        // Class representing a node in the exported JSON
        private class NodeInfo
        {
            public int Id { get; set; }
            public string Text { get; set; }
            public int? ParentId { get; set; }
            public List<int> Children { get; set; }
        }
    }
}