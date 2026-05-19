using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtFontSizeIncrease
{
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
                Console.WriteLine("Input file does not exist.");
                return;
            }

            try
            {
                // Load the presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through all slides
                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        // Check if the shape is a SmartArt diagram
                        Aspose.Slides.SmartArt.ISmartArt smartArt = shape as Aspose.Slides.SmartArt.ISmartArt;
                        if (smartArt != null)
                        {
                            // Iterate through all nodes in the SmartArt
                            foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                            {
                                // Ensure the node has a TextFrame
                                if (node.TextFrame != null)
                                {
                                    // Iterate through all paragraphs and portions to adjust font size
                                    foreach (Aspose.Slides.IParagraph paragraph in node.TextFrame.Paragraphs)
                                    {
                                        foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                                        {
                                            float currentSize = portion.PortionFormat.FontHeight;
                                            portion.PortionFormat.FontHeight = currentSize + 2f; // Increase by 2 points
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the modified presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                // Format not supported.
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}