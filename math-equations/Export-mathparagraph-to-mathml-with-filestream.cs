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
            FileStream stream = new FileStream(outFilePath, FileMode.Create);
            mathParagraph.WriteAsMathMl(stream);
            stream.Close();

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