using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtGeometryExport
{
    class Program
    {
        // DTO for shape geometry
        public class ShapeInfo
        {
            public float X { get; set; }
            public float Y { get; set; }
            public float Width { get; set; }
            public float Height { get; set; }
        }

        // DTO for node geometry
        public class NodeInfo
        {
            public int NodeIndex { get; set; }
            public List<ShapeInfo> Shapes { get; set; }
        }

        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string jsonOutputPath = "nodes_geometry.json";
            string presentationOutputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // List to hold geometry data for all nodes
            List<NodeInfo> allNodeInfos = new List<NodeInfo>();

            // Iterate through slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate through shapes on the slide
                foreach (IShape shape in slide.Shapes)
                {
                    // Identify SmartArt shapes
                    if (shape is ISmartArt)
                    {
                        ISmartArt smartArt = (ISmartArt)shape;
                        ISmartArtNodeCollection nodes = smartArt.AllNodes;
                        int nodeIdx = 0;

                        // Iterate through all nodes in the SmartArt
                        foreach (ISmartArtNode node in nodes)
                        {
                            NodeInfo nodeInfo = new NodeInfo();
                            nodeInfo.NodeIndex = nodeIdx;
                            nodeInfo.Shapes = new List<ShapeInfo>();

                            // Iterate through shapes associated with the node
                            foreach (ISmartArtShape smartShape in node.Shapes)
                            {
                                ShapeInfo shapeInfo = new ShapeInfo();
                                shapeInfo.X = smartShape.X;
                                shapeInfo.Y = smartShape.Y;
                                shapeInfo.Width = smartShape.Width;
                                shapeInfo.Height = smartShape.Height;
                                nodeInfo.Shapes.Add(shapeInfo);
                            }

                            allNodeInfos.Add(nodeInfo);
                            nodeIdx++;
                        }
                    }
                }
            }

            // Serialize geometry information to JSON
            string json = JsonSerializer.Serialize(allNodeInfos, new JsonSerializerOptions { WriteIndented = true });

            try
            {
                File.WriteAllText(jsonOutputPath, json);
                Console.WriteLine("Geometry JSON saved to: " + jsonOutputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to write JSON file: " + ex.Message);
            }

            // Save the presentation (even if unchanged) before exiting
            try
            {
                presentation.Save(presentationOutputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + presentationOutputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Clean up
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}