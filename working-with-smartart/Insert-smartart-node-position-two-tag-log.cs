using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtNodeExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputFile = "output.pptx";

            try
            {
                // Ensure output directory exists
                string outputDir = Path.GetDirectoryName(Path.GetFullPath(outputFile));
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a SmartArt diagram (Stacked List layout)
                Aspose.Slides.SmartArt.ISmartArt smartArt = slide.Shapes.AddSmartArt(50, 50, 400, 300, Aspose.Slides.SmartArt.SmartArtLayoutType.StackedList);

                // Get a root node (first node) to add a child node to
                Aspose.Slides.SmartArt.ISmartArtNode rootNode = smartArt.AllNodes[0];

                // Insert a new child node at position 2 (zero‑based)
                Aspose.Slides.SmartArt.SmartArtNode childNode = (Aspose.Slides.SmartArt.SmartArtNode)((Aspose.Slides.SmartArt.SmartArtNodeCollection)rootNode.ChildNodes).AddNodeByPosition(2);

                // Assign a unique tag to the new node
                string uniqueTag = Guid.NewGuid().ToString();
                childNode.TextFrame.Text = uniqueTag;

                // Log the identifier (using the node's position as an example)
                Console.WriteLine("Added SmartArt node with tag: " + uniqueTag + " at position: " + childNode.Position);

                // Save the presentation
                presentation.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Position is out of range
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}