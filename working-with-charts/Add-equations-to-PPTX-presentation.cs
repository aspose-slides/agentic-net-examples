using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;
using System.IO;

class Program
{
    static void Main()
    {
        // Create a new presentation
        var presentation = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

        // Retrieve the math paragraph from the shape
        var mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Create a fraction x/y and add it to the paragraph
        var fraction = new MathematicalText("x").Divide("y");
        mathParagraph.Add(new MathBlock(fraction));

        // Create a quadratic equation c² = a² + b² and add it to the paragraph
        var quadratic = new MathematicalText("c")
            .SetSuperscript("2")
            .Join("=")
            .Join(new MathematicalText("a").SetSuperscript("2"))
            .Join("+")
            .Join(new MathematicalText("b").SetSuperscript("2"));
        mathParagraph.Add(quadratic);

        // Save the presentation
        presentation.Save("math_equations.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        presentation.Dispose();
    }
}