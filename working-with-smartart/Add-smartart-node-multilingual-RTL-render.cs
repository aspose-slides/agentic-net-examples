using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a SmartArt diagram to the first slide
        Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle);

        // Add a new node to the SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();

        // Set multilingual text (English, Hebrew, Arabic) on the node
        newNode.TextFrame.Text = "Hello שלום مرحبا";

        // Enable right-to-left layout for proper rendering of RTL languages
        smartArt.IsReversed = true;

        // Save the presentation
        presentation.Save("MultilingualSmartArt.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}