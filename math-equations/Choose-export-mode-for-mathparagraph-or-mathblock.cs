using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace MathExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine export mode from command‑line arguments
            string mode = (args.Length > 0) ? args[0].ToLowerInvariant() : "paragraph";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a math shape to the first slide
            IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the math paragraph from the shape
            IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build a simple equation a + b = c
            mathParagraph.Add(
                new MathematicalText("a")
                .Join(new MathematicalText("+"))
                .Join(new MathematicalText("b"))
                .Join(new MathematicalText("="))
                .Join(new MathematicalText("c"))
            );

            // Export based on selected mode
            if (mode == "paragraph")
            {
                // Export the whole math paragraph to LaTeX
                string latex = mathParagraph.ToLatex();
                Console.WriteLine("LaTeX output:");
                Console.WriteLine(latex);
            }
            else if (mode == "block")
            {
                // Export each individual math block (if any) to LaTeX
                for (int i = 0; i < mathParagraph.Count; i++)
                {
                    // Each block implements IMathBlock; cast to MathBlock to access its content
                    MathBlock block = mathParagraph[i] as MathBlock;
                    if (block != null)
                    {
                        // Create a temporary paragraph containing only this block to reuse ToLatex()
                        MathParagraph tempParagraph = new MathParagraph(block);
                        string blockLatex = tempParagraph.ToLatex();
                        Console.WriteLine($"Block {i} LaTeX: {blockLatex}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid mode specified. Use \"paragraph\" or \"block\".");
            }

            // Save the presentation
            try
            {
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "MathExportOutput.pptx");
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Dispose presentation
            presentation.Dispose();
        }
    }
}