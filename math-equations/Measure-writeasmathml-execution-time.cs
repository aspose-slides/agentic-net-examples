// -----------------------------------------------------------------------------
// Example: Measure WriteAsMathMl execution time using C#
//
// Description:
// Demonstrates how to measure the execution time of the WriteAsMathMl method 
// for a MathParagraph using Aspose.Slides for .NET. The example creates a 
// presentation, adds a simple mathematical equation, exports it to MathML 
// in memory while timing the operation, and then saves the presentation. 
// This pattern helps developers benchmark MathML export performance in 
// PowerPoint automation scenarios.
//
// Keywords:
// C#, Aspose.Slides, MathML, WriteAsMathMl, performance measurement, 
// execution time, PowerPoint, PPTX, automation, presentation processing
//
// Use Cases:
// - Benchmark MathML export speed for large or complex equations.
// - Optimize PowerPoint automation workflows that involve MathML.
// - Validate performance of Aspose.Slides Math APIs in .NET applications.
// - Build tools that need to monitor or log MathML generation times.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Diagnostics;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace MathMlExportPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a Math shape to the first slide
            IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Get the MathParagraph from the shape
            IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build a simple equation: a + b = c
            mathParagraph.Add(
                new MathematicalText("a")
                .Join("+")
                .Join(new MathematicalText("b"))
                .Join("=")
                .Join(new MathematicalText("c"))
            );

            // Measure execution time of WriteAsMathMl
            Stopwatch stopwatch = new Stopwatch();
            try
            {
                stopwatch.Start();
                using (MemoryStream stream = new MemoryStream())
                {
                    mathParagraph.WriteAsMathMl(stream);
                }
                stopwatch.Stop();
                Console.WriteLine($"WriteAsMathMl execution time: {stopwatch.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during export
                Console.WriteLine($"Error during MathML export: {ex.Message}");
            }

            // Save the presentation
            try
            {
                presentation.Save("MathExport.pptx", SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Comment: format not supported
            }

            // Clean up
            presentation.Dispose();
        }
    }
}
