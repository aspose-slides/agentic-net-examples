using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        string outputPptx = "SmartArtPresentation.pptx";
        string outputPng = "SmartArtNodeThumbnail.png";

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a SmartArt diagram of Organization Chart layout
        ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

        // Access a specific child node (second node in this example)
        ISmartArtNode node = smartArt.AllNodes[1];

        // Get the first shape associated with the node
        ISmartArtShape shape = node.Shapes[0];

        // Generate a thumbnail image of the shape
        IImage shapeImage = shape.GetImage();

        // Save the thumbnail as PNG
        try
        {
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Save the presentation
        try
        {
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception)
        {
            // Format not supported
        }

        // Dispose the presentation
        pres.Dispose();

        // TODO: Embed the generated PNG (outputPng) into a report document as needed.
    }
}