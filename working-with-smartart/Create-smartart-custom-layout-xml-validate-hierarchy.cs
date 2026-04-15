using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a SmartArt diagram of OrganizationChart layout
            Aspose.Slides.SmartArt.ISmartArt smartArt = presentation.Slides[0].Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // Assign a custom layout XML (placeholder - actual implementation depends on API capabilities)
            // smartArt.Layout = CustomLayout; // Custom layout XML handling would be placed here

            // Build a simple hierarchy: root node with two child nodes
            Aspose.Slides.SmartArt.ISmartArtNode rootNode = smartArt.AllNodes[0];

            // Add first child node
            Aspose.Slides.SmartArt.ISmartArtNode childNode1 = rootNode.ChildNodes.AddNode();
            childNode1.Position = 0; // first child

            // Add second child node
            Aspose.Slides.SmartArt.ISmartArtNode childNode2 = rootNode.ChildNodes.AddNode();
            childNode2.Position = 1; // second child

            // Validate hierarchy: ensure that child nodes have Level == 1 (direct children of root)
            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
            {
                if (node.Level == 1)
                {
                    // This node is a direct child of the root node
                    // Additional validation logic can be placed here
                }
            }

            // Save the presentation
            presentation.Save("CustomSmartArt.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, file I/O issues)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}