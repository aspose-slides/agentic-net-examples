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
        // Add a SmartArt diagram with StackedList layout
        Aspose.Slides.SmartArt.ISmartArt smart = slide.Shapes.AddSmartArt(50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.StackedList);
        // Access the first root node
        Aspose.Slides.SmartArt.ISmartArtNode node = smart.AllNodes[0];
        // Add a child node at position 2 (zero-based)
        Aspose.Slides.SmartArt.SmartArtNode childNode = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)node.ChildNodes).AddNodeByPosition(2);
        // Assign a unique tag using the text frame
        childNode.TextFrame.Text = "UniqueTag_001";
        // Log the identifier (position) of the added node
        Console.WriteLine("Added node at position: " + childNode.Position);
        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        // Dispose the presentation
        presentation.Dispose();
    }
}