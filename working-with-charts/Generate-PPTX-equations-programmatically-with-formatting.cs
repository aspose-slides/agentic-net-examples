using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace MathEquationDemo
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Add a shape that will host the mathematical content
                IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);

                // Retrieve the MathParagraph from the shape
                IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Create a fraction x / y and add it to the paragraph
                IMathElement fraction = new MathematicalText("x").Divide("y");
                MathBlock fractionBlock = new MathBlock(fraction);
                mathParagraph.Add(fractionBlock);

                // Build the quadratic formula: c² = a² + b²
                // Create individual blocks for each part
                MathBlock blockC = new MathBlock(new MathematicalText("c"));
                blockC.SetSuperscript("2");

                MathBlock blockEquals = new MathBlock(new MathematicalText("="));

                MathBlock blockA = new MathBlock(new MathematicalText("a"));
                blockA.SetSuperscript("2");

                MathBlock blockPlus = new MathBlock(new MathematicalText("+"));

                MathBlock blockB = new MathBlock(new MathematicalText("b"));
                blockB.SetSuperscript("2");

                // Combine the blocks into a single equation block
                MathBlock equationBlock = new MathBlock();
                equationBlock.JoinBlock(blockC);
                equationBlock.JoinBlock(blockEquals);
                equationBlock.JoinBlock(blockA);
                equationBlock.JoinBlock(blockPlus);
                equationBlock.JoinBlock(blockB);

                // Add the equation to the paragraph
                mathParagraph.Add(equationBlock);

                // Save the presentation
                presentation.Save("MathEquations.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}