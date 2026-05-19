using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram to the slide
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

        // Access the first root node (parent node)
        Aspose.Slides.SmartArt.ISmartArtNode parentNode = smartArt.AllNodes[0];

        // Add three child nodes to ensure the third child exists
        Aspose.Slides.SmartArt.SmartArtNode childNode0 = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(0);
        Aspose.Slides.SmartArt.SmartArtNode childNode1 = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(1);
        Aspose.Slides.SmartArt.SmartArtNode childNode2 = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(2);

        // Retrieve the position of the third child node (zero‑based index)
        int thirdChildPosition = childNode2.Position;

        // Log the position (coordinates) to the console
        Console.WriteLine("Third child node position: " + thirdChildPosition);

        // Save the presentation
        try
        {
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}