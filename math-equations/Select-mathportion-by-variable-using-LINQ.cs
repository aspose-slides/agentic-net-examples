// -----------------------------------------------------------------------------
// Example: Export Selected MathPortions Containing Variable to MathML Using LINQ
//
// Description:
// This console application creates a PowerPoint presentation, adds a math
// shape with an equation, uses LINQ to filter MathPortion objects whose text
// includes a specific variable (e.g., "x"), and exports each matching
// MathParagraph to a MathML file. It demonstrates Aspose.Slides for .NET,
// PPTX handling, and LINQ-based selection of mathematical content.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathPortion, LINQ, MathML export
//
// Use Cases:
// - Generate PPTX with equations and extract those containing certain symbols.
// - Automate documentation of math expressions that involve a particular variable.
// - Filter and export math content for further processing in scientific workflows.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare output directory
            string outputDir = "Output";
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Add a math shape to the first slide
            Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

            // Retrieve the MathPortion from the shape
            Aspose.Slides.MathText.MathPortion mathPortion = (Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0];

            // Build a simple equation: a*x + b = c
            Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;
            mathParagraph.Add(
                new Aspose.Slides.MathText.MathematicalText("a")
                .Join(new Aspose.Slides.MathText.MathematicalText("*"))
                .Join(new Aspose.Slides.MathText.MathematicalText("x"))
                .Join(new Aspose.Slides.MathText.MathematicalText("+"))
                .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                .Join(new Aspose.Slides.MathText.MathematicalText("="))
                .Join(new Aspose.Slides.MathText.MathematicalText("c"))
            );

            // Use LINQ to select MathPortion objects whose text contains the variable "x"
            System.Collections.Generic.IEnumerable<Aspose.Slides.MathText.MathPortion> matchingPortions =
                presentation.Slides[0].Shapes
                    .OfType<Aspose.Slides.IAutoShape>()
                    .SelectMany(shape => shape.TextFrame.Paragraphs)
                    .SelectMany(paragraph => paragraph.Portions)
                    .OfType<Aspose.Slides.MathText.MathPortion>()
                    .Where(portion => portion.Text != null && portion.Text.Contains("x"));

            // Export each matching MathParagraph to a MathML file
            int index = 0;
            foreach (Aspose.Slides.MathText.MathPortion portion in matchingPortions)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    Aspose.Slides.MathText.IMathParagraph paragraph = portion.MathParagraph;
                    paragraph.WriteAsMathMl(stream);
                    stream.Position = 0;

                    string filePath = Path.Combine(outputDir, $"MathPortion_{index}.xml");
                    using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        stream.CopyTo(file);
                    }
                }
                index++;
            }

            // Save the presentation
            string presentationPath = Path.Combine(outputDir, "MathExample.pptx");
            presentation.Save(presentationPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
