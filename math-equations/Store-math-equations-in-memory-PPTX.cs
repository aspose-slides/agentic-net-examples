using System;
using System.Collections.Generic;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace ExtractMathEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            // In-memory collection to store extracted equations in LaTeX format
            List<string> equations = new List<string>();

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

                                    // Identify MathPortion instances
                                    MathPortion mathPortion = portion as MathPortion;
                                    if (mathPortion != null)
                                    {
                                        // Retrieve the MathParagraph and convert to LaTeX
                                        IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                        string latex = mathParagraph.ToLatex();

                                        // Store the extracted equation
                                        equations.Add(latex);
                                    }
                                }
                            }
                        }
                    }
                }

                // Example usage: write extracted equations to console
                Console.WriteLine("Extracted Math Equations (LaTeX):");
                foreach (string eq in equations)
                {
                    Console.WriteLine(eq);
                }

                // Save the presentation (required by the task)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}