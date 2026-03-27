using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Load the presentation
        Presentation pres = new Presentation(inputPath);
        try
        {
            // Access the first slide
            ISlide slide = pres.Slides[0];

            // List to collect node titles
            List<string> nodeTitles = new List<string>();

            // Iterate through shapes to find SmartArt objects
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is SmartArt)
                {
                    SmartArt smartArt = (SmartArt)shape;

                    // Traverse each root node depth‑first
                    foreach (ISmartArtNode rootNode in smartArt.Nodes)
                    {
                        TraverseNode(rootNode, nodeTitles);
                    }
                }
            }

            // Example usage of collected titles
            Console.WriteLine("Collected {0} node titles.", nodeTitles.Count);
        }
        finally
        {
            // Save the presentation before exiting
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
    }

    // Recursive depth‑first traversal of SmartArt nodes
    static void TraverseNode(ISmartArtNode node, List<string> titles)
    {
        if (node.TextFrame != null && node.TextFrame.Text != null)
        {
            titles.Add(node.TextFrame.Text);
        }

        foreach (ISmartArtNode child in node.ChildNodes)
        {
            TraverseNode(child, titles);
        }
    }
}