using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a SmartArt diagram of type BasicCycle (Cycle layout) to the first slide
            ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(50, 50, 400, 400, SmartArtLayoutType.BasicCycle);

            // Ensure the layout is set to Cycle (BasicCycle)
            smartArt.Layout = SmartArtLayoutType.BasicCycle;

            // Add three root nodes to the SmartArt
            ISmartArtNode node1 = smartArt.Nodes.AddNode();
            ISmartArtNode node2 = smartArt.Nodes.AddNode();
            ISmartArtNode node3 = smartArt.Nodes.AddNode();

            // Set text for each node (optional, demonstrates node usage)
            node1.TextFrame.Text = "Node 1";
            node2.TextFrame.Text = "Node 2";
            node3.TextFrame.Text = "Node 3";

            // Save the presentation
            try
            {
                pres.Save("SmartArtCycle.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }
        }
    }
}