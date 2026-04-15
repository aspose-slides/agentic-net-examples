using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a SmartArt diagram
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 60, Aspose.Slides.SmartArt.SmartArtLayoutType.ClosedChevronProcess);
        // Add a new node to the SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();
        node.TextFrame.Text = "New Node";
        // Apply solid fill using the theme's accent color to each shape in the node
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in node.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.SchemeColor = Aspose.Slides.SchemeColor.Accent1;
        }
        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Dispose the presentation
        presentation.Dispose();
    }
}