using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace WorkingWithCharts
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a math shape to host the equation
            IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0f, 0f, 500f, 50f);

            // Retrieve the math paragraph from the shape
            IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Create a math block and add elements to form the equation a + b = c
            MathBlock mathBlock = new MathBlock();
            mathBlock.Add(new MathematicalText("a"));
            mathBlock.Add(new MathematicalText("+"));
            mathBlock.Add(new MathematicalText("b"));
            mathBlock.Add(new MathematicalText("="));
            mathBlock.Add(new MathematicalText("c"));

            // Add the math block to the paragraph
            mathParagraph.Add(mathBlock);

            // Save the presentation as XPS
            pres.Save("MathEquationOutput.xps", SaveFormat.Xps);

            // Dispose the presentation
            pres.Dispose();
        }
    }
}