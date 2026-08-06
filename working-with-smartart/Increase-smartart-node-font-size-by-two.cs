// -----------------------------------------------------------------------------
// Example: Increase smartart node font size by two using C#
//
// Description:
// Demonstrates how to increase smartart node font size by two using C# and 
// Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Increase, Smartart, Node, Font, 
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate increase smartart node font size by two.
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
        Presentation presentation = new Presentation();

        // Add a SmartArt diagram to the first slide
        ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

        // Iterate over all SmartArt nodes and increase font size by 2 points
        foreach (ISmartArtNode node in smartArt.AllNodes)
        {
            if (node.TextFrame != null && node.TextFrame.Paragraphs.Count > 0)
            {
                foreach (IParagraph paragraph in node.TextFrame.Paragraphs)
                {
                    foreach (IPortion portion in paragraph.Portions)
                    {
                        portion.PortionFormat.FontHeight += 2;
                    }
                }
            }
        }

        // Save the presentation
        presentation.Save("SmartArtFontIncrease.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}
