using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtNodeIdentifier
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Add a SmartArt diagram to the first slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
                20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // Collection of all nodes in the SmartArt
            Aspose.Slides.SmartArt.ISmartArtNodeCollection allNodes = smartArt.AllNodes;

            // Dictionary to store node-to-identifier mappings
            Dictionary<Aspose.Slides.SmartArt.ISmartArtNode, string> nodeIdMap = new Dictionary<Aspose.Slides.SmartArt.ISmartArtNode, string>();

            // Add first new node
            Aspose.Slides.SmartArt.ISmartArtNode newNode1 = allNodes.AddNode();
            newNode1.TextFrame.Text = "Node 1";
            string id1 = Guid.NewGuid().ToString();
            nodeIdMap.Add(newNode1, id1);

            // Add second new node
            Aspose.Slides.SmartArt.ISmartArtNode newNode2 = allNodes.AddNode();
            newNode2.TextFrame.Text = "Node 2";
            string id2 = Guid.NewGuid().ToString();
            nodeIdMap.Add(newNode2, id2);

            // Add a child node to the first node
            Aspose.Slides.SmartArt.ISmartArtNodeCollection childNodes = newNode1.ChildNodes;
            Aspose.Slides.SmartArt.ISmartArtNode childNode = childNodes.AddNode();
            childNode.TextFrame.Text = "Child of Node 1";
            string childId = Guid.NewGuid().ToString();
            nodeIdMap.Add(childNode, childId);

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}