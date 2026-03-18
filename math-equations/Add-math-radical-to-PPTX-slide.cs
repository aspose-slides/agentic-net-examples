using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 400, 100);
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            Aspose.Slides.MathText.MathRadical radical = new Aspose.Slides.MathText.MathRadical(
                new Aspose.Slides.MathText.MathematicalText("x"),
                new Aspose.Slides.MathText.MathematicalText("3"));

            Aspose.Slides.MathText.MathBlock block = new Aspose.Slides.MathText.MathBlock(radical);
            mathParagraph.Add(block);

            pres.Save("MathRadical.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}