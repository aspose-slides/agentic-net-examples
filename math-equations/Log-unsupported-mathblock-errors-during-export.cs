using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace AsposeSlidesMathExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Add a mathematical shape to the first slide
            IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the math paragraph from the shape
            IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build a simple equation: a + b = c
            mathParagraph.Add(
                new MathematicalText("a")
                .Join("+")
                .Join(new MathematicalText("b"))
                .Join("=")
                .Join(new MathematicalText("c"))
            );

            // Export the math paragraph to MathML, handling unsupported block types
            string mathMlPath = "equation.xml";
            FileStream mathMlStream = null;
            try
            {
                mathMlStream = new FileStream(mathMlPath, FileMode.Create, FileAccess.Write);
                mathParagraph.WriteAsMathMl(mathMlStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error exporting MathML: " + ex.Message);
            }
            finally
            {
                if (mathMlStream != null)
                {
                    mathMlStream.Close();
                }
            }

            // Save the presentation
            string pptxPath = "math.pptx";
            pres.Save(pptxPath, SaveFormat.Pptx);
        }
    }
}