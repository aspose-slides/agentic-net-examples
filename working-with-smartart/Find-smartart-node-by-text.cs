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
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
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

                // List to hold node titles
                List<string> nodeTitles = new List<string>();

                // Access the first slide
                ISlide slide = pres.Slides[0];

                // Iterate through shapes to find SmartArt objects
                foreach (IShape shape in slide.Shapes)
                {
                    if (shape is ISmartArt)
                    {
                        ISmartArt smartArt = (ISmartArt)shape;

                        // Depth‑first traversal of all nodes
                        foreach (ISmartArtNode rootNode in smartArt.AllNodes)
                        {
                            TraverseNode(rootNode, nodeTitles);
                        }
                    }
                }

                // Example usage of collected titles (e.g., print them)
                Console.WriteLine("Collected SmartArt node titles:");
                foreach (string title in nodeTitles)
                {
                    Console.WriteLine("- " + title);
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // TODO: Add specific handling for unsupported file formats if needed
            }
            finally
            {
                // Ensure resources are released
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }

        // Recursive depth‑first traversal of SmartArt nodes
        private static void TraverseNode(ISmartArtNode node, List<string> titles)
        {
            if (node.TextFrame != null)
            {
                titles.Add(node.TextFrame.Text);
            }

            foreach (ISmartArtNode child in node.ChildNodes)
            {
                TraverseNode(child, titles);
            }
        }
    }
}