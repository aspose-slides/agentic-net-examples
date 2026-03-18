using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace ApplyMathLimitExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Add a math shape to host the equation
                    IAutoShape mathShape = slide.Shapes.AddMathShape(50f, 50f, 600f, 100f);

                    // Retrieve the math paragraph from the shape
                    IMathParagraph mathParagraph = ((IMathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                    // Create a limit element: lim_{n→∞}
                    IMathElement limitBase = new MathematicalText("lim");
                    IMathElement limitValue = new MathematicalText("n→∞");
                    IMathElement limitElement = new MathLimit(limitBase, limitValue);

                    // Build the equation: lim_{n→∞} (1 + 1/n)^n = e
                    IMathBlock equationBlock = new MathBlock(limitElement)
                        .Join(" ")
                        .Join("(")
                        .Join(new MathematicalText("1"))
                        .Join(" + ")
                        .Join(new MathematicalText("1"))
                        .Join("/")
                        .Join(new MathematicalText("n"))
                        .Join(")")
                        .Join("^")
                        .Join(new MathematicalText("n"))
                        .Join(" = ")
                        .Join(new MathematicalText("e"));

                    // Add the equation to the paragraph
                    mathParagraph.Add(equationBlock);

                    // Save the presentation
                    presentation.Save("MathLimitExample.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}