using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesDemo
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

            Presentation presentation = null;
            try
            {
                // Load presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                return;
            }

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    bool hasText = false;

                    // Check if shape is an AutoShape with a TextFrame containing text
                    IAutoShape autoShape = shape as IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        if (autoShape.TextFrame.Paragraphs.Count > 0)
                        {
                            for (int paraIdx = 0; paraIdx < autoShape.TextFrame.Paragraphs.Count; paraIdx++)
                            {
                                IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIdx];
                                if (paragraph.Portions.Count > 0)
                                {
                                    for (int portionIdx = 0; portionIdx < paragraph.Portions.Count; portionIdx++)
                                    {
                                        IPortion portion = paragraph.Portions[portionIdx];
                                        if (!string.IsNullOrEmpty(portion.Text))
                                        {
                                            hasText = true;
                                            break;
                                        }
                                    }
                                }
                                if (hasText) break;
                            }
                        }
                    }

                    // If shape has no textual content, mark as decorative
                    if (!hasText)
                    {
                        shape.IsDecorative = true;
                    }
                }
            }

            try
            {
                // Save the modified presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle save errors (e.g., unsupported format)
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}