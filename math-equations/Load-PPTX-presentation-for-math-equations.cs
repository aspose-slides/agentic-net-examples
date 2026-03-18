using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace MathEquationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Path to the source PPTX file
                string sourcePath = "input.pptx";

                // Load the presentation
                using (Presentation presentation = new Presentation(sourcePath))
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a Math shape to host the equation
                    IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

                    // Retrieve the MathParagraph from the shape
                    IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                    // Create a single IMathElement (MathematicalText) to avoid constructor ambiguity
                    IMathElement element = new MathematicalText("x");

                    // Construct MathBlock using the IMathElement overload
                    MathBlock mathBlock = new MathBlock(element);

                    // Add the MathBlock to the paragraph
                    mathParagraph.Add(mathBlock);

                    // Save the modified presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}