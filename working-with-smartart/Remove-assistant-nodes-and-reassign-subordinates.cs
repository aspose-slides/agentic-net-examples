using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace OrganizationChartAssistantRemoval
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add an organization chart SmartArt
            Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 600, 400, Aspose.Slides.SmartArt.SmartArtLayoutType.OrganizationChart);

            // Example: set layout for a node (optional)
            if (smartArt.Nodes.Count > 0)
            {
                smartArt.Nodes[0].OrganizationChartLayout = Aspose.Slides.SmartArt.OrganizationChartLayoutType.LeftHanging;
            }

            // Iterate through nodes in reverse order to safely remove assistants
            for (int i = smartArt.Nodes.Count - 1; i >= 0; i--)
            {
                Aspose.Slides.SmartArt.ISmartArtNode node = smartArt.Nodes[i];

                if (node.IsAssistant)
                {
                    // Reassign subordinates (child nodes) to the nearest manager.
                    // Aspose.Slides does not provide a direct method to change a node's parent,
                    // so this step would require custom logic such as cloning child nodes
                    // under the manager node. For demonstration, we simply remove the assistant node.
                    // Note: In a real scenario, you would copy each child node to the manager's ChildNodes collection.

                    // Remove the assistant node
                    node.Remove();
                }
            }

            // Save the presentation
            try
            {
                presentation.Save("OrganizationChart_NoAssistants.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other save errors
                // Format not supported
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}