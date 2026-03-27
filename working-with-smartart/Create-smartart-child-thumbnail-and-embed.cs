using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Ensure output directory exists
        string outputDir = "Output";
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        // Create a new presentation
        Presentation pres = new Presentation();

        // Add a SmartArt diagram (Organization Chart)
        ISmartArt smartArt = pres.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

        // Select a specific child node (e.g., third node)
        ISmartArtNode node = smartArt.AllNodes[2];

        // Get the first shape of the selected node
        ISmartArtShape shape = node.Shapes[0];

        // Generate a thumbnail image of the shape
        IImage shapeImage = shape.GetImage();

        // Save the thumbnail as PNG
        string pngPath = Path.Combine(outputDir, "SmartArtNodeThumbnail.png");
        shapeImage.Save(pngPath, Aspose.Slides.ImageFormat.Png);

        // Save the presentation
        string pptxPath = Path.Combine(outputDir, "Presentation.pptx");
        pres.Save(pptxPath, SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}