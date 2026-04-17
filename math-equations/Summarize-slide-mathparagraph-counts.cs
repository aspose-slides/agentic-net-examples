using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;

namespace MathParagraphSummary
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

            Presentation presentation = null;
            try
            {
                // Load the presentation
                presentation = new Presentation(inputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other loading errors
                Console.WriteLine("Failed to load presentation: " + ex.Message);
                // Format not supported comment
                // The file format may not be supported by Aspose.Slides.
                return;
            }

            // Iterate through each slide and count MathParagraphs
            int slideCount = presentation.Slides.Count;
            for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
            {
                ISlide slide = presentation.Slides[slideIndex];
                int mathParagraphCount = 0;

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    IShape shape = slide.Shapes[shapeIndex];

                    // Process only AutoShape objects (including Math shapes)
                    IAutoShape autoShape = shape as IAutoShape;
                    if (autoShape == null || autoShape.TextFrame == null)
                        continue;

                    // Iterate through paragraphs
                    for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                    {
                        IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];

                        // Iterate through portions
                        for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                        {
                            IPortion portion = paragraph.Portions[portionIndex];

                            // Check if the portion is a MathPortion
                            MathPortion mathPortion = portion as MathPortion;
                            if (mathPortion != null)
                            {
                                // Access the MathParagraph (read-only property)
                                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                if (mathParagraph != null)
                                {
                                    mathParagraphCount++;
                                }
                            }
                        }
                    }
                }

                // Output the count for the current slide (slide numbers are 1-based)
                Console.WriteLine("Slide " + (slideIndex + 1) + ": " + mathParagraphCount + " MathParagraph(s) found.");
            }

            // Save the presentation before exiting
            try
            {
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to save presentation: " + ex.Message);
            }
        }
    }
}