using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a math shape to the first slide
            IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

            // Retrieve the math paragraph from the shape
            IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the equation: c² = a² + b²

            // First part: c²
            MathBlock blockC = new MathBlock(
                new MathSuperscriptElement(
                    new MathematicalText("c"),
                    new MathematicalText("2")
                )
            );
            blockC.Add(new MathematicalText("="));

            // Second part: a² + b²
            MathBlock blockAB = new MathBlock(
                new MathSuperscriptElement(
                    new MathematicalText("a"),
                    new MathematicalText("2")
                )
            );
            blockAB.Add(new MathematicalText("+"));
            blockAB.Add(new MathSuperscriptElement(
                new MathematicalText("b"),
                new MathematicalText("2")
            ));

            // Add both blocks to the paragraph
            mathParagraph.Add(blockC);
            mathParagraph.Add(blockAB);

            // Save the presentation
            string outPath = "math_equation.pptx";
            pres.Save(outPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}