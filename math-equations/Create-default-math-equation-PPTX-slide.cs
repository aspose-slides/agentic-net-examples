using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a math shape to host the equation
                Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 500, 50);

                // Retrieve the math paragraph from the shape
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Build a simple equation: a + b = c
                Aspose.Slides.MathText.MathematicalText a = new Aspose.Slides.MathText.MathematicalText("a");
                Aspose.Slides.MathText.MathematicalText b = new Aspose.Slides.MathText.MathematicalText("b");
                Aspose.Slides.MathText.MathematicalText c = new Aspose.Slides.MathText.MathematicalText("c");
                Aspose.Slides.MathText.MathematicalText plus = new Aspose.Slides.MathText.MathematicalText("+");
                Aspose.Slides.MathText.MathematicalText equals = new Aspose.Slides.MathText.MathematicalText("=");

                // Add the equation to the paragraph
                mathParagraph.Add(a.Join(plus).Join(b).Join(equals).Join(c));

                // Optional: get LaTeX representation
                string latex = mathParagraph.ToLatex();

                // Save the presentation
                presentation.Save("DefaultMathEquation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}