using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a SmartArt diagram of OrganizationChart layout
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

        // Add a new node to the SmartArt
        Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.AllNodes.AddNode();

        // Record the node's level before setting IsAssistant
        int levelBefore = node.Level;

        // Set the node as an assistant
        node.IsAssistant = true;

        // Record the node's level after setting IsAssistant
        int levelAfter = node.Level;

        // Output the level values to verify indentation depth change
        Console.WriteLine("Node level before setting IsAssistant: " + levelBefore);
        Console.WriteLine("Node level after setting IsAssistant: " + levelAfter);

        // Save the presentation
        string outputPath = "AssistantNodeExample.pptx";
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}