using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace PromoteSmartArtNode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);

            // Access the first slide
            ISlide slide = pres.Slides[0];

            // Find the first SmartArt shape in the slide
            SmartArt smartArt = null;
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is SmartArt)
                {
                    smartArt = (SmartArt)shape;
                    break;
                }
            }

            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt found in the first slide.");
                pres.Dispose();
                return;
            }

            // Ensure there is at least one root node
            if (smartArt.Nodes.Count == 0)
            {
                Console.WriteLine("SmartArt contains no root nodes.");
                pres.Dispose();
                return;
            }

            // Get the first root node (the node to be removed)
            ISmartArtNode parentNode = smartArt.Nodes[0];

            // Check if the parent node has at least one child
            if (parentNode.ChildNodes.Count > 0)
            {
                // Store the position of the parent node before removal
                int parentPosition = parentNode.Position;

                // Get the first child node that will be promoted
                ISmartArtNode childNode = parentNode.ChildNodes[0];
                string childText = childNode.TextFrame.Text;

                // Remove the parent node from the SmartArt
                parentNode.Remove();

                // Add a new node at the original position of the removed parent
                ISmartArtNode promotedNode = ((SmartArtNodeCollection)smartArt.Nodes).AddNodeByPosition(parentPosition);
                promotedNode.TextFrame.Text = childText;
            }
            else
            {
                Console.WriteLine("The selected node has no child nodes to promote.");
            }

            // Save the modified presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
    }
}