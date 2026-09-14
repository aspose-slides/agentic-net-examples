// -----------------------------------------------------------------------------
// Example: Export Math Paragraph to MathML using Aspose.Slides
//
// Description:
// This console application creates a PowerPoint presentation, inserts a
// mathematical shape, builds a simple equation, and exports the entire
// MathParagraph to MathML using WriteAsMathMl with a FileStream. The result
// is saved as a .xml file alongside the generated PPTX.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, MathParagraph, Export
//
// Use Cases:
// - Generate MathML from equations created in PowerPoint for web rendering.
// - Automate conversion of slide math content to XML for further processing.
// - Integrate Aspose.Slides math export in document generation pipelines.
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
            string outputDirectory = "Output";
            string pptxPath = Path.Combine(outputDirectory, "MathParagraph.pptx");
            string mathmlPath = Path.Combine(outputDirectory, "MathParagraph.xml");

            try
            {
                if (!Directory.Exists(outputDirectory))
                {
                    Directory.CreateDirectory(outputDirectory);
                }

                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Add a mathematical shape to the first slide
                Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(50, 50, 400, 50);

                // Retrieve the MathParagraph from the shape
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Build a simple equation: a + b = c
                mathParagraph.Add(
                    new Aspose.Slides.MathText.MathematicalText("a")
                        .Join(new Aspose.Slides.MathText.MathematicalText("+"))
                        .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                        .Join(new Aspose.Slides.MathText.MathematicalText("="))
                        .Join(new Aspose.Slides.MathText.MathematicalText("c"))
                );

                // Export the MathParagraph to MathML
                using (FileStream mathmlStream = new FileStream(mathmlPath, FileMode.Create, FileAccess.Write))
                {
                    mathParagraph.WriteAsMathMl(mathmlStream);
                }

                // Save the presentation
                presentation.Save(pptxPath, Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + pptxPath);
                Console.WriteLine("MathML exported to: " + mathmlPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
