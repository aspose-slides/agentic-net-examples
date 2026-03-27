using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

namespace SmartArtFontSizeIncrease
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
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load presentation
            Presentation presentation = new Presentation(inputPath);

            // Find the first SmartArt shape on the first slide
            ISmartArt smartArt = null;
            foreach (IShape shape in presentation.Slides[0].Shapes)
            {
                if (shape is ISmartArt)
                {
                    smartArt = (ISmartArt)shape;
                    break;
                }
            }

            if (smartArt == null)
            {
                Console.WriteLine("No SmartArt shape found in the presentation.");
                presentation.Dispose();
                return;
            }

            // Iterate over all SmartArt nodes and increase font size by 2 points
            foreach (ISmartArtNode node in smartArt.AllNodes)
            {
                ITextFrame textFrame = node.TextFrame;
                foreach (IParagraph paragraph in textFrame.Paragraphs)
                {
                    foreach (IPortion portion in paragraph.Portions)
                    {
                        portion.PortionFormat.FontHeight += 2;
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
    }
}