using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtTraversal
{
    class Program
    {
        static void Main()
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found.");
                return;
            }

            try
            {
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Assume we work with the first slide
                    ISlide slide = pres.Slides[0];

                    // Find the first SmartArt shape on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        if (shape is ISmartArt smartArt)
                        {
                            List<string> titles = new List<string>();
                            // Traverse all root nodes
                            ISmartArtNodeCollection rootNodes = smartArt.Nodes;
                            for (int i = 0; i < rootNodes.Count; i++)
                            {
                                DepthFirstTraverse(rootNodes[i], titles);
                            }

                            // Output collected titles
                            foreach (string title in titles)
                            {
                                Console.WriteLine(title);
                            }

                            // Only process the first SmartArt found
                            break;
                        }
                    }

                    // Save the presentation before exiting
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // If the format is not supported, Aspose.Slides may throw an exception
                // Comment: format not supported
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Depth‑first traversal of SmartArt nodes
        private static void DepthFirstTraverse(ISmartArtNode node, List<string> titles)
        {
            if (node.TextFrame != null && node.TextFrame.Text != null)
            {
                titles.Add(node.TextFrame.Text);
            }

            ISmartArtNodeCollection childNodes = node.ChildNodes;
            for (int i = 0; i < childNodes.Count; i++)
            {
                DepthFirstTraverse(childNodes[i], titles);
            }
        }
    }
}