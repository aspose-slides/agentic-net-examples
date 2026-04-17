using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];
        // Add a SmartArt diagram
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);
        // Access a parent node (first node)
        Aspose.Slides.SmartArt.ISmartArtNode parentNode = smartArt.AllNodes[0];
        // Access the third child node (zero‑based index 2)
        int childIndex = 2;
        Aspose.Slides.SmartArt.SmartArtNode childNode = (Aspose.Slides.SmartArt.SmartArtNode)parentNode.ChildNodes[childIndex];
        // Retrieve the node's position
        int position = childNode.Position;
        // Retrieve coordinates of the first shape associated with the child node
        Aspose.Slides.IShape shape = childNode.Shapes[0];
        float x = shape.X;
        float y = shape.Y;
        // Log the information
        Console.WriteLine("Child node position: {0}", position);
        Console.WriteLine("Shape coordinates: X={0}, Y={1}", x, y);
        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}