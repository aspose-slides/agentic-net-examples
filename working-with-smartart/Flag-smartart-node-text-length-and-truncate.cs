using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.SmartArt;
using Aspose.Slides.Export;

namespace SmartArtTextTruncate
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the input presentation
            string inputPath = "input.pptx";
            // Path to the output presentation
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
                        // Get the current slide
                        Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            // Get the shape
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                            // Check if the shape is a SmartArt diagram
                            if (shape is Aspose.Slides.SmartArt.ISmartArt smartArt)
                            {
                                // Iterate through all nodes in the SmartArt diagram
                                Aspose.Slides.SmartArt.ISmartArtNodeCollection allNodes = smartArt.AllNodes;
                                foreach (Aspose.Slides.SmartArt.ISmartArtNode node in allNodes)
                                {
                                    // Get the text of the node
                                    string nodeText = node.TextFrame.Text;

                                    // If text exceeds 50 characters, truncate it
                                    if (!string.IsNullOrEmpty(nodeText) && nodeText.Length > 50)
                                    {
                                        string truncated = nodeText.Substring(0, 50);
                                        node.TextFrame.Text = truncated;
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., unsupported format)
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported
            }
        }
    }
}