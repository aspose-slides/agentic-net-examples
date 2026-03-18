using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a mathematical shape to the first slide
            IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the math paragraph from the shape
            IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Create a fraction using the Divide method (numerator "x", denominator "y")
            IMathFraction fraction = new MathematicalText("x").Divide("y");

            // Add the fraction to the math paragraph as a math block
            mathParagraph.Add(new MathBlock(fraction));

            // Save the presentation
            presentation.Save("DividedMath.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}