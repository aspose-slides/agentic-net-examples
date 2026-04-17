using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var pres = new Aspose.Slides.Presentation();
            var mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 300, 50);
            var mathPortion = mathShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion;
            if (mathPortion != null)
            {
                var mathParagraph = mathPortion.MathParagraph;
                mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("x+y")));
                var latex = mathParagraph.ToLatex();
                Console.WriteLine("LaTeX: " + latex);
            }
            var outPath = "output.pptx";
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}