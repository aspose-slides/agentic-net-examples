// -----------------------------------------------------------------------------
// Example: Export Math Paragraph to MathML Without Altering Original Presentation
//
// Description:
// This console application loads an existing PowerPoint PPTX file, adds a
// mathematical shape, constructs a simple equation, and exports the equation
// as MathML to a separate XML file. The original presentation content is not
// modified; the updated presentation is saved to a new file. The example uses
// Aspose.Slides for .NET and demonstrates handling of file existence and
// Aspose format exceptions.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, Math Paragraph, Export
//
// Use Cases:
// - Generate MathML from equations created in a PowerPoint slide for web publishing.
// - Preserve the original presentation while extracting mathematical content.
// - Automate conversion of slide equations to XML for further processing.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMathMlExport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPresentationPath = "output.pptx";
            string mathMlPath = "equation.xml";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a math shape to the slide
                Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 500, 50);

                // Retrieve the math paragraph from the first portion
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Build the equation a + b = c
                Aspose.Slides.MathText.MathematicalText a = new Aspose.Slides.MathText.MathematicalText("a");
                Aspose.Slides.MathText.MathematicalText plus = new Aspose.Slides.MathText.MathematicalText("+");
                Aspose.Slides.MathText.MathematicalText b = new Aspose.Slides.MathText.MathematicalText("b");
                Aspose.Slides.MathText.MathematicalText equals = new Aspose.Slides.MathText.MathematicalText("=");
                Aspose.Slides.MathText.MathematicalText c = new Aspose.Slides.MathText.MathematicalText("c");

                mathParagraph.Add(a.Join(plus).Join(b).Join(equals).Join(c));

                // Export the math paragraph to MathML without affecting the original presentation
                using (FileStream mathMlStream = new FileStream(mathMlPath, FileMode.Create, FileAccess.Write))
                {
                    mathParagraph.WriteAsMathMl(mathMlStream);
                }

                // Save the modified presentation to a new file to keep the original unchanged
                presentation.Save(outputPresentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("MathML exported to: " + mathMlPath);
                Console.WriteLine("Modified presentation saved as: " + outputPresentationPath);
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException ex)
            {
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
