// -----------------------------------------------------------------------------
// Example: Promote first child after node removal using C#
//
// Description:
// Demonstrates how to promote the first child node of a SmartArt organization
// chart after removing its root node using C# and Aspose.Slides for .NET. The
// example creates a presentation, adds an organization chart SmartArt, builds
// a root node with two children, removes the root, and promotes the first
// child to become a new root node. The resulting presentation is saved as a
// PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, SmartArt, OrganizationChart,
// Promote, First Child, Node Removal, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate promotion of a child node after root removal in SmartArt diagrams.
// - Build C# utilities for manipulating SmartArt structures in PowerPoint files.
// - Generate or transform PPTX presentations with dynamic hierarchy changes.
// - Validate SmartArt hierarchy workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = Path.Combine(Environment.CurrentDirectory, "input.pptx");
            string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pptx");

            // Create a new presentation (or load if input exists)
            Presentation pres;
            if (File.Exists(inputPath))
            {
                try
                {
                    pres = new Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format
                    // Format not supported
                    Console.WriteLine("Failed to load presentation: " + ex.Message);
                    return;
                }
            }
            else
            {
                pres = new Presentation();
            }

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Add a SmartArt diagram (Organization Chart)
            ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

            // Add a root node
            ISmartArtNode rootNode = smartArt.Nodes.AddNode();
            rootNode.TextFrame.Text = "Root Node";

            // Add first child to the root node
            ISmartArtNode childNode1 = rootNode.ChildNodes.AddNode();
            childNode1.TextFrame.Text = "First Child";

            // Add second child to the root node
            ISmartArtNode childNode2 = rootNode.ChildNodes.AddNode();
            childNode2.TextFrame.Text = "Second Child";

            // Promote the first child after removing the root node
            // Store reference to the first child
            ISmartArtNode firstChild = null;
            if (rootNode.ChildNodes.Count > 0)
            {
                firstChild = rootNode.ChildNodes[0];
            }

            // Remove the root node
            bool removed = rootNode.Remove();

            // If removal succeeded and there was a child, promote it to root level
            if (removed && firstChild != null)
            {
                // Add a new root node and copy the text from the promoted child
                ISmartArtNode promotedNode = smartArt.Nodes.AddNode();
                promotedNode.TextFrame.Text = firstChild.TextFrame.Text;
            }

            // Save the presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any saving exceptions (e.g., unsupported format)
                // Format not supported
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }

            // Dispose the presentation
            pres.Dispose();
        }
    }
}
