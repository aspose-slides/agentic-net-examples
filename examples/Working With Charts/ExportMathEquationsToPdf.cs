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

        // Get the math paragraph from the math portion
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Create a math block for the equation c² = a² + b²
        Aspose.Slides.MathText.MathBlock equationBlock = new Aspose.Slides.MathText.MathBlock();
        equationBlock.Add(new Aspose.Slides.MathText.MathematicalText("c").SetSuperscript("2"));
        equationBlock.Add(new Aspose.Slides.MathText.MathematicalText("="));
        equationBlock.Add(new Aspose.Slides.MathText.MathematicalText("a").SetSuperscript("2"));
        equationBlock.Add(new Aspose.Slides.MathText.MathematicalText("+"));
        equationBlock.Add(new Aspose.Slides.MathText.MathematicalText("b").SetSuperscript("2"));

        // Add the equation block to the paragraph
        mathParagraph.Add(equationBlock);

        // Save the presentation as PDF
        presentation.Save("MathEquation.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
    }
}