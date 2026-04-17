using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "smartart.json";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
            {
                List<NodeInfo> allSmartArtData = new List<NodeInfo>();

                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        if (shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
                        {
                            foreach (Aspose.Slides.SmartArt.ISmartArtNode rootNode in smartArt.Nodes)
                            {
                                NodeInfo nodeInfo = ProcessNode(rootNode);
                                allSmartArtData.Add(nodeInfo);
                            }
                        }
                    }
                }

                string json = JsonSerializer.Serialize(allSmartArtData, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(outputPath, json);
                Console.WriteLine("SmartArt data exported to " + outputPath);

                // Save presentation before exit
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException ex)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private static NodeInfo ProcessNode(Aspose.Slides.SmartArt.ISmartArtNode node)
    {
        NodeInfo info = new NodeInfo();
        // Use Position as identifier
        info.Id = node.Position;

        // Get text from the first shape of the node, if any
        if (node.Shapes.Count > 0)
        {
            Aspose.Slides.SmartArt.ISmartArtShape shape = node.Shapes[0];
            if (shape.TextFrame != null)
            {
                info.Text = shape.TextFrame.Text;
            }
        }

        // Recursively process child nodes
        foreach (Aspose.Slides.SmartArt.ISmartArtNode child in node.ChildNodes)
        {
            info.Children.Add(ProcessNode(child));
        }

        return info;
    }

    private class NodeInfo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public List<NodeInfo> Children { get; set; }

        public NodeInfo()
        {
            Children = new List<NodeInfo>();
            Text = string.Empty;
        }
    }
}