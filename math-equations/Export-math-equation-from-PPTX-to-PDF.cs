using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace ExportMathEquation
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Input presentation containing the math equation
                string inputPath = "input.pptx";
                // Output file for the exported MathML
                string mathMlPath = "equation.xml";
                // Output presentation (saved after processing)
                string outputPresPath = "output.pptx";

                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    // Assume the first shape on the first slide is a math shape
                    Aspose.Slides.IAutoShape mathShape = (Aspose.Slides.IAutoShape)pres.Slides[0].Shapes[0];

                    // Retrieve the math paragraph from the shape
                    Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                    // Export the math paragraph to MathML
                    using (System.IO.FileStream fs = System.IO.File.Create(mathMlPath))
                    {
                        mathParagraph.WriteAsMathMl(fs);
                    }

                    // Save the (potentially modified) presentation
                    pres.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}