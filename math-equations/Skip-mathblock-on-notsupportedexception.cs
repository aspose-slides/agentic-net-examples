// -----------------------------------------------------------------------------
// Example: Export Math Paragraph to MathML with NotSupportedException Fallback
//
// Description:
// This console application creates a PowerPoint presentation containing a
// mathematical equation using Aspose.Slides for .NET. It attempts to export the
// math paragraph to MathML. If the WriteAsMathMl method throws a
// NotSupportedException, the program gracefully skips the export and continues.
// The resulting PPTX file is saved to the current directory.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, NotSupportedException, fallback
//
// Use Cases:
// - Generate PPTX with math equations and export to MathML for web rendering.
// - Ensure application continues when MathML export is not supported on the platform.
// - Automate creation of presentations with mathematical content while handling API limitations.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Build a simple mathematical expression: a + b = c
        Aspose.Slides.MathText.MathematicalText aText = new Aspose.Slides.MathText.MathematicalText("a");
        Aspose.Slides.MathText.MathematicalText plusText = new Aspose.Slides.MathText.MathematicalText("+");
        Aspose.Slides.MathText.MathematicalText bText = new Aspose.Slides.MathText.MathematicalText("b");
        Aspose.Slides.MathText.MathematicalText equalsText = new Aspose.Slides.MathText.MathematicalText("=");
        Aspose.Slides.MathText.MathematicalText cText = new Aspose.Slides.MathText.MathematicalText("c");

        // Add the expression to the math paragraph
        mathParagraph.Add(aText.Join(plusText).Join(bText).Join(equalsText).Join(cText));

        // Define output path for MathML
        string mathMlPath = Path.Combine(Directory.GetCurrentDirectory(), "EquationMathML.xml");

        // Attempt to write MathML, with fallback for NotSupportedException
        try
        {
            using (FileStream stream = new FileStream(mathMlPath, FileMode.Create, FileAccess.Write))
            {
                mathParagraph.WriteAsMathMl(stream);
            }
            Console.WriteLine("MathML successfully written to: " + mathMlPath);
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("WriteAsMathMl is not supported on this platform. Skipping MathML export.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while exporting MathML: " + ex.Message);
        }

        // Save the presentation
        string pptxPath = Path.Combine(Directory.GetCurrentDirectory(), "MathBlockExample.pptx");
        presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
        Console.WriteLine("Presentation saved to: " + pptxPath);
    }
}
