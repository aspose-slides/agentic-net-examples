using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace MathParagraphReport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input presentation path
            string inputPath = "input.pptx";

            // Verify file existence
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist.");
                return;
            }

            // Load presentation with exception handling for unsupported formats
            Presentation presentation;
            try
            {
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // If the format is not supported, write a comment and exit
                Console.WriteLine("Failed to load presentation. Format may not be supported.");
                // ex.Message can be logged if needed
                return;
            }

            // Iterate through slides and count MathParagraphs
            int totalSlides = presentation.Slides.Count;
            for (int slideIndex = 0; slideIndex < totalSlides; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];
                int mathParagraphCount = 0;

                foreach (IShape shape in slide.Shapes)
                {
                    IAutoShape autoShape = shape as IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        foreach (IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                        {
                            foreach (IPortion portion in paragraph.Portions)
                            {
                                IMathPortion mathPortion = portion as IMathPortion;
                                if (mathPortion != null)
                                {
                                    // Each MathPortion represents a MathParagraph
                                    mathParagraphCount++;
                                }
                            }
                        }
                    }
                }

                Console.WriteLine($"Slide {slideIndex + 1}: {mathParagraphCount} MathParagraph(s) detected.");
            }

            // Save the presentation before exiting
            string outputPath = "output.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
    }
}