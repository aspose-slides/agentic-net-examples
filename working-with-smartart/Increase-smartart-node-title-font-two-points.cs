using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtFontIncrease
{
    class Program
    {
        static void Main(string[] args)
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
                    foreach (ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (IShape shape in slide.Shapes)
                        {
                            // Check if the shape is a SmartArt diagram
                            if (shape is ISmartArt)
                            {
                                ISmartArt smartArt = (ISmartArt)shape;

                                // Iterate through all SmartArt nodes (including child nodes)
                                foreach (ISmartArtNode node in smartArt.AllNodes)
                                {
                                    // Access the text frame of the node
                                    ITextFrame textFrame = node.TextFrame;
                                    if (textFrame == null) continue;

                                    // Iterate through all paragraphs in the text frame
                                    foreach (IParagraph paragraph in textFrame.Paragraphs)
                                    {
                                        // Iterate through all portions (runs) in the paragraph
                                        foreach (IPortion portion in paragraph.Portions)
                                        {
                                            // Increase the font height by 2 points
                                            float currentHeight = portion.PortionFormat.FontHeight;
                                            portion.PortionFormat.FontHeight = currentHeight + 2f;
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
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Comment: format not supported or other issue
            }
        }
    }
}