using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SmartArtAlignmentDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output_center_aligned.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            Presentation presentation = new Presentation(inputPath);

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape is a SmartArt diagram
                    Aspose.Slides.SmartArt.ISmartArt smartArt = shape as Aspose.Slides.SmartArt.ISmartArt;
                    if (smartArt != null)
                    {
                        // Iterate through all nodes in the SmartArt
                        foreach (Aspose.Slides.SmartArt.ISmartArtNode node in smartArt.AllNodes)
                        {
                            // Get the text frame of the node
                            ITextFrame textFrame = node.TextFrame;
                            if (textFrame != null)
                            {
                                // Align each paragraph in the node to center
                                foreach (IParagraph paragraph in textFrame.Paragraphs)
                                {
                                    paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
                                }
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}