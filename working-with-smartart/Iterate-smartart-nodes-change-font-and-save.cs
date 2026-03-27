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
            // Define input and output file paths
            string dataDir = "Data";
            string inputPath = Path.Combine(dataDir, "input.pptx");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Presentation presentation = new Presentation(inputPath))
            {
                // Iterate through all slides
                foreach (ISlide slide in presentation.Slides)
                {
                    // Iterate through all shapes on the slide
                    foreach (IShape shape in slide.Shapes)
                    {
                        // Process only SmartArt shapes
                        if (shape is ISmartArt smartArt)
                        {
                            // Iterate over all SmartArt nodes
                            foreach (ISmartArtNode node in smartArt.AllNodes)
                            {
                                // Access the text frame of the node
                                ITextFrame textFrame = node.TextFrame;
                                if (textFrame == null) continue;

                                // Iterate through paragraphs and portions to set the font
                                foreach (IParagraph paragraph in textFrame.Paragraphs)
                                {
                                    foreach (IPortion portion in paragraph.Portions)
                                    {
                                        // Change the Latin font to Arial
                                        portion.PortionFormat.LatinFont = new FontData("Arial");
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the updated presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}