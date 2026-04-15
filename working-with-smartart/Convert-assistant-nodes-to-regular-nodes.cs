using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AssistantNodeConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Check if the input file exists
            Presentation presentation;
            if (File.Exists(inputPath))
            {
                try
                {
                    // Load existing presentation
                    presentation = new Presentation(inputPath);
                }
                catch (Exception ex)
                {
                    // Handle unsupported format exception
                    // Format not supported
                    Console.WriteLine("Error loading presentation: " + ex.Message);
                    return;
                }
            }
            else
            {
                // Create a new presentation if input does not exist
                presentation = new Presentation();
                // Add an organization chart SmartArt to the first slide
                ISlide slide = presentation.Slides[0];
                // Coordinates and size for the SmartArt
                float x = 50f;
                float y = 50f;
                float width = 600f;
                float height = 400f;
                ISmartArt smartArt = slide.Shapes.AddSmartArt(x, y, width, height, SmartArtLayoutType.OrganizationChart);

                // Example: set the first node as an assistant
                if (smartArt.Nodes.Count > 0)
                {
                    ISmartArtNode firstNode = smartArt.Nodes[0];
                    firstNode.IsAssistant = true;
                }
            }

            // Iterate through all nodes and clear the IsAssistant flag
            ISmartArt smartArtObject = null;
            // Find the first SmartArt of type OrganizationChart in the presentation
            foreach (ISlide slide in presentation.Slides)
            {
                foreach (IShape shape in slide.Shapes)
                {
                    smartArtObject = shape as ISmartArt;
                    if (smartArtObject != null && smartArtObject.Layout == SmartArtLayoutType.OrganizationChart)
                    {
                        break;
                    }
                }
                if (smartArtObject != null)
                {
                    break;
                }
            }

            if (smartArtObject != null)
            {
                // Clear IsAssistant for all nodes
                for (int i = 0; i < smartArtObject.AllNodes.Count; i++)
                {
                    ISmartArtNode node = smartArtObject.AllNodes[i];
                    node.IsAssistant = false;
                }
            }
            else
            {
                Console.WriteLine("No organization chart SmartArt found in the presentation.");
            }

            // Save the presentation
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any saving errors
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}