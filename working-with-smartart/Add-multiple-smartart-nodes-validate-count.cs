using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtExample
{
    class Program
    {
        static void Main()
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a SmartArt shape to the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.BasicBlockList);

            // Number of nodes to add
            int nodesToAdd = 5;

            // Add nodes in a loop with sequential identifiers
            for (int i = 0; i < nodesToAdd; i++)
            {
                // Add a new node at the end of the collection
                Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();

                // Assign text to the node
                if (newNode.TextFrame != null)
                {
                    newNode.TextFrame.Text = "Node " + (i + 1);
                }
            }

            // Validate node count after insertion
            int expectedCount = nodesToAdd;
            int actualCount = smartArt.AllNodes.Count;
            if (actualCount == expectedCount)
            {
                Console.WriteLine("Node count validation passed: " + actualCount);
            }
            else
            {
                Console.WriteLine("Node count validation failed. Expected: " + expectedCount + ", Actual: " + actualCount);
            }

            // Save the presentation
            string outputPath = "SmartArtNodes.pptx";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}