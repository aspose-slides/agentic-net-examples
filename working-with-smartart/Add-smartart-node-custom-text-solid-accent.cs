// -----------------------------------------------------------------------------
// Example: Add smartart node custom text solid accent using C#
//
// Description:
// Demonstrates how to add a SmartArt node with custom text and apply a solid
// accent fill using the theme's Accent1 color in a PowerPoint presentation
// with Aspose.Slides for .NET. The example creates a new presentation, inserts a
// Closed Chevron Process SmartArt diagram, adds a node with custom text, sets a
// solid fill on each shape within the node, and saves the result as a PPTX file.
// This pattern can be used to automate SmartArt customization in .NET
// applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, Custom Text,
// Solid Fill, Accent Color, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding SmartArt nodes with custom text and accent styling.
// - Build C# tools for PowerPoint presentation processing and customization.
// - Generate or transform PPTX files with themed SmartArt elements in .NET.
// - Validate and preview SmartArt modifications before publishing.
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

        // Add a SmartArt diagram of Closed Chevron Process layout
        ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);

        // Add a new node to the SmartArt
        ISmartArtNode node = smartArt.AllNodes.AddNode();

        // Set custom text for the node
        node.TextFrame.Text = "Custom Node Text";

        // Apply solid fill using the theme's accent color to each shape in the node
        foreach (ISmartArtShape shape in node.Shapes)
        {
            shape.FillFormat.FillType = FillType.Solid;
            shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;
        }

        // Save the presentation
        presentation.Save("SmartArtNodeAccent.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}
