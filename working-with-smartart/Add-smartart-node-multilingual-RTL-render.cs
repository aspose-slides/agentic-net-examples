// -----------------------------------------------------------------------------
// Example: Add smartart node multilingual RTL render using C#
//
// Description:
// Demonstrates how to add a SmartArt node containing multilingual (English, Hebrew, Arabic) text
// and enable right-to-left (RTL) rendering using C# and Aspose.Slides for .NET. The example
// creates a new presentation, inserts a SmartArt diagram, adds a node with mixed-language
// text, configures RTL layout, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, Multilingual, RTL,
// Render, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of multilingual SmartArt nodes with proper RTL rendering.
// - Build C# utilities for PowerPoint presentation processing that support mixed-language content.
// - Generate or transform PPTX files in .NET applications with right-to-left language support.
// - Validate presentation workflows involving SmartArt and multilingual text before publishing.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a SmartArt diagram to the first slide
        Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
            10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);

        // Add a new node to the SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();

        // Set multilingual text (English, Hebrew, Arabic) on the node
        newNode.TextFrame.Text = "Hello שלום مرحبا";

        // Enable right-to-left layout for proper rendering of RTL languages
        smartArt.IsReversed = true;

        // Save the presentation
        presentation.Save("MultilingualSmartArt.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}
