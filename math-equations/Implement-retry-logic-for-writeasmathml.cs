// -----------------------------------------------------------------------------
// Example: Export Math Paragraph to MathML with Retry Logic
//
// Description:
// This console application creates a PowerPoint presentation using Aspose.Slides,
// adds a mathematical shape, constructs a simple equation, and exports the
// MathML representation to a file. It implements retry logic to handle transient
// I/O errors during the WriteAsMathMl operation, ensuring reliable file writing.
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, retry, transient I/O errors
//
// Use Cases:
// - Generating MathML from slide equations for web publishing.
// - Automating export of mathematical content with resilience to file system glitches.
// - Integrating Aspose.Slides math features into robust batch processing pipelines.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Threading;

namespace AsposeSlidesMathMlExport
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define file paths
            string presentationPath = "MathShapeExample.pptx";
            string mathMlOutputPath = "EquationMathML.xml";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a math shape to the first slide
            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(50, 50, 500, 50);

            // Retrieve the math paragraph from the first portion
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build a simple equation: a + b = c
            string a = "a";
            string plus = "+";
            string b = "b";
            string equals = "=";
            string c = "c";

            mathParagraph.Add(
                new Aspose.Slides.MathText.MathematicalText(a)
                    .Join(plus)
                    .Join(new Aspose.Slides.MathText.MathematicalText(b))
                    .Join(equals)
                    .Join(new Aspose.Slides.MathText.MathematicalText(c))
            );

            // Export MathML with retry logic
            const int maxRetryAttempts = 3;
            int attempt = 0;
            bool success = false;

            while (attempt < maxRetryAttempts && !success)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(mathMlOutputPath, FileMode.Create, FileAccess.Write))
                    {
                        mathParagraph.WriteAsMathMl(fileStream);
                    }
                    success = true;
                }
                catch (IOException ioEx)
                {
                    attempt++;
                    Console.WriteLine($"I/O error during MathML export (attempt {attempt}): {ioEx.Message}");
                    if (attempt >= maxRetryAttempts)
                    {
                        Console.WriteLine("Maximum retry attempts reached. Export failed.");
                        throw;
                    }
                    // Wait before retrying
                    Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                    throw;
                }
            }

            // Save the presentation
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine($"Presentation saved to '{presentationPath}'.");
            Console.WriteLine($"MathML exported to '{mathMlOutputPath}'.");
        }
    }
}
