using System;
using Aspose.Slides;
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
        var smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 200, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);

        // Add a new node to the SmartArt
        var node = smartArt.AllNodes.AddNode();
        node.TextFrame.Text = "New Node";

        // Apply solid fill with theme accent color to each shape in the node
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;
        }

        // Save the presentation
        string outputPath = "SmartArtNodeAccent.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}