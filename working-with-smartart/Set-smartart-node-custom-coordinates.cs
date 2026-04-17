using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation presentation = null;
        try
        {
            presentation = new Presentation();
        }
        catch (Aspose.Slides.PptxUnsupportedFormatException)
        {
            // Format not supported
            return;
        }

        // Get the first slide
        ISlide slide = presentation.Slides[0];

        // Add a SmartArt diagram to the slide
        ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

        // Ensure there is at least one root node
        ISmartArtNode rootNode = smartArt.Nodes[0];

        // Add a child node if none exists, otherwise get the first child node
        ISmartArtNode childNode;
        if (rootNode.ChildNodes.Count == 0)
        {
            childNode = rootNode.ChildNodes.AddNode();
        }
        else
        {
            childNode = rootNode.ChildNodes[0];
        }

        // Each node has at least one shape; get the first shape of the child node
        ISmartArtShape childShape = childNode.Shapes[0];

        // Set custom X and Y coordinates for precise placement
        childShape.X = 150;
        childShape.Y = 200;

        // Save the presentation
        try
        {
            presentation.Save("SmartArtCustomCoordinates.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle any errors during saving
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
        finally
        {
            // Ensure the presentation is disposed before exiting
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}