// -----------------------------------------------------------------------------
// Example: Assign unique identifiers to smartart nodes using C#
//
// Description:
// Demonstrates how to assign unique integer identifiers to SmartArt nodes in a
// PowerPoint presentation using C# and Aspose.Slides for .NET. The example
// creates a presentation, adds a SmartArt diagram, inserts root and child
// nodes, maps each node to a unique ID using a dictionary, outputs the mapping,
// and saves the resulting PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Assign, Unique, Identifiers,
// SmartArt, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate the assignment of unique identifiers to SmartArt nodes.
// - Build C# tools for PowerPoint presentation processing and analysis.
// - Generate or transform PPTX files with custom SmartArt metadata in .NET
//   applications.
// - Validate SmartArt structures before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (use ISlide)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
            0, 0, 400, 400,
            Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Dictionary to store node-to-unique-id mapping
        Dictionary<Aspose.Slides.SmartArt.ISmartArtNode, int> nodeIdMap =
            new Dictionary<Aspose.Slides.SmartArt.ISmartArtNode, int>();

        // Counter for generating unique identifiers
        int nextId = 1;

        // Add root node and assign an identifier
        Aspose.Slides.SmartArt.ISmartArtNode rootNode = smartArt.Nodes.AddNode();
        nodeIdMap.Add(rootNode, nextId++);

        // Add a child node to the root node and assign an identifier
        Aspose.Slides.SmartArt.ISmartArtNode childNode = rootNode.ChildNodes.AddNode();
        nodeIdMap.Add(childNode, nextId++);

        // Add another root node and assign an identifier
        Aspose.Slides.SmartArt.ISmartArtNode secondRoot = smartArt.Nodes.AddNode();
        nodeIdMap.Add(secondRoot, nextId++);

        // Example: iterate over the mapping and output the assigned IDs
        foreach (KeyValuePair<Aspose.Slides.SmartArt.ISmartArtNode, int> entry in nodeIdMap)
        {
            Console.WriteLine("Node Position: " + entry.Key.Position + " Assigned ID: " + entry.Value);
        }

        // Save the presentation before exiting
        presentation.Save("SmartArtWithIds_out.pptx", SaveFormat.Pptx);
    }
}
