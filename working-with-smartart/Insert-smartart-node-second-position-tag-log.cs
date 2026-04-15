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

        // Add a SmartArt diagram of StackedList layout
        Aspose.Slides.SmartArt.ISmartArt smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.StackedList);

        // Get an existing root node (index 0)
        Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];

        // Insert a new child node at position 2
        Aspose.Slides.SmartArt.SmartArtNode childNode = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);

        // Assign a unique tag via the text frame
        childNode.TextFrame.Text = "UniqueTag_001";

        // Log the node's position for tracking
        Console.WriteLine("Inserted node at position: " + childNode.Position);

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up
        presentation.Dispose();
    }
}