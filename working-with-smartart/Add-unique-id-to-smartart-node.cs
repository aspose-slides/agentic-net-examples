using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtNodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            var presentation = new Presentation();

            // Get the first slide
            var slide = presentation.Slides[0];

            // Add a SmartArt diagram to the slide
            var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);

            // Add a new node to the SmartArt
            var node = smartArt.Nodes.AddNode();

            // Generate a unique identifier for the node
            var nodeId = Guid.NewGuid();

            // Store the mapping between the node and its unique identifier
            var nodeIdMap = new Dictionary<ISmartArtNode, Guid>();
            nodeIdMap[node] = nodeId;

            // Save the presentation
            presentation.Save("SmartArtNodeExample.pptx", SaveFormat.Pptx);
        }
    }
}