using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            var pres = new Presentation();
            var mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
            mathParagraph.Add(
                new MathematicalText("a")
                    .Join("+")
                    .Join(new MathematicalText("b"))
                    .Join("=")
                    .Join(new MathematicalText("c"))
            );
            var latex = mathParagraph.ToLatex();
            Console.WriteLine("LaTeX: " + latex);
            pres.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}