// -----------------------------------------------------------------------------
// Example: Create smartart diagram with XML validate using C#
//
// Description:
// Demonstrates how to create a SmartArt diagram (OrganizationChart layout) in a
// PowerPoint presentation using Aspose.Slides for .NET, traverse its hierarchy,
// and output node levels to the console. The example also notes the lack of
// direct API support for assigning a custom layout XML, serving as a reference
// for developers who need to validate SmartArt structures programmatically.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, OrganizationChart, XML,
// Validation, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate creation of SmartArt diagrams in PowerPoint files.
// - Validate SmartArt hierarchy levels in .NET applications.
// - Generate or transform PPTX files with custom SmartArt structures.
// - Provide console‑based diagnostics for SmartArt content before publishing.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string outputPath = "CustomSmartArt.pptx";

        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];

            // Create a SmartArt diagram with OrganizationChart layout
            var smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // NOTE: Assigning a custom layout XML is not directly supported via the API.
            // Placeholder for custom layout assignment if such functionality existed:
            // smartArt.Layout = <custom layout>;

            // Build hierarchy:
            // Root node (already exists as first node)
            var rootNode = smartArt.AllNodes[0];

            // Add two child nodes to the root
            var childNode1 = rootNode.ChildNodes.AddNode();
            var childNode2 = rootNode.ChildNodes.AddNode();

            // Add a sub‑child node to the first child
            var subChildNode = childNode1.ChildNodes.AddNode();

            // Validate hierarchy by printing each node's level
            foreach (var node in smartArt.AllNodes)
            {
                Console.WriteLine($"Node Level: {node.Level}");
            }

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., unsupported format, I/O errors)
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
