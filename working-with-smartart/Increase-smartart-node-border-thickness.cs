using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Process only SmartArt shapes
                        if (shape is SmartArt)
                        {
                            SmartArt smartArt = (SmartArt)shape;

                            // Iterate over all nodes in the SmartArt diagram
                            ISmartArtNodeCollection allNodes = smartArt.AllNodes;
                            foreach (ISmartArtNode node in allNodes)
                            {
                                // Iterate over all shapes associated with the node
                                foreach (ISmartArtShape nodeShape in node.Shapes)
                                {
                                    // Ensure the shape has a line format (border)
                                    if (nodeShape.LineFormat != null)
                                    {
                                        // Increase the border thickness by one point
                                        nodeShape.LineFormat.Width = nodeShape.LineFormat.Width + 1f;
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        // Handle unsupported file format exceptions
        catch (Aspose.Slides.PptxUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported file format: " + ex.Message);
        }
        catch (Aspose.Slides.PptUnsupportedFormatException ex)
        {
            // Format not supported
            Console.WriteLine("Unsupported file format: " + ex.Message);
        }
        // General exception handling
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}