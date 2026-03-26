using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace MathEquationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a math shape to the first slide
            Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0f, 0f, 500f, 50f);

            // Retrieve the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the equation a² + b² = c² using superscript elements
            Aspose.Slides.MathText.IMathBlock equationBlock = new Aspose.Slides.MathText.MathBlock(
                new Aspose.Slides.MathText.MathSuperscriptElement(
                    new Aspose.Slides.MathText.MathematicalText("a"),
                    new Aspose.Slides.MathText.MathematicalText("2")
                )
            )
            .Join("+")
            .Join(new Aspose.Slides.MathText.MathSuperscriptElement(
                new Aspose.Slides.MathText.MathematicalText("b"),
                new Aspose.Slides.MathText.MathematicalText("2")
            ))
            .Join("=")
            .Join(new Aspose.Slides.MathText.MathSuperscriptElement(
                new Aspose.Slides.MathText.MathematicalText("c"),
                new Aspose.Slides.MathText.MathematicalText("2")
            ));

            // Add the equation block to the paragraph
            mathParagraph.Add(equationBlock);

            // Export the equation to LaTeX format (optional demonstration)
            string latex = mathParagraph.ToLatex();
            Console.WriteLine("LaTeX representation: " + latex);

            // Save the presentation
            string outPath = "MathEquation.pptx";
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}