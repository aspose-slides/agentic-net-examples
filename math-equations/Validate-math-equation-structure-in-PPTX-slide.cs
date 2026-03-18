using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            using (Presentation pres = new Presentation(inputPath))
            {
                // Access the first slide using the ISlide interface
                ISlide slide = pres.Slides[0];

                // Add a math shape to the slide
                IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 500, 50);

                // Retrieve the math paragraph from the shape
                IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Create a math block representing the equation a+b=c
                IMathBlock equationBlock = new MathBlock(new MathematicalText("a"));
                equationBlock.Add(new MathematicalText("+"));
                equationBlock.Add(new MathematicalText("b"));
                equationBlock.Add(new MathematicalText("="));
                equationBlock.Add(new MathematicalText("c"));

                // Add the block to the paragraph
                mathParagraph.Add(equationBlock);

                // Validate by converting the paragraph to LaTeX
                string latex = mathParagraph.ToLatex();
                Console.WriteLine("LaTeX representation: " + latex);

                // Save the modified presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}