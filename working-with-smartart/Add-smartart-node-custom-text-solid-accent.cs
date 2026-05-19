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

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram of Closed Chevron Process layout
        ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);

        // Add a new node to the SmartArt
        ISmartArtNode node = smartArt.AllNodes.AddNode();

        // Set custom text for the node
        node.TextFrame.Text = "Custom Node Text";

        // Apply solid fill using the theme's accent color to each shape in the node
        foreach (ISmartArtShape shape in node.Shapes)
        {
            shape.FillFormat.FillType = FillType.Solid;
            shape.FillFormat.SolidFillColor.SchemeColor = SchemeColor.Accent1;
        }

        // Save the presentation
        presentation.Save("SmartArtNodeAccent.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}