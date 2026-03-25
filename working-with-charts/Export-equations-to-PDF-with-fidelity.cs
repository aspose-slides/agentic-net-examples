using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a math shape to the first slide
            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Construct a mathematical block representing the equation a + b = c
            Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock();
            mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("a"));
            mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("+"));
            mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("b"));
            mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("="));
            mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("c"));

            // Add the block to the paragraph
            mathParagraph.Add(mathBlock);

            // Save the presentation as PDF to preserve equation layout and fonts
            string outputPath = "Equation.pdf";
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pdf);
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine("Input file not found: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}