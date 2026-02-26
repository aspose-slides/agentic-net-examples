using System;
using Aspose.Slides;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0f, 0f, 720f, 150f);

        // Get the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Create a fraction (x / y)
        Aspose.Slides.MathText.IMathFraction fraction = new Aspose.Slides.MathText.MathFraction(
            new Aspose.Slides.MathText.MathematicalText("x"),
            new Aspose.Slides.MathText.MathematicalText("y")
        );

        // Wrap the fraction in a MathBlock and add it to the paragraph
        Aspose.Slides.MathText.IMathBlock fractionBlock = new Aspose.Slides.MathText.MathBlock(fraction);
        mathParagraph.Add(fractionBlock);

        // Add a superscript example (c²)
        Aspose.Slides.MathText.IMathBlock superscriptBlock = new Aspose.Slides.MathText.MathBlock(
            new Aspose.Slides.MathText.MathematicalText("c").SetSuperscript("2")
        );
        mathParagraph.Add(superscriptBlock);

        // Retrieve LaTeX representation (optional)
        string latex = mathParagraph.ToLatex();

        // Save the presentation
        presentation.Save("IdentifyMathEquationTypes.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}