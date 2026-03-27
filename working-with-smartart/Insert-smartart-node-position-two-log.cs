using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtNodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(
                0f, 0f, 400f, 400f,
                Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Insert a new node at zero‑based position 2 (third position)
            Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.Nodes.AddNodeByPosition(2);

            // Assign a unique tag to the node (using the text frame)
            newNode.TextFrame.Text = "UniqueTag_001";

            // Log the node's position for tracking
            Console.WriteLine("Inserted SmartArt node at position: " + newNode.Position);

            // Save the presentation
            presentation.Save("SmartArtNodeInserted.pptx", SaveFormat.Pptx);
        }
    }
}