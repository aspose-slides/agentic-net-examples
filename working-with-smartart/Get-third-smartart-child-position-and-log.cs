using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtChildNodeExample
{
    class Program
    {
        static void Main()
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Find the first SmartArt shape on the slide
            Aspose.Slides.SmartArt.ISmartArt smartArt = null;
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is Aspose.Slides.SmartArt.ISmartArt)
                {
                    smartArt = (Aspose.Slides.SmartArt.ISmartArt)shape;
                    break;
                }
            }

            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt shape found on the slide.");
                presentation.Dispose();
                return;
            }

            // Assume the first node is the parent node
            Aspose.Slides.SmartArt.ISmartArtNode parentNode = smartArt.AllNodes[0];

            // Access the third child node (zero‑based index 2)
            int childIndex = 2;
            if (parentNode.ChildNodes.Count <= childIndex)
            {
                Console.WriteLine("The parent node does not have a third child node.");
                presentation.Dispose();
                return;
            }

            Aspose.Slides.SmartArt.SmartArtNode childNode = (Aspose.Slides.SmartArt.SmartArtNode)parentNode.ChildNodes[childIndex];

            // Retrieve the position of the child node
            int position = childNode.Position;

            // Log the position (coordinates) to the console
            Console.WriteLine("Third child node position: " + position);

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}