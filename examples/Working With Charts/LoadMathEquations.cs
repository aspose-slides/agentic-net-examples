using System;
using System.IO;

namespace LoadMathEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source presentation containing math equations
            string sourcePath = "input.pptx";

            // Load the presentation from file
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(sourcePath);

            // Attempt to retrieve the first shape on the first slide as a math shape
            Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes[0] as Aspose.Slides.IAutoShape;

            if (mathShape != null && mathShape.TextFrame != null &&
                mathShape.TextFrame.Paragraphs.Count > 0 &&
                mathShape.TextFrame.Paragraphs[0].Portions.Count > 0)
            {
                // Cast the first portion to MathPortion to access the MathParagraph
                Aspose.Slides.MathText.IMathParagraph mathParagraph =
                    (mathShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion).MathParagraph;

                // Convert the mathematical equation to LaTeX format
                string latex = mathParagraph.ToLatex();

                // Output the LaTeX string
                Console.WriteLine("LaTeX representation: " + latex);
            }
            else
            {
                Console.WriteLine("No mathematical shape found on the first slide.");
            }

            // Save the (potentially unchanged) presentation before exiting
            string outputPath = "output.pptx";
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}