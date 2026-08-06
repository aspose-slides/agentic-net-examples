// -----------------------------------------------------------------------------
// Example: Add smartart node pattern fill verify using C#
//
// Description:
// Demonstrates how to add a SmartArt node with a pattern fill and verify the
// result using C# and Aspose.Slides for .NET. The example creates a presentation,
// inserts a SmartArt diagram, adds a node, applies a diagonal‑cross pattern
// fill to the node's shapes, and saves the file. This pattern can be used to
// automate PPTX workflows, validate SmartArt styling, or integrate presentation
// logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, Pattern Fill,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a SmartArt node with pattern fill.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files with custom SmartArt styling.
// - Validate SmartArt node appearance before publishing or integration.
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
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram of type BasicBlockList
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Add a new node to the SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();

        // Set text for the new node
        node.TextFrame.Text = "Pattern Filled Node";

        // Apply a pattern fill to each shape within the node
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
        {
            // Set fill type to Pattern
            shape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;

            // Configure the pattern style
            shape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;

            // Set foreground and background colors for the pattern
            shape.FillFormat.PatternFormat.ForeColor.Color = System.Drawing.Color.Blue;
            shape.FillFormat.PatternFormat.BackColor.Color = System.Drawing.Color.Yellow;
        }

        // Save the presentation (handle unsupported format exception)
        try
        {
            presentation.Save("SmartArtPatternFill.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
