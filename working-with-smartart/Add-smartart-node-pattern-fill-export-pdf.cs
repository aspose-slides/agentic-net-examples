// -----------------------------------------------------------------------------
// Example: Add smartart node pattern fill export pdf using C#
//
// Description:
// Demonstrates how to add SmartArt nodes with pattern fills and export the
// presentation to PDF using C# and Aspose.Slides for .NET. The example shows
// creating a presentation, inserting a SmartArt diagram, applying different
// pattern fills to individual nodes, and saving the result as a PDF file.
// This pattern can be used to automate PowerPoint workflows that require
// custom SmartArt styling and PDF output.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, PDF, SmartArt, Node, Pattern,
// Fill, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding SmartArt nodes with pattern fills and exporting to PDF.
// - Build C# tools for PowerPoint presentation processing with custom styling.
// - Generate or transform PPTX files with SmartArt content in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Add first node and set its text
        Aspose.Slides.SmartArt.ISmartArtNode node1 = smartArt.AllNodes.AddNode();
        node1.TextFrame.Text = "Node 1";

        // Apply pattern fill to each shape in the first node
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node1.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
            shape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.DiagonalCross;
            shape.FillFormat.PatternFormat.ForeColor.Color = Color.Blue;
            shape.FillFormat.PatternFormat.BackColor.Color = Color.Yellow;
        }

        // Add second node and set its text
        Aspose.Slides.SmartArt.ISmartArtNode node2 = smartArt.AllNodes.AddNode();
        node2.TextFrame.Text = "Node 2";

        // Apply pattern fill to each shape in the second node
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node2.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Pattern;
            shape.FillFormat.PatternFormat.PatternStyle = Aspose.Slides.PatternStyle.Horizontal;
            shape.FillFormat.PatternFormat.ForeColor.Color = Color.Green;
            shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
        }

        // Save the presentation as PDF with exception handling
        try
        {
            presentation.Save("SmartArtPattern.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (Exception)
        {
            // Format not supported or other error
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}
