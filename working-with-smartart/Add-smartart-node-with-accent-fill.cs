using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();
        // Get the first slide
        var slide = presentation.Slides[0];
        // Add a SmartArt diagram
        var smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 60, Aspose.Slides.SmartArt.SmartArtLayoutType.ClosedChevronProcess);
        // Add a new node with custom text
        var node = smartArt.AllNodes.AddNode();
        node.TextFrame.Text = "Custom Node Text";
        // Apply solid fill with theme accent color to each shape in the node
        foreach (var shape in node.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;
        }
        // Save the presentation
        presentation.Save("SmartArtNodeAccent.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}