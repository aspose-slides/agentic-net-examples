using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace CloneSmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation pres = new Presentation(inputPath);
            try
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Locate the first SmartArt shape on the slide
                ISmartArt originalSmartArt = null;
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is ISmartArt)
                    {
                        originalSmartArt = (ISmartArt)shape;
                        break;
                    }
                }

                if (originalSmartArt == null)
                {
                    Console.WriteLine("No SmartArt shape found on the first slide.");
                }
                else
                {
                    // Clone the SmartArt shape using the shape collection's AddClone method
                    IShape clonedShape = slide.Shapes.AddClone(originalSmartArt);
                    ISmartArt clonedSmartArt = (ISmartArt)clonedShape;

                    // Change each node's organization chart layout to horizontal (Standart)
                    foreach (ISmartArtNode node in clonedSmartArt.AllNodes)
                    {
                        node.OrganizationChartLayout = OrganizationChartLayoutType.Standart;
                    }

                    // Compare node arrangement between original and cloned SmartArt
                    int nodeIndex = 0;
                    foreach (ISmartArtNode originalNode in originalSmartArt.AllNodes)
                    {
                        // Ensure the cloned SmartArt has the same number of nodes
                        if (nodeIndex >= clonedSmartArt.AllNodes.Count)
                        {
                            Console.WriteLine("Cloned SmartArt has fewer nodes than the original.");
                            break;
                        }

                        ISmartArtNode clonedNode = clonedSmartArt.AllNodes[nodeIndex];

                        // Compare the position of the first shape within each node
                        ISmartArtShape originalNodeShape = originalNode.Shapes[0];
                        ISmartArtShape clonedNodeShape = clonedNode.Shapes[0];

                        bool sameX = originalNodeShape.X == clonedNodeShape.X;
                        bool sameY = originalNodeShape.Y == clonedNodeShape.Y;

                        Console.WriteLine("Node " + nodeIndex + " - X same: " + sameX + ", Y same: " + sameY);

                        nodeIndex++;
                    }
                }

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            finally
            {
                // Ensure resources are released
                pres.Dispose();
            }
        }
    }
}