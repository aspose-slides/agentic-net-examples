// -----------------------------------------------------------------------------
// Example: Remove smartart node promote first child using C#
//
// Description:
// Demonstrates how to remove a SmartArt node and promote its first child node
// using C# and Aspose.Slides for .NET. The example loads a PPTX file, finds the
// first SmartArt shape, extracts the text of its first child, removes the
// original node, and inserts a new node at the same position containing the
// child's text. The modified presentation is saved as a new PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, SmartArt, Node, Promote,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate removal of a SmartArt node while preserving its first child.
// - Build C# tools for PowerPoint presentation manipulation.
// - Generate or transform PPTX files in .NET applications.
// - Validate SmartArt structures before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace RemoveAndPromoteSmartArtNode
{
    class Program
    {
        static void Main()
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
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath);

                foreach (Aspose.Slides.IShape shape in pres.Slides[0].Shapes)
                {
                    if (shape is Aspose.Slides.SmartArt.SmartArt)
                    {
                        Aspose.Slides.SmartArt.SmartArt smartArt = (Aspose.Slides.SmartArt.SmartArt)shape;

                        if (smartArt.Nodes.Count > 0)
                        {
                            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.Nodes[0];

                            if (node.ChildNodes.Count > 0)
                            {
                                Aspose.Slides.SmartArt.ISmartArtNode child = node.ChildNodes[0];
                                string childText = child.TextFrame.Text;
                                int nodePosition = node.Position;

                                // Remove the original node (its children are also removed)
                                node.Remove();

                                // Add a new node at the original position with the child's text
                                Aspose.Slides.SmartArt.SmartArtNode newNode = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)smartArt.Nodes).AddNodeByPosition(nodePosition);
                                newNode.TextFrame.Text = childText;
                            }
                        }

                        break;
                    }
                }

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported or other errors can be handled here.
            }
        }
    }
}
