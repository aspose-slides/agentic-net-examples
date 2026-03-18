using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace NaryOperatorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Add a mathematical shape to the first slide
                Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

                // Retrieve the math paragraph from the shape
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Create an N‑ary operator (Summation) with base, lower limit, and upper limit
                Aspose.Slides.MathText.MathNaryOperator naryOperator = new Aspose.Slides.MathText.MathNaryOperator(
                    '∑',
                    new Aspose.Slides.MathText.MathematicalText("i"),
                    new Aspose.Slides.MathText.MathematicalText("i=0"),
                    new Aspose.Slides.MathText.MathematicalText("n")
                );

                // Add the N‑ary operator to the math paragraph inside a MathBlock
                mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(naryOperator));

                // Save the presentation
                pres.Save("NaryOperator.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}