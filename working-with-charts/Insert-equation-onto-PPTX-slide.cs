using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Presentation pres = new Presentation())
        {
            // Add a math shape to the first slide
            IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

            // Retrieve the math paragraph from the shape
            IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Add a simple fraction: x / y
            IMathElement fraction = new MathematicalText("x").Divide("y");
            mathParagraph.Add(new MathBlock(fraction));

            // Add a complex equation: c² = a² + b²
            IMathBlock equation = new MathematicalText("c").SetSuperscript("2").Join("=")
                .Join(new MathematicalText("a").SetSuperscript("2"))
                .Join("+")
                .Join(new MathematicalText("b").SetSuperscript("2"));
            mathParagraph.Add(equation);

            // Save the presentation
            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}