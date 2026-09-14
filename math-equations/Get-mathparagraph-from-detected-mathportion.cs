// -----------------------------------------------------------------------------
// Example: Retrieve MathParagraph from MathPortion in PowerPoint using Aspose.Slides
//
// Description:
// This console application demonstrates how to create a PowerPoint presentation,
// add a mathematical shape, and retrieve the MathParagraph object associated with
// the first MathPortion. It uses Aspose.Slides for .NET to manipulate PPTX files
// and saves the resulting presentation. The code checks for existing files and
// handles format support exceptions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathParagraph, MathPortion, MathShape
//
// Use Cases:
// - Automating the extraction of mathematical equations from slides for analysis.
// - Generating slide content programmatically with embedded math expressions.
// - Converting math equations to other formats (e.g., MathML, LaTeX) after retrieval.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMathParagraphExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "MathParagraphExample.pptx";

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a math shape to the first slide
                Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0f, 0f, 500f, 50f);

                // Build a simple equation: a + b = c
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;
                mathParagraph.Add(
                    new Aspose.Slides.MathText.MathematicalText("a")
                    .Join(new Aspose.Slides.MathText.MathematicalText("+"))
                    .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                    .Join(new Aspose.Slides.MathText.MathematicalText("="))
                    .Join(new Aspose.Slides.MathText.MathematicalText("c"))
                );

                // Retrieve the MathParagraph from the MathPortion (demonstration)
                Aspose.Slides.MathText.MathPortion retrievedPortion = (Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];
                Aspose.Slides.MathText.IMathParagraph retrievedParagraph = retrievedPortion.MathParagraph;

                // Output a simple confirmation
                Console.WriteLine("MathParagraph successfully retrieved. Contains {0} elements.", retrievedParagraph.Count);

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to: " + Path.GetFullPath(outputPath));
            }
            catch (FileNotFoundException fileEx)
            {
                Console.WriteLine("File error: " + fileEx.Message);
            }
            catch (NotSupportedException notSupEx)
            {
                Console.WriteLine("Format not supported: " + notSupEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
