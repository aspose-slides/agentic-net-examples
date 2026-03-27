using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace RemoveAssistantNodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            Presentation pres = new Presentation(inputPath);
            ISlide slide = pres.Slides[0];

            ISmartArt smartArt = null;
            for (int i = 0; i < slide.Shapes.Count; i++)
            {
                if (slide.Shapes[i] is ISmartArt)
                {
                    smartArt = (ISmartArt)slide.Shapes[i];
                    break;
                }
            }

            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt found on the first slide.");
                pres.Save(outputPath, SaveFormat.Pptx);
                return;
            }

            // Process each top‑level node
            List<ISmartArtNode> rootNodes = new List<ISmartArtNode>();
            foreach (ISmartArtNode node in smartArt.Nodes)
            {
                rootNodes.Add(node);
            }

            foreach (ISmartArtNode rootNode in rootNodes)
            {
                ProcessNode(rootNode, null);
            }

            pres.Save(outputPath, SaveFormat.Pptx);
        }

        // Recursively process nodes, reassigning children of assistant nodes
        private static void ProcessNode(ISmartArtNode node, ISmartArtNode parent)
        {
            // Copy child list because the collection may change during processing
            List<ISmartArtNode> children = new List<ISmartArtNode>();
            foreach (ISmartArtNode child in node.ChildNodes)
            {
                children.Add(child);
            }

            foreach (ISmartArtNode child in children)
            {
                ProcessNode(child, node);
            }

            if (node.IsAssistant && parent != null)
            {
                // Promote each child of the assistant node to the parent
                foreach (ISmartArtNode subNode in node.ChildNodes)
                {
                    CloneNode(subNode, parent);
                }

                // Remove the assistant node
                node.Remove();
            }
        }

        // Clone a node (including its subtree) under a new parent
        private static void CloneNode(ISmartArtNode source, ISmartArtNode targetParent)
        {
            ISmartArtNode newNode = targetParent.ChildNodes.AddNode();
            newNode.TextFrame.Text = source.TextFrame.Text;
            newNode.IsAssistant = source.IsAssistant;
            newNode.OrganizationChartLayout = source.OrganizationChartLayout;

            foreach (ISmartArtNode child in source.ChildNodes)
            {
                CloneNode(child, newNode);
            }
        }
    }
}