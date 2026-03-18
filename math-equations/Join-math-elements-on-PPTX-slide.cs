using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (var pres = new Aspose.Slides.Presentation())
            {
                var slide = pres.Slides[0];
                var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);
                var mathPortion = mathShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion;
                var mathParagraph = mathPortion.MathParagraph;

                var block1 = new Aspose.Slides.MathText.MathSuperscriptElement(
                                new Aspose.Slides.MathText.MathematicalText("c"),
                                new Aspose.Slides.MathText.MathematicalText("2"))
                             .Join(new Aspose.Slides.MathText.MathematicalText("="));

                var block2 = new Aspose.Slides.MathText.MathSuperscriptElement(
                                new Aspose.Slides.MathText.MathematicalText("a"),
                                new Aspose.Slides.MathText.MathematicalText("2"))
                             .Join(new Aspose.Slides.MathText.MathematicalText("+"))
                             .Join(new Aspose.Slides.MathText.MathSuperscriptElement(
                                new Aspose.Slides.MathText.MathematicalText("b"),
                                new Aspose.Slides.MathText.MathematicalText("2")));

                var combinedBlock = block1.JoinBlock(block2);
                mathParagraph.Add(combinedBlock);

                pres.Save("CombinedMath.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}