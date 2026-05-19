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