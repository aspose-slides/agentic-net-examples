using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a mathematical shape to the first slide
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build the equation a + b = c using MathematicalText and MathBlock
        Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock(
            (Aspose.Slides.MathText.IMathElement)new Aspose.Slides.MathText.MathematicalText("a")
        );
        mathBlock = (Aspose.Slides.MathText.MathBlock)mathBlock.Join(new Aspose.Slides.MathText.MathematicalText("+"));
        mathBlock = (Aspose.Slides.MathText.MathBlock)mathBlock.Join(new Aspose.Slides.MathText.MathematicalText("b"));
        mathBlock = (Aspose.Slides.MathText.MathBlock)mathBlock.Join(new Aspose.Slides.MathText.MathematicalText("="));
        mathBlock = (Aspose.Slides.MathText.MathBlock)mathBlock.Join(new Aspose.Slides.MathText.MathematicalText("c"));

        // Add the constructed block to the paragraph
        mathParagraph.Add(mathBlock);

        // Save the presentation as PDF
        presentation.Save("MathEquation.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
    }
}