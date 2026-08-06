// -----------------------------------------------------------------------------
// Example: Add smartart node to end with text using C#
//
// Description:
// Demonstrates how to add a SmartArt node to the end of a SmartArt diagram and
// assign custom text using C# and Aspose.Slides for .NET. The example creates a
// new presentation, inserts a SmartArt diagram, adds a node at the end of the
// node collection, sets its text, and saves the result as a PPTX file. This
// pattern can be used to automate PowerPoint content creation and manipulation
// in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, Text,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a SmartArt node to the end with custom text.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArt.SmartArtLayoutType.BasicCycle);

            // Add a new node at the end of the SmartArt collection
            SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();

            // Assign custom text to the new node
            newNode.TextFrame.Text = "Custom Node Text";

            // Save the presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format)
            // Format not supported
        }
    }
}
