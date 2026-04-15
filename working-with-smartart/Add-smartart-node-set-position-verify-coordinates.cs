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

        // Add a SmartArt diagram of type StackedList
        Aspose.Slides.SmartArt.ISmartArt smart = slide.Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.StackedList);

        // Choose a parent node (first node) to add a child node to
        Aspose.Slides.SmartArt.ISmartArtNode parentNode = smart.AllNodes[0];

        // Define the desired position for the new child node (zero-based)
        int desiredPosition = 1;

        // Add a new child node at the specified position
        Aspose.Slides.SmartArt.SmartArtNode childNode = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)parentNode.ChildNodes).AddNodeByPosition(desiredPosition);

        // Set text for the new node
        childNode.TextFrame.Text = "Inserted Node";

        // Verify that the node's Position matches the expected value
        if (childNode.Position != desiredPosition)
        {
            Console.WriteLine("Position verification failed. Expected: " + desiredPosition + ", Actual: " + childNode.Position);
        }
        else
        {
            Console.WriteLine("Position verification succeeded. Position: " + childNode.Position);
        }

        // Save the presentation
        try
        {
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }

        // Dispose the presentation
        presentation.Dispose();
    }
}