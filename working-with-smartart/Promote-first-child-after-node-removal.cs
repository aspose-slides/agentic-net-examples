using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a SmartArt of OrganizationChart type to the first slide
            ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

            // Ensure there are at least two root nodes
            ISmartArtNode rootNode = smartArt.Nodes.AddNode(); // first root node
            rootNode.TextFrame.Text = "Root Node";

            ISmartArtNode nodeToRemove = smartArt.Nodes.AddNode(); // second root node (will be removed)
            nodeToRemove.TextFrame.Text = "Node To Remove";

            // Add a child to the node that will be removed
            ISmartArtNode childNode = nodeToRemove.ChildNodes.AddNode();
            childNode.TextFrame.Text = "Promoted Child";

            // Promote the first child of the node to be removed
            try
            {
                if (nodeToRemove.ChildNodes.Count > 0)
                {
                    // Capture the first child's text
                    string promotedText = nodeToRemove.ChildNodes[0].TextFrame.Text;

                    // Remove the node
                    bool removed = nodeToRemove.Remove();

                    if (removed)
                    {
                        // Add a new root node at the position of the removed node
                        ISmartArtNode newRoot = smartArt.Nodes.AddNodeByPosition(1); // position 1 (second root)
                        newRoot.TextFrame.Text = promotedText;
                    }
                }
                else
                {
                    // If there is no child, simply remove the node
                    nodeToRemove.Remove();
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors (e.g., index out of range)
                Console.WriteLine("Error during node promotion: " + ex.Message);
            }

            // Save the presentation
            string outputPath = System.IO.Path.Combine(Environment.CurrentDirectory, "PromotedSmartArt.pptx");
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}