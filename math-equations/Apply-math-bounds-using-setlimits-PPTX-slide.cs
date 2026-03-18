using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace ApplyMathBounds
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to host the mathematical equation
                IAutoShape mathShape = slide.Shapes.AddMathShape(0f, 0f, 720f, 150f);

                // Retrieve the math paragraph from the shape
                IMathParagraph mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Create integral symbol with upper and lower limits
                IMathElement integral = new MathematicalText("∫")
                                            .SetUpperLimit("b")
                                            .SetLowerLimit("a");

                // Create the expression x²
                IMathElement xSquared = new MathematicalText("x")
                                            .SetSuperscript("2");

                // Create differential dx
                IMathElement dx = new MathematicalText("dx");

                // Build the full equation: ∫ₐᵇ x² dx
                IMathElement equation = integral
                                            .Join(xSquared)
                                            .Join(dx);

                // Create a MathBlock using the single IMathElement to avoid overload ambiguity
                MathBlock mathBlock = new MathBlock(equation);

                // Add the MathBlock to the paragraph
                mathParagraph.Add(mathBlock);

                // Save the presentation
                presentation.Save("ApplyMathBounds.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}