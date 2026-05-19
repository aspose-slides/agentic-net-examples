using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace OrganizationChartAssistantRemoval
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                var presentation = new Presentation(inputPath);
                var slide = presentation.Slides[0];

                // Add an organization chart SmartArt if none exists
                var smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, SmartArtLayoutType.OrganizationChart);

                // Process all nodes recursively
                var allNodes = GetAllNodes(smartArt);
                foreach (var node in allNodes)
                {
                    if (node.IsAssistant)
                    {
                        var parent = FindParentNode(smartArt, node);
                        if (parent != null)
                        {
                            // Reassign child nodes to the parent
                            var children = new System.Collections.Generic.List<ISmartArtNode>();
                            foreach (var child in node.ChildNodes)
                            {
                                children.Add(child);
                            }

                            foreach (var child in children)
                            {
                                var newNode = parent.ChildNodes.AddNode();
                                newNode.TextFrame.Text = child.TextFrame.Text;
                                // Transfer further properties if needed

                                // Remove original child node
                                child.Remove();
                            }
                        }

                        // Remove the assistant node itself
                        node.Remove();
                    }
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();
                Console.WriteLine("Assistant nodes removed and subordinates reassigned successfully.");
            }
            catch (Exception ex) when (ex is NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        // Recursively collect all nodes in the SmartArt
        private static System.Collections.Generic.List<ISmartArtNode> GetAllNodes(ISmartArt smartArt)
        {
            var nodes = new System.Collections.Generic.List<ISmartArtNode>();
            foreach (var topNode in smartArt.Nodes)
            {
                CollectNodeRecursive(topNode, nodes);
            }
            return nodes;
        }

        private static void CollectNodeRecursive(ISmartArtNode node, System.Collections.Generic.List<ISmartArtNode> list)
        {
            list.Add(node);
            foreach (var child in node.ChildNodes)
            {
                CollectNodeRecursive(child, list);
            }
        }

        // Find the parent node of a given node
        private static ISmartArtNode FindParentNode(ISmartArt smartArt, ISmartArtNode targetNode)
        {
            foreach (var topNode in smartArt.Nodes)
            {
                var parent = FindParentRecursive(topNode, targetNode);
                if (parent != null)
                    return parent;
            }
            return null;
        }

        private static ISmartArtNode FindParentRecursive(ISmartArtNode currentNode, ISmartArtNode targetNode)
        {
            foreach (var child in currentNode.ChildNodes)
            {
                if (child == targetNode)
                    return currentNode;
                var result = FindParentRecursive(child, targetNode);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}