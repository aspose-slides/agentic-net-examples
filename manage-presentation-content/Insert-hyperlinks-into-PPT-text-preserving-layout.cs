using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define input and output file paths
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Define the URL to be applied as a hyperlink
            string hyperlinkUrl = "https://www.example.com";

            // Iterate through each slide and apply hyperlink to the first portion of the first auto shape
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Find the first AutoShape that contains a TextFrame
                Aspose.Slides.IAutoShape autoShape = null;
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        break;
                    }
                }

                // If a suitable shape is found, set the hyperlink
                if (autoShape != null)
                {
                    // Ensure there is at least one paragraph and portion
                    if (autoShape.TextFrame.Paragraphs.Count > 0 && autoShape.TextFrame.Paragraphs[0].Portions.Count > 0)
                    {
                        Aspose.Slides.IPortion portion = autoShape.TextFrame.Paragraphs[0].Portions[0];
                        Aspose.Slides.IHyperlinkManager hyperlinkManager = portion.PortionFormat.HyperlinkManager;
                        hyperlinkManager.SetExternalHyperlinkClick(hyperlinkUrl);
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}