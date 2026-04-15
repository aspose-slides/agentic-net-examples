using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = (args != null && args.Length > 0) ? args[0] : "input.pptx";
            // Output presentation path
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            Presentation pres = null;
            try
            {
                // Load the presentation
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Process each slide
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                ISlide slide = pres.Slides[slideIndex];

                // Find the first SmartArt shape on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];
                    if (shape is ISmartArt)
                    {
                        ISmartArt smartArt = (ISmartArt)shape;
                        // Process root nodes
                        for (int rootIndex = 0; rootIndex < smartArt.Nodes.Count; rootIndex++)
                        {
                            ISmartArtNode rootNode = smartArt.Nodes[rootIndex];
                            ProcessNode(rootNode);
                        }
                        // Only process the first SmartArt shape
                        break;
                    }
                }
            }

            try
            {
                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle saving errors
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }

        // Recursively removes assistant nodes and promotes their children
        private static void ProcessNode(ISmartArtNode node)
        {
            ISmartArtNodeCollection childNodes = node.ChildNodes;
            // Iterate backwards to safely remove nodes while iterating
            for (int i = childNodes.Count - 1; i >= 0; i--)
            {
                ISmartArtNode child = childNodes[i];
                if (child.IsAssistant)
                {
                    // Promote assistant's children to the current node
                    ISmartArtNodeCollection assistantChildren = child.ChildNodes;
                    // Copy assistant children to a temporary list to avoid modification during iteration
                    ISmartArtNode[] assistantChildrenArray = new ISmartArtNode[assistantChildren.Count];
                    for (int j = 0; j < assistantChildren.Count; j++)
                    {
                        assistantChildrenArray[j] = assistantChildren[j];
                    }

                    foreach (ISmartArtNode grandChild in assistantChildrenArray)
                    {
                        // Add a new node under the current node
                        ISmartArtNode newNode = node.ChildNodes.AddNode();
                        // Copy text from the original grand child
                        if (grandChild.TextFrame != null && newNode.TextFrame != null)
                        {
                            newNode.TextFrame.Text = grandChild.TextFrame.Text;
                        }
                        // Recursively process the newly added node (in case it has its own assistants)
                        ProcessNode(newNode);
                    }

                    // Remove the assistant node
                    child.Remove();
                }
                else
                {
                    // Recursively process non‑assistant child nodes
                    ProcessNode(child);
                }
            }
        }
    }
}