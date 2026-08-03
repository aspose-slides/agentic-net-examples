// -----------------------------------------------------------------------------
// Example: Retrieve mathparagraph from detected mathportion using C#
//
// Description:
// Demonstrates how to retrieve a MathParagraph from a detected MathPortion,
// add a mathematical expression, convert it to LaTeX, and save the presentation
// using Aspose.Slides for .NET. The example creates a new presentation, adds a
// math shape, accesses its first MathPortion, manipulates the underlying
// MathParagraph, and writes the resulting LaTeX string to the console.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Retrieve, MathParagraph,
// Detected, MathPortion, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate retrieval and modification of MathParagraphs in PPTX files.
// - Build C# tools for processing mathematical equations in PowerPoint.
// - Generate LaTeX representations of slide equations.
// - Validate and transform math content before publishing.
// -----------------------------------------------------------------------------
using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var pres = new Aspose.Slides.Presentation();
            var mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 300, 50);
            var mathPortion = mathShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion;
            if (mathPortion != null)
            {
                var mathParagraph = mathPortion.MathParagraph;
                mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("x+y")));
                var latex = mathParagraph.ToLatex();
                Console.WriteLine("LaTeX: " + latex);
            }
            var outPath = "output.pptx";
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
