using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace AsposeSlidesSmartArtDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path (can be passed as first argument)
            string inputPath = args.Length > 0 ? args[0] : "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("File not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation pres = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        ISlide slide = pres.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Check if the shape is a SmartArt diagram
                            if (shape is ISmartArt)
                            {
                                ISmartArt smartArt = (ISmartArt)shape;
                                ISmartArtNodeCollection allNodes = smartArt.AllNodes;

                                // Iterate through all nodes in the SmartArt
                                for (int nodeIndex = 0; nodeIndex < allNodes.Count; nodeIndex++)
                                {
                                    ISmartArtNode node = allNodes[nodeIndex];

                                    // Log hidden nodes
                                    if (node.IsHidden)
                                    {
                                        Console.WriteLine($"Slide {slideIndex + 1}, SmartArt hidden node at index {nodeIndex}");
                                    }
                                }
                            }
                        }
                    }

                    // Save the presentation (even if unchanged) before exiting
                    pres.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported: PPTX
                Console.WriteLine("The file format is not supported (PPTX).");
            }
            catch (PptUnsupportedFormatException)
            {
                // Format not supported: PPT
                Console.WriteLine("The file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}