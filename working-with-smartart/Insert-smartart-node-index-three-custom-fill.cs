using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide (use ISlide)
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram (ClosedChevronProcess layout)
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 800, 60, Aspose.Slides.SmartArt.SmartArtLayoutType.ClosedChevronProcess);

        // Insert a new node at position index 3 (zero‑based)
        Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNodeByPosition(3);
        newNode.TextFrame.Text = "Custom Node";

        // Apply a custom solid fill color to all shapes of the new node
        foreach (Aspose.Slides.SmartArt.ISmartArtShape shape in newNode.Shapes)
        {
            shape.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            shape.FillFormat.SolidFillColor.Color = System.Drawing.Color.Orange;
        }

        // Save the presentation
        presentation.Save("InsertSmartArtNodeCustomFill.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}