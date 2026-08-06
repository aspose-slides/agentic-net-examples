// -----------------------------------------------------------------------------
// Example: Add smartart node solid accent verify using C#
//
// Description:
// Demonstrates how to add a SmartArt node with a solid fill using the theme's
// Accent1 color in a PowerPoint presentation using Aspose.Slides for .NET.
// The example creates a new presentation, inserts a SmartArt diagram, adds a
// node, applies a solid accent fill to the node's shapes, and saves the file.
// This pattern can be used to automate SmartArt modifications and verify visual
// styling in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, Solid, Accent,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding SmartArt nodes with specific accent styling.
// - Build C# tools for PowerPoint presentation processing and styling.
// - Generate or transform PPTX files with customized SmartArt in .NET apps.
// - Verify SmartArt visual properties before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.BasicCycle);

            // Add a new node to the SmartArt
            ISmartArtNode node = smartArt.AllNodes.AddNode();

            // Set text for the new node
            node.TextFrame.Text = "New Node";

            // Apply solid fill using the theme's Accent1 color to each shape in the node
            foreach (ISmartArtShape shape in node.Shapes)
            {
                shape.FillFormat.FillType = FillType.Solid;
                shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;
            }

            // Save the presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
