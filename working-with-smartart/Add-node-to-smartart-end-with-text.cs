using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a SmartArt diagram to the slide
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);
        // Add a new node at the end of the SmartArt collection
        Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();
        // Assign custom text to the new node
        newNode.TextFrame.Text = "Custom Node Text";
        // Save the presentation
        presentation.Save("AddNode.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Clean up resources
        presentation.Dispose();
    }
}