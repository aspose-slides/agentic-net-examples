using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

public class Program
{
    public static void Main()
    {
        try
        {
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // N‑ary summation operator: Σ_{i=0}^{n} i
            Aspose.Slides.MathText.IMathElement summationBase = new Aspose.Slides.MathText.MathematicalText("i");
            Aspose.Slides.MathText.IMathNaryOperator summationOperator = summationBase.Nary(
                Aspose.Slides.MathText.MathNaryOperatorTypes.Summation,
                new Aspose.Slides.MathText.MathematicalText("i=0"),
                new Aspose.Slides.MathText.MathematicalText("n"));
            Aspose.Slides.MathText.MathBlock summationBlock = new Aspose.Slides.MathText.MathBlock(summationOperator);
            mathParagraph.Add(summationBlock);

            // Integral operator: ∫_{0}^{1} x dx
            Aspose.Slides.MathText.IMathElement integralBase = new Aspose.Slides.MathText.MathematicalText("x");
            Aspose.Slides.MathText.IMathElement integralElement = integralBase.Integral(
                Aspose.Slides.MathText.MathIntegralTypes.Simple,
                new Aspose.Slides.MathText.MathematicalText("0"),
                new Aspose.Slides.MathText.MathematicalText("1"));
            Aspose.Slides.MathText.MathBlock integralBlock = new Aspose.Slides.MathText.MathBlock(integralElement);
            Aspose.Slides.MathText.IMathBlock differentialBlock = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("dx"));
            Aspose.Slides.MathText.IMathBlock integralWithDifferential = integralBlock.JoinBlock(differentialBlock);
            mathParagraph.Add(integralWithDifferential);

            // Save the presentation
            presentation.Save("NaryIntegralExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}