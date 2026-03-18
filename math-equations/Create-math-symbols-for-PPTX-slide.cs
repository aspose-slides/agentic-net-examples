using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add a math shape to the first slide
            Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

            // Get the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Quadratic formula: x = (-b ± √(b²-4ac)) / (2a)
            Aspose.Slides.MathText.IMathBlock quadraticBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("x"))
                .Join("=")
                .Join(new Aspose.Slides.MathText.MathematicalText("("))
                .Join(new Aspose.Slides.MathText.MathematicalText("-"))
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join(new Aspose.Slides.MathText.MathematicalText("±"))
                .Join(new Aspose.Slides.MathText.MathematicalText("√"))
                .Join(new Aspose.Slides.MathText.MathematicalText("("))
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join(new Aspose.Slides.MathText.MathematicalText("²"))
                .Join(new Aspose.Slides.MathText.MathematicalText("-"))
                .Join(new Aspose.Slides.MathText.MathematicalText("4"))
                .Join(new Aspose.Slides.MathText.MathematicalText("a"))
                .Join(new Aspose.Slides.MathText.MathematicalText("c"))
                .Join(new Aspose.Slides.MathText.MathematicalText(")"))
                .Join(new Aspose.Slides.MathText.MathematicalText(")"))
                .Join(new Aspose.Slides.MathText.MathematicalText("/"))
                .Join(new Aspose.Slides.MathText.MathematicalText("("))
                .Join(new Aspose.Slides.MathText.MathematicalText("2"))
                .Join(new Aspose.Slides.MathText.MathematicalText("a"))
                .Join(new Aspose.Slides.MathText.MathematicalText(")"));

            mathParagraph.Add(quadraticBlock);

            // Integral example: ∫_0^1 x² dx
            Aspose.Slides.MathText.IMathBlock integralBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("∫"))
                .Join(new Aspose.Slides.MathText.MathematicalText("_"))
                .Join(new Aspose.Slides.MathText.MathematicalText("0"))
                .Join(new Aspose.Slides.MathText.MathematicalText("^"))
                .Join(new Aspose.Slides.MathText.MathematicalText("1"))
                .Join(new Aspose.Slides.MathText.MathematicalText("x"))
                .Join(new Aspose.Slides.MathText.MathematicalText("²"))
                .Join(new Aspose.Slides.MathText.MathematicalText("dx"));

            mathParagraph.Add(integralBlock);

            // Fraction example: (a+b)/(c+d)
            Aspose.Slides.MathText.IMathBlock fractionBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("("))
                .Join(new Aspose.Slides.MathText.MathematicalText("a"))
                .Join(new Aspose.Slides.MathText.MathematicalText("+"))
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join(new Aspose.Slides.MathText.MathematicalText(")"))
                .Join(new Aspose.Slides.MathText.MathematicalText("/"))
                .Join(new Aspose.Slides.MathText.MathematicalText("("))
                .Join(new Aspose.Slides.MathText.MathematicalText("c"))
                .Join(new Aspose.Slides.MathText.MathematicalText("+"))
                .Join(new Aspose.Slides.MathText.MathematicalText("d"))
                .Join(new Aspose.Slides.MathText.MathematicalText(")"));

            mathParagraph.Add(fractionBlock);

            // Save the presentation
            pres.Save("MathSymbols.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}