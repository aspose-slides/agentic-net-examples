// -----------------------------------------------------------------------------
// Example: Add smartart node position two tag log using C#
//
// Description:
// Demonstrates how to add a SmartArt node at position two, assign a unique
// tag to it, and log its position using C# and Aspose.Slides for .NET. The
// example shows the required presentation-processing steps for PowerPoint
// files and produces the requested output in a standalone console
// application. Developers can use this pattern to automate PPTX workflows,
// validate results, or integrate presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, Node, Position, Tag,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a SmartArt node at a specific position with a tag.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Log SmartArt node details for validation or debugging.
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

        // Add a SmartArt diagram with StackedList layout
        Aspose.Slides.SmartArt.ISmartArt smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.StackedList);

        // Access the first root node
        Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

        // Add a child node at position 2 (zero-based)
        Aspose.Slides.SmartArt.SmartArtNode childNode = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

        // Assign a unique tag using the text frame
        childNode.TextFrame.Text = "UniqueTag_001";

        // Log the identifier (position) of the added node
        Console.WriteLine("Added node at position: " + childNode.Position);

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}
