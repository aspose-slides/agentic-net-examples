// -----------------------------------------------------------------------------
// Example: Export Math Paragraph to MathML with Safe Stream Handling
//
// Description:
// This console application creates a PowerPoint presentation using Aspose.Slides
// for .NET, adds a mathematical shape containing a simple equation, and exports
// the math paragraph to a MathML file. A try‑finally block guarantees that the
// FileStream is closed even if WriteAsMathMl throws an exception. The resulting
// PPTX and MathML files are saved to the current directory.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, export, try-finally, safe stream
//
// Use Cases:
// - Generate MathML from PowerPoint equations for web publishing.
// - Ensure resources are released when exporting large presentations.
// - Automate creation of PPTX with embedded math and export to MathML.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMathExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPptxPath = Path.Combine(Directory.GetCurrentDirectory(), "MathExport.pptx");
            string outputMathMlPath = Path.Combine(Directory.GetCurrentDirectory(), "Equation.xml");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a mathematical shape to the first slide
            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build a simple equation: a + b = c
            Aspose.Slides.MathText.MathematicalText a = new Aspose.Slides.MathText.MathematicalText("a");
            Aspose.Slides.MathText.MathematicalText plus = new Aspose.Slides.MathText.MathematicalText("+");
            Aspose.Slides.MathText.MathematicalText b = new Aspose.Slides.MathText.MathematicalText("b");
            Aspose.Slides.MathText.MathematicalText equals = new Aspose.Slides.MathText.MathematicalText("=");
            Aspose.Slides.MathText.MathematicalText c = new Aspose.Slides.MathText.MathematicalText("c");

            // Combine the parts into a single math element and add to the paragraph
            mathParagraph.Add(a.Join(plus).Join(b).Join(equals).Join(c));

            // Export the math paragraph to MathML using a safe FileStream
            FileStream stream = null;
            try
            {
                stream = new FileStream(outputMathMlPath, FileMode.Create, FileAccess.Write);
                mathParagraph.WriteAsMathMl(stream);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    stream.Dispose();
                }
            }

            // Save the presentation to PPTX format
            presentation.Save(outputPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPptxPath);
            Console.WriteLine("MathML exported to: " + outputMathMlPath);
        }
    }
}
