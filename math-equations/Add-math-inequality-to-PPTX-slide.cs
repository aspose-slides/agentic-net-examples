using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

public class Program
{
    public static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a math shape to host the equation
            Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the math paragraph from the first portion (cast to MathPortion)
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the inequality "a < b"
            Aspose.Slides.MathText.MathematicalText a = new Aspose.Slides.MathText.MathematicalText("a");
            Aspose.Slides.MathText.MathematicalText lessThan = new Aspose.Slides.MathText.MathematicalText("<");
            Aspose.Slides.MathText.MathematicalText b = new Aspose.Slides.MathText.MathematicalText("b");

            // Create a math block and add the elements
            Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock(a);
            mathBlock.Add(lessThan);
            mathBlock.Add(b);

            // Add the block to the paragraph
            mathParagraph.Add(mathBlock);

            // Save the presentation
            presentation.Save("MathInequality.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}