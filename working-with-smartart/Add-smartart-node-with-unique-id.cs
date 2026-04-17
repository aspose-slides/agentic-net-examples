using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file path
            string outputPath = "output.pptx";

            // Create a dictionary to store identifier to node mapping
            Dictionary<string, Aspose.Slides.SmartArt.ISmartArtNode> nodeDictionary = new Dictionary<string, Aspose.Slides.SmartArt.ISmartArtNode>();

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram of type OrganizationChart
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(20, 20, 600, 500, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

                // Add a new root node to the SmartArt
                Aspose.Slides.SmartArt.ISmartArtNode newNode = smartArt.AllNodes.AddNode();

                // Generate a unique identifier for the node
                string uniqueId = Guid.NewGuid().ToString();

                // Assign the identifier as the node's text
                if (newNode.TextFrame != null)
                {
                    newNode.TextFrame.Text = uniqueId;
                }

                // Store the mapping in the dictionary
                nodeDictionary.Add(uniqueId, newNode);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., unsupported format)
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}