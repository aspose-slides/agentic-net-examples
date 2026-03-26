using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a math shape to the first slide
            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0f, 0f, 500f, 50f);

            // Get the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the equation a + b = c
            mathParagraph.Add(
                new Aspose.Slides.MathText.MathematicalText("a")
                .Join("+")
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join("=")
                .Join(new Aspose.Slides.MathText.MathematicalText("c"))
            );

            // Get LaTeX representation (optional)
            string latex = mathParagraph.ToLatex();

            // Save the presentation
            presentation.Save("MathEquation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}