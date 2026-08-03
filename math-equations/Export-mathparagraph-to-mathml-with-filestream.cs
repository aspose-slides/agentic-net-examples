// -----------------------------------------------------------------------------
// Example: Export MathParagraph to MathML using FileStream in C#
//
// Description:
// Demonstrates how to create a simple mathematical equation, add it to a
// presentation, and export the MathParagraph to a MathML file using a
// FileStream with Aspose.Slides for .NET. The example also saves the
// presentation as a PPTX file.
//
// Keywords:
// C#, Aspose.Slides, MathParagraph, MathML, FileStream, Export, PowerPoint,
// PPTX, Presentation Processing, Office Automation
//
// Use Cases:
// - Export MathParagraph content to MathML for interoperability.
// - Automate generation of MathML from PowerPoint presentations.
// - Build .NET tools that process mathematical equations in slides.
// - Save presentations after modifying mathematical shapes.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace ExportMathParagraphToMathML
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output MathML file path
            string outFilePath = "mathml_output.xml";

            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a mathematical shape to the first slide
            IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Get the MathParagraph from the shape
            IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build a simple equation a + b = c
            mathParagraph.Add(
                new MathematicalText("a")
                .Join("+")
                .Join(new MathematicalText("b"))
                .Join("=")
                .Join(new MathematicalText("c"))
            );

            // Export the MathParagraph to MathML using a FileStream
            using (FileStream stream = new FileStream(outFilePath, FileMode.Create))
            {
                mathParagraph.WriteAsMathMl(stream);
            }

            // Save the presentation before exiting
            string presentationPath = "output.pptx";
            try
            {
                pres.Save(presentationPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported exception
                // Format not supported: " + ex.Message
            }

            // Clean up
            pres.Dispose();
        }
    }
}
