// -----------------------------------------------------------------------------
// Example: Create smartart cycle with three nodes using C#
//
// Description:
// Demonstrates how to create a SmartArt cycle with three nodes using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Cycle, Three, Nodes, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of a SmartArt cycle with three nodes.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a SmartArt diagram with the BasicCycle layout (represents a cycle)
        ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicCycle);
        smartArt.Layout = SmartArtLayoutType.BasicCycle; // Ensure layout is set to Cycle

        // Add three root nodes to the SmartArt
        ISmartArtNode node1 = smartArt.Nodes.AddNode();
        ISmartArtNode node2 = smartArt.Nodes.AddNode();
        ISmartArtNode node3 = smartArt.Nodes.AddNode();

        // Set text for each node
        node1.TextFrame.Text = "Node 1";
        node2.TextFrame.Text = "Node 2";
        node3.TextFrame.Text = "Node 3";

        // Save the presentation
        try
        {
            pres.Save("SmartArtCycle.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during saving (e.g., unsupported format)
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
