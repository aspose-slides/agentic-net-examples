using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtCycleExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a SmartArt diagram with a basic layout
            Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(
                50f,   // X position
                50f,   // Y position
                400f,  // Width
                400f,  // Height
                Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Change the layout to a Cycle layout
            smartArt.Layout = Aspose.Slides.SmartArt.SmartArtLayoutType.BasicCycle;

            // Add three interconnected nodes
            Aspose.Slides.SmartArt.ISmartArtNode node1 = smartArt.Nodes.AddNode();
            Aspose.Slides.SmartArt.ISmartArtNode node2 = smartArt.Nodes.AddNode();
            Aspose.Slides.SmartArt.ISmartArtNode node3 = smartArt.Nodes.AddNode();

            // Save the presentation
            presentation.Save("SmartArtCycle.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}