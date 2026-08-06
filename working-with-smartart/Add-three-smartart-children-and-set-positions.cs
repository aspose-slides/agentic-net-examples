// -----------------------------------------------------------------------------
// Example: Add three smartart children and set positions using C#
//
// Description:
// Demonstrates how to add three SmartArt child nodes to an Organization Chart
// SmartArt diagram and set their positions using Aspose.Slides for .NET. The
// example creates a new presentation, inserts a SmartArt layout, adds child
// nodes at specific positions, assigns text, and saves the file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, OrganizationChart,
// AddChildNodes, SetPositions, Presentation Processing
//
// Use Cases:
// - Programmatically add multiple SmartArt child nodes with defined order.
// - Automate creation of hierarchical diagrams in PowerPoint files.
// - Build .NET tools for generating or modifying SmartArt structures.
// - Validate SmartArt layout modifications before deployment.
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
        // Add a SmartArt diagram (Organization Chart)
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);
        // Get a parent node (first root node)
        Aspose.Slides.SmartArt.ISmartArtNode parentNode = smartArt.AllNodes[0];
        // Add three child nodes at specific positions
        Aspose.Slides.SmartArt.ISmartArtNode childNode1 = ((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(0);
        childNode1.Position = 0;
        Aspose.Slides.SmartArt.ISmartArtNode childNode2 = ((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(1);
        childNode2.Position = 1;
        Aspose.Slides.SmartArt.ISmartArtNode childNode3 = ((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(2);
        childNode3.Position = 2;
        // Set text for each child node
        childNode1.TextFrame.Text = "Child 1";
        childNode2.TextFrame.Text = "Child 2";
        childNode3.TextFrame.Text = "Child 3";
        // Save the presentation
        try
        {
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported or other error handling
        }
        finally
        {
            presentation.Dispose();
        }
    }
}
