// -----------------------------------------------------------------------------
// Example: Add smartart node long text wrap using C#
//
// Description:
// Demonstrates how to add a SmartArt node containing a long paragraph of text
// and enable text wrapping within the node using C# and Aspose.Slides for .NET.
// The example creates a new presentation, inserts a SmartArt diagram, adds a
// node with extensive text, activates wrapping, and saves the result as a PPTX
// file. This pattern helps developers automate PowerPoint content creation and
// ensure proper text layout in SmartArt elements.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, Long Text, Text Wrapping,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding SmartArt nodes with long wrapped text.
// - Build C# utilities for PowerPoint presentation generation and editing.
// - Generate or transform PPTX files that include complex SmartArt layouts.
// - Validate SmartArt text formatting before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);

            // Add a new node to the SmartArt
            Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();

            // Set a long paragraph as the node's text
            node.TextFrame.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                                 "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
                                 "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris " +
                                 "nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
                                 "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.";

            // Enable text wrapping within the node
            node.TextFrame.TextFrameFormat.WrapText = Aspose.Slides.NullableBool.True;

            // Save the presentation
            presentation.Save("SmartArtWithWrappedText.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}
