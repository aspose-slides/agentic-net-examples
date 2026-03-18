using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var mathShape = slide.Shapes.AddMathShape(0, 0, 720, 150);
            var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion).MathParagraph;

            var fraction = new Aspose.Slides.MathText.MathematicalText("x").Divide("y");
            mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(fraction));

            var mathBlock = new Aspose.Slides.MathText.MathematicalText("c")
                .SetSuperscript("2")
                .Join("=")
                .Join(new Aspose.Slides.MathText.MathematicalText("a").SetSuperscript("2"))
                .Join("+")
                .Join(new Aspose.Slides.MathText.MathematicalText("b").SetSuperscript("2"));
            mathParagraph.Add(mathBlock);

            presentation.Save("math.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}