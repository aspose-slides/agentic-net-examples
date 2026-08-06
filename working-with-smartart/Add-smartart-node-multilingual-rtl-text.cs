// -----------------------------------------------------------------------------
// Example: Add smartart node multilingual rtl text using C#
//
// Description:
// Demonstrates how to add a SmartArt node containing multilingual (Arabic and
// English) right‑to‑left (RTL) text using C# and Aspose.Slides for .NET. The
// example sets the default text language to Arabic, configures the SmartArt
// layout for RTL rendering, adds a node, assigns mixed‑language text, and saves
// the presentation. This pattern can be used to automate PPTX workflows that
// require multilingual RTL content.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, Multilingual,
// RTL, Text, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding SmartArt nodes with multilingual RTL text.
// - Build C# tools for PowerPoint presentation processing with RTL languages.
// - Generate or transform PPTX files containing mixed‑language content in .NET
//   applications.
// - Validate presentation workflows that involve right‑to‑left rendering.
// -----------------------------------------------------------------------------

using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Set default text language to Arabic for RTL rendering
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.DefaultTextLanguage = "ar-SA";

        // Create a new presentation with the load options
        Presentation presentation = new Presentation(loadOptions);

        // Add SmartArt diagram
        Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
            10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);

        // Set SmartArt to right-to-left
        smartArt.IsReversed = true;

        // Add a new node to SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();

        // Set multilingual text (Arabic and English)
        node.TextFrame.Text = "مرحبا World";

        // Save the presentation
        presentation.Save("SmartArtMultilingual.pptx", SaveFormat.Pptx);

        // Dispose presentation
        presentation.Dispose();
    }
}
