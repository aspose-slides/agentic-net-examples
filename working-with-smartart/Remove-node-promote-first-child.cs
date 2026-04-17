using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace RemoveSmartArtNode
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
                Presentation pres = new Presentation(inputPath);

                foreach (IShape shape in pres.Slides[0].Shapes)
                {
                    if (shape is SmartArt)
                    {
                        SmartArt smartArt = (SmartArt)shape;

                        if (smartArt.AllNodes.Count > 0)
                        {
                            ISmartArtNode nodeToRemove = smartArt.AllNodes[0];

                            if (nodeToRemove.ChildNodes.Count > 0)
                            {
                                ISmartArtNode firstChild = nodeToRemove.ChildNodes[0];
                                string childText = firstChild.TextFrame.Text;

                                // Remove the original node
                                smartArt.AllNodes.RemoveNode(nodeToRemove);

                                // Add a new node at the same position (0)
                                SmartArtNode newNode = (SmartArtNode)((SmartArtNodeCollection)smartArt.AllNodes).AddNodeByPosition(0);
                                newNode.TextFrame.Text = childText;

                                // Promote grandchildren (if any) to the new node
                                foreach (ISmartArtNode grandChild in firstChild.ChildNodes)
                                {
                                    SmartArtNode newGrand = (SmartArtNode)((SmartArtNodeCollection)newNode.ChildNodes).AddNode();
                                    newGrand.TextFrame.Text = grandChild.TextFrame.Text;
                                }
                            }
                        }

                        break; // Process only the first SmartArt shape
                    }
                }

                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}