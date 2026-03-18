using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace ExtractMathEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Load the presentation
                Presentation presentation = new Presentation("input.pptx");

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];

                        // Process only AutoShape objects that contain a TextFrame
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
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
                                    if (mathPortion != null && mathPortion.MathParagraph != null)
                                    {
                                        IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                        string latex = mathParagraph.ToLatex();
                                        Console.WriteLine("Slide {0}, Shape {1}: {2}", slideIndex + 1, shapeIndex + 1, latex);
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the presentation (no changes made, just to satisfy requirement)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}