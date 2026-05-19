using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

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
        string outputPath = Path.Combine(outputDir, "SmartArtNodes.pptx");

        // Create a new presentation
        Presentation presentation = new Presentation();
        ISlide slide = presentation.Slides[0];

        // Add a SmartArt shape to the slide
        Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

        // Add multiple nodes in a loop with sequential identifiers
        int nodesToAdd = 5;
        for (int i = 0; i < nodesToAdd; i++)
        {
            Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();
            newNode.TextFrame.Text = "Node " + (i + 1);
        }

        // Validate node count after insertion
        int expectedCount = nodesToAdd;
        int actualCount = smartArt.AllNodes.Count;
        if (actualCount != expectedCount)
        {
            Console.WriteLine("Node count validation failed. Expected: " + expectedCount + ", Actual: " + actualCount);
        }
        else
        {
            Console.WriteLine("Node count validation succeeded. Total nodes: " + actualCount);
        }

        // Save the presentation
        presentation.Save(outputPath, SaveFormat.Pptx);
        presentation.Dispose();
    }
}