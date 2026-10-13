// -----------------------------------------------------------------------------
// Example: Export Math Equation to LaTeX or MathML using Aspose.Slides
//
// Description:
// This console application creates a PowerPoint presentation containing a
// simple mathematical equation (a + b = c) using Aspose.Slides for .NET. Based on
// a command‑line argument it exports the equation either as a LaTeX string or
// as MathML and writes the result to a file. The generated presentation is saved
// as a PPTX file for verification.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, LaTeX, export, math paragraph
//
// Use Cases:
// - Generate LaTeX representations of equations embedded in PPTX files.
// - Convert PowerPoint math objects to MathML for web publishing.
// - Automate documentation pipelines that require both PPTX and markup formats.
// Tested and Verified with Aspose.Slides for .NET v26.10.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Usage: ExportMath <latex|mathml> [outputFilePath]");
                return;
            }

            string exportMode = args[0].Trim().ToLowerInvariant();
            string outputPath = (args.Length > 1) ? args[1] : "ExportResult.txt";
            string presentationPath = "MathPresentation.pptx";

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a mathematical shape to the first slide
            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the MathParagraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the equation a + b = c
            Aspose.Slides.MathText.MathematicalText a = new Aspose.Slides.MathText.MathematicalText("a");
            Aspose.Slides.MathText.MathematicalText plus = new Aspose.Slides.MathText.MathematicalText("+");
            Aspose.Slides.MathText.MathematicalText b = new Aspose.Slides.MathText.MathematicalText("b");
            Aspose.Slides.MathText.MathematicalText equals = new Aspose.Slides.MathText.MathematicalText("=");
            Aspose.Slides.MathText.MathematicalText c = new Aspose.Slides.MathText.MathematicalText("c");

            mathParagraph.Add(a.Join(plus).Join(b).Join(equals).Join(c));

            // Export based on the requested mode
            if (exportMode == "latex")
            {
                string latex = mathParagraph.ToLatex();
                File.WriteAllText(outputPath, latex, Encoding.UTF8);
                Console.WriteLine($"LaTeX exported to '{outputPath}'.");
            }
            else if (exportMode == "mathml")
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    mathParagraph.WriteAsMathMl(ms);
                    ms.Position = 0;
                    using (StreamReader reader = new StreamReader(ms, Encoding.UTF8))
                    {
                        string mathMl = reader.ReadToEnd();
                        File.WriteAllText(outputPath, mathMl, Encoding.UTF8);
                        Console.WriteLine($"MathML exported to '{outputPath}'.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid export mode. Use 'latex' or 'mathml'.");
                return;
            }

            // Save the presentation for verification
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
            Console.WriteLine($"Presentation saved to '{presentationPath}'.");
        }
        catch (FileNotFoundException fnfEx)
        {
            Console.WriteLine($"File not found: {fnfEx.Message}");
        }
        catch (DirectoryNotFoundException dnfEx)
        {
            Console.WriteLine($"Directory not found: {dnfEx.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
