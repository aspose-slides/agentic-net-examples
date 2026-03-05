using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a Hierarchy SmartArt diagram
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.Hierarchy);

        // Access the root node
        Aspose.Slides.SmartArt.ISmartArtNode rootNode = smartArt.AllNodes[0];

        // Add a child node to the root node
        Aspose.Slides.SmartArt.ISmartArtNode childNode = rootNode.ChildNodes.AddNode();
        childNode.TextFrame.Text = "Child Node";

        // Add a sub‑child node to the child node
        Aspose.Slides.SmartArt.ISmartArtNode subChildNode = childNode.ChildNodes.AddNode();
        subChildNode.TextFrame.Text = "Sub Child";

        // Adjust positions of the shapes associated with the nodes
        Aspose.Slides.SmartArt.ISmartArtShape rootShape = rootNode.Shapes[0];
        rootShape.X += rootShape.Width * 0.5f;

        Aspose.Slides.SmartArt.ISmartArtShape childShape = childNode.Shapes[0];
        childShape.Y += childShape.Height * 0.5f;

        // Save the presentation
        presentation.Save("HierarchicalData_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}