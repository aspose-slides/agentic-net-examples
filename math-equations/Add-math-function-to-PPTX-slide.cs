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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];
            Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);
            Aspose.Slides.MathText.IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion).MathParagraph;
            Aspose.Slides.MathText.MathFunction mathFunction = new Aspose.Slides.MathText.MathFunction("sin", new Aspose.Slides.MathText.MathematicalText("x"));
            mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(mathFunction));
            presentation.Save("MathFunctionPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}