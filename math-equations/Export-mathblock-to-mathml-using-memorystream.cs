// -----------------------------------------------------------------------------
// Example: Export Math Block to MathML using Aspose.Slides and MemoryStream
//
// Description:
// This console application creates a PowerPoint presentation, inserts a
// Math shape, builds a simple mathematical expression, and exports the MathML
// representation of the expression to a memory stream. The MathML string is
// printed to the console. It demonstrates Aspose.Slides for .NET API usage
// for MathText and stream handling.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, Math shape, Export, MemoryStream
//
// Use Cases:
// - Generate MathML from PowerPoint equations for web rendering.
// - Convert slide math content to XML for further processing.
// - Automate extraction of mathematical expressions from presentations.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;

namespace AsposeSlidesMathMlExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output file for the generated presentation
            string outputPptxPath = Path.Combine(Directory.GetCurrentDirectory(), "MathExportDemo.pptx");

            // Ensure any existing file is removed to avoid conflicts
            if (File.Exists(outputPptxPath))
            {
                try
                {
                    File.Delete(outputPptxPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to delete existing output file: " + ex.Message);
                    return;
                }
            }

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a Math shape to the slide
                Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 500, 50);

                // Retrieve the Math paragraph from the shape
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Build a simple expression: a + b = c
                Aspose.Slides.MathText.MathematicalText a = new Aspose.Slides.MathText.MathematicalText("a");
                Aspose.Slides.MathText.MathematicalText plus = new Aspose.Slides.MathText.MathematicalText("+");
                Aspose.Slides.MathText.MathematicalText b = new Aspose.Slides.MathText.MathematicalText("b");
                Aspose.Slides.MathText.MathematicalText equals = new Aspose.Slides.MathText.MathematicalText("=");
                Aspose.Slides.MathText.MathematicalText c = new Aspose.Slides.MathText.MathematicalText("c");

                // Combine the parts into a single Math paragraph
                mathParagraph.Add(a.Join(plus).Join(b).Join(equals).Join(c));

                // Export the Math paragraph to MathML using a MemoryStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    mathParagraph.WriteAsMathMl(memoryStream);

                    // Reset stream position to read the content
                    memoryStream.Position = 0;
                    using (StreamReader reader = new StreamReader(memoryStream, Encoding.UTF8))
                    {
                        string mathMl = reader.ReadToEnd();
                        Console.WriteLine("Generated MathML:");
                        Console.WriteLine(mathMl);
                    }
                }

                // Save the presentation to a file
                using (FileStream fileStream = new FileStream(outputPptxPath, FileMode.Create, FileAccess.Write))
                {
                    presentation.Save(fileStream, Aspose.Slides.Export.SaveFormat.Pptx);
                }

                // Clean up
                presentation.Dispose();

                Console.WriteLine("Presentation saved to: " + outputPptxPath);
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine("File not found: " + fnfEx.Message);
            }
            catch (NotSupportedException nsEx)
            {
                Console.WriteLine("Operation not supported: " + nsEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
