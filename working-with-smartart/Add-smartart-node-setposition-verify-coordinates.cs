using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace SmartArtNodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            ISmartArt smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

            // Add a new node at position 0 (valid position)
            ISmartArtNode newNode = smartArt.Nodes.AddNodeByPosition(0);

            // Set the node's position (zero‑based index among sibling nodes)
            newNode.Position = 0;

            // Verify that the position was set correctly
            if (newNode.Position == 0)
            {
                Console.WriteLine("Node position set correctly.");
            }
            else
            {
                Console.WriteLine("Node position verification failed.");
            }

            // Save the presentation
            string outputPath = "SmartArtNodeExample.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}