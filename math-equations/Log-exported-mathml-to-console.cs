using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

        // Get the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build mathematical elements
        Aspose.Slides.MathText.MathematicalText textX = new Aspose.Slides.MathText.MathematicalText("x");
        Aspose.Slides.MathText.MathematicalText textY = new Aspose.Slides.MathText.MathematicalText("y");
        Aspose.Slides.MathText.MathFraction fraction = new Aspose.Slides.MathText.MathFraction(textX, textY);
        Aspose.Slides.MathText.MathPhantom phantom = new Aspose.Slides.MathText.MathPhantom(fraction) { Show = true, ZeroAsc = false };
        Aspose.Slides.MathText.MathematicalText textA = new Aspose.Slides.MathText.MathematicalText("a");
        Aspose.Slides.MathText.MathematicalText textB = new Aspose.Slides.MathText.MathematicalText("b");
        Aspose.Slides.MathText.IMathElement element1 = new Aspose.Slides.MathText.MathematicalText().Join(phantom).Join(textA);
        Aspose.Slides.MathText.MathArray array = new Aspose.Slides.MathText.MathArray(new Aspose.Slides.MathText.IMathElement[] { element1, textB });
        Aspose.Slides.MathText.MathDelimiter delimiter = new Aspose.Slides.MathText.MathDelimiter(array) { BeginningCharacter = '(', EndingCharacter = ')' };
        Aspose.Slides.MathText.IMathElement finalElement = new Aspose.Slides.MathText.MathematicalText().Join(delimiter).Join(new Aspose.Slides.MathText.MathematicalText("c"));
        Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock(finalElement);

        // Add the math block to the paragraph
        mathParagraph.Add(mathBlock);

        // Diagnostic: write MathML to console
        using (MemoryStream ms = new MemoryStream())
        {
            mathParagraph.WriteAsMathMl(ms);
            ms.Position = 0;
            using (StreamReader reader = new StreamReader(ms))
            {
                string mathMl = reader.ReadToEnd();
                Console.WriteLine("MathML Output:");
                Console.WriteLine(mathMl);
            }
        }

        // Save the presentation
        presentation.Save("MathExample.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}