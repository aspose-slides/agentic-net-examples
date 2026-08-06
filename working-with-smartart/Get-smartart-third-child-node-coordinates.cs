// -----------------------------------------------------------------------------
// Example: Get smartart third child node position using C#
//
// Description:
// Demonstrates how to retrieve the position index of the third child node of a
// SmartArt diagram using C# and Aspose.Slides for .NET. The example creates a
// presentation, adds an OrganizationChart SmartArt, inserts three child nodes,
// obtains the zero‑based position of the third child node, outputs it to the
// console, and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Third, Child, Node, Position, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate retrieval of a SmartArt child node's position index.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate SmartArt structures before publishing or integration.
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
        Presentation presentation = new Presentation();

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram to the slide
        ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

        // Access the first root node (parent node)
        ISmartArtNode parentNode = smartArt.AllNodes[0];

        // Add three child nodes to ensure the third child exists
        SmartArtNode childNode0 = (SmartArtNode)parentNode.ChildNodes.AddNodeByPosition(0);
        SmartArtNode childNode1 = (SmartArtNode)parentNode.ChildNodes.AddNodeByPosition(1);
        SmartArtNode childNode2 = (SmartArtNode)parentNode.ChildNodes.AddNodeByPosition(2);

        // Retrieve the position of the third child node (zero‑based index)
        int thirdChildPosition = childNode2.Position;

        // Log the position (index) to the console
        Console.WriteLine("Third child node position: " + thirdChildPosition);

        // Save the presentation
        try
        {
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
