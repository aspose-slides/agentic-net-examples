using System;
using Aspose.Slides;
using Aspose.Slides.MathText;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build the equation a + b = c
        mathParagraph.Add(new Aspose.Slides.MathText.MathematicalText("a")
            .Join("+")
            .Join(new Aspose.Slides.MathText.MathematicalText("b"))
            .Join("=")
            .Join(new Aspose.Slides.MathText.MathematicalText("c")));

        // Export the equation to LaTeX (optional)
        string latex = mathParagraph.ToLatex();

        // Save the presentation as PDF
        presentation.Save("MathEquation.pdf", Aspose.Slides.Export.SaveFormat.Pdf);

        // Also save as PPTX for reference
        presentation.Save("MathEquation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}