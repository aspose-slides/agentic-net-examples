using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ModifyHyperlinks
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

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Process only AutoShape objects that contain text
                    if (shape is Aspose.Slides.IAutoShape)
                    {
                        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                        if (textFrame != null)
                        {
                            // Iterate through paragraphs
                            for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                            {
                                Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[paraIndex];

                                // Iterate through portions
                                for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                                {
                                    Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];

                                    // Check if the portion already has a hyperlink
                                    if (portion.PortionFormat.HyperlinkClick != null)
                                    {
                                        // Update the hyperlink URL, tooltip, and font size
                                        string newUrl = "https://newexample.com";
                                        portion.PortionFormat.HyperlinkClick = new Aspose.Slides.Hyperlink(newUrl);
                                        portion.PortionFormat.HyperlinkClick.Tooltip = "Updated link";
                                        portion.PortionFormat.FontHeight = 14;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}