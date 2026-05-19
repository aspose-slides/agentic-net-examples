using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Add a SmartArt diagram with the BasicCycle layout (represents a cycle)
        ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicCycle);
        smartArt.Layout = SmartArtLayoutType.BasicCycle; // Ensure layout is set to Cycle

        // Add three root nodes to the SmartArt
        ISmartArtNode node1 = smartArt.Nodes.AddNode();
        ISmartArtNode node2 = smartArt.Nodes.AddNode();
        ISmartArtNode node3 = smartArt.Nodes.AddNode();

        // Set text for each node
        node1.TextFrame.Text = "Node 1";
        node2.TextFrame.Text = "Node 2";
        node3.TextFrame.Text = "Node 3";

        // Save the presentation
        try
        {
            pres.Save("SmartArtCycle.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during saving (e.g., unsupported format)
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}