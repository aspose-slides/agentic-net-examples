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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a math shape to host the equation
                Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(50, 50, 400, 100);

                // Retrieve the math paragraph from the first portion
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Create right‑aligned subscript/superscript (N with i subscript and j superscript)
                Aspose.Slides.MathText.IMathRightSubSuperscriptElement rightSubSup = new Aspose.Slides.MathText.MathematicalText("N")
                    .SetSubSuperscriptOnTheRight("i", "j");
                // Align scripts horizontally
                rightSubSup.AlignScripts = true;
                // Add to the math paragraph
                mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(rightSubSup));

                // Create left‑aligned subscript/superscript (N with i subscript and j superscript)
                Aspose.Slides.MathText.IMathLeftSubSuperscriptElement leftSubSup = new Aspose.Slides.MathText.MathematicalText("N")
                    .SetSubSuperscriptOnTheLeft("i", "j");
                // Add to the math paragraph
                mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(leftSubSup));

                // Save the presentation
                string outPath = "SubSuperscriptExample.pptx";
                presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Open the generated file
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(outPath) { UseShellExecute = true });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}