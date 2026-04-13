using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace MathExportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Determine export mode from command‑line arguments
            // "latex" – export whole MathParagraph to LaTeX
            // "mathml" – export each MathBlock as MathML
            string exportMode = (args.Length > 0) ? args[0].ToLowerInvariant() : "latex";

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a mathematical shape to the first slide
            IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the MathParagraph from the shape
            IMathParagraph mathParagraph = ((MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the equation a + b = c
            mathParagraph.Add(
                new MathematicalText("a")
                .Join(new MathematicalText("+"))
                .Join(new MathematicalText("b"))
                .Join(new MathematicalText("="))
                .Join(new MathematicalText("c"))
            );

            // Export based on selected mode
            if (exportMode == "latex")
            {
                // Export the whole MathParagraph to LaTeX
                string latexString = mathParagraph.ToLatex();
                Console.WriteLine("LaTeX output:");
                Console.WriteLine(latexString);
            }
            else if (exportMode == "mathml")
            {
                // Export each MathBlock as MathML into a file
                string mathMlPath = Path.Combine(Directory.GetCurrentDirectory(), "mathml_output.xml");
                try
                {
                    using (FileStream stream = new FileStream(mathMlPath, FileMode.Create, FileAccess.Write))
                    {
                        // Write the entire paragraph as MathML
                        mathParagraph.WriteAsMathMl(stream);
                    }
                    Console.WriteLine($"MathML written to {mathMlPath}");
                }
                catch (Exception ex)
                {
                    // Handle any I/O or format exceptions
                    Console.WriteLine($"Error writing MathML: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Invalid export mode. Use \"latex\" or \"mathml\".");
            }

            // Save the presentation before exiting
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "MathExportPresentation.pptx");
            try
            {
                presentation.Save(outputPath, SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved to {outputPath}");
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                // Format not supported
                Console.WriteLine($"Error saving presentation: {ex.Message}");
            }

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}