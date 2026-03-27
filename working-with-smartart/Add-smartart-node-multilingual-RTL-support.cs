using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram of type BasicCycle
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

        // Add a new node to the SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();

        // Set multilingual text (including right‑to‑left language)
        node.TextFrame.Text = "Hello שלום مرحبا";

        // Save the presentation
        presentation.Save("SmartArtMultilingual.pptx", SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}