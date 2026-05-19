using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtHierarchyExport
{
    // Simple DTO for JSON serialization
    public class SmartArtNodeInfo
    {
        public int SlideIndex { get; set; }
        public string SmartArtName { get; set; }
        public int NodeId { get; set; }
        public int ParentId { get; set; }
        public string Text { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string jsonOutputPath = "smartart_hierarchy.json";
            string presentationSavePath = "output.pptx";

            // Check if input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                // Load presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    List<SmartArtNodeInfo> nodeInfos = new List<SmartArtNodeInfo>();

                    // Iterate through slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Identify SmartArt shapes
                            if (shape is SmartArt)
                            {
                                SmartArt smartArt = (SmartArt)shape;
                                string smartArtName = smartArt.Name;

                                // Process all nodes recursively
                                ProcessNodeCollection(smartArt.AllNodes, -1, slideIndex, smartArtName, nodeInfos);
                            }
                        }
                    }

                    // Serialize hierarchy to JSON
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };
                    string json = JsonSerializer.Serialize(nodeInfos, options);
                    File.WriteAllText(jsonOutputPath, json);
                    Console.WriteLine("SmartArt hierarchy exported to: " + jsonOutputPath);

                    // Save presentation (no modifications made, but required by rules)
                    pres.Save(presentationSavePath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Recursive method to traverse SmartArt nodes
        private static void ProcessNodeCollection(ISmartArtNodeCollection nodes, int parentId, int slideIndex, string smartArtName, List<SmartArtNodeInfo> nodeInfos)
        {
            foreach (ISmartArtNode node in nodes)
            {
                int nodeId = node.Position;
                string text = node.TextFrame?.Text;

                SmartArtNodeInfo info = new SmartArtNodeInfo
                {
                    SlideIndex = slideIndex,
                    SmartArtName = smartArtName,
                    NodeId = nodeId,
                    ParentId = parentId,
                    Text = text
                };
                nodeInfos.Add(info);

                // Recursively process child nodes
                ProcessNodeCollection(node.ChildNodes, nodeId, slideIndex, smartArtName, nodeInfos);
            }
        }
    }
}