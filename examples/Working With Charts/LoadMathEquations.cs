using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load an existing presentation that contains mathematical equations
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation("input.pptx");

            // Iterate through all slides
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through all shapes on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                    // Check if the shape is an AutoShape with a TextFrame
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                    {
                        // Get the first paragraph and its first portion
                        Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                        if (paragraph.Portions.Count > 0)
                        {
                            Aspose.Slides.MathText.MathPortion mathPortion = paragraph.Portions[0] as Aspose.Slides.MathText.MathPortion;
                            if (mathPortion != null)
                            {
                                // Retrieve the mathematical paragraph and convert it to LaTeX
                                Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                string latex = mathParagraph.ToLatex();

                                // Output the LaTeX representation
                                Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}: {latex}");
                            }
                        }
                    }
                }
            }

            // Save the presentation (required before exiting)
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}