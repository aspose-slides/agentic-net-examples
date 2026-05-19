using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load presentation with exception handling for unsupported formats
            Presentation pres = null;
            try
            {
                pres = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Comment: format not supported
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            // Iterate through slides and shapes to find SmartArt organization charts
            for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
            {
                ISlide slide = pres.Slides[slideIndex];
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];
                    ISmartArt smartArt = shape as ISmartArt;
                    if (smartArt != null)
                    {
                        // Iterate all nodes to locate assistant nodes
                        ISmartArtNodeCollection allNodes = smartArt.AllNodes;
                        for (int nodeIndex = 0; nodeIndex < allNodes.Count; nodeIndex++)
                        {
                            ISmartArtNode node = allNodes[nodeIndex];
                            if (node.IsAssistant)
                            {
                                // Convert assistant node to regular node
                                node.IsAssistant = false;
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            try
            {
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}