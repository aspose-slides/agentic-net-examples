// -----------------------------------------------------------------------------
// Example: Select mathportions with variable using LINQ using C#
//
// Description:
// Demonstrates how to load a PowerPoint presentation, select MathPortion
// objects whose text contains a specific variable using LINQ, output their
// LaTeX representation, and save the presentation using Aspose.Slides for .NET.
// The example is a self‑contained console application suitable for automating
// PPTX workflows that involve mathematical equations.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Select, MathPortion, Variable,
// LINQ, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate extraction of mathematical portions containing a given variable.
// - Build C# tools for analyzing or transforming equations in PowerPoint files.
// - Generate reports of LaTeX strings from PPTX presentations.
// - Validate or modify presentations that include math equations before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";
        string variable = "x";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        Aspose.Slides.Presentation pres = null;
        try
        {
            pres = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Select MathPortion objects whose Text contains the specified variable
        List<Aspose.Slides.MathText.MathPortion> mathPortions = pres.Slides
            .SelectMany(slide => slide.Shapes)
            .OfType<Aspose.Slides.IAutoShape>()
            .SelectMany(shape => shape.TextFrame != null ? shape.TextFrame.Paragraphs : Enumerable.Empty<Aspose.Slides.IParagraph>())
            .SelectMany(paragraph => paragraph.Portions)
            .OfType<Aspose.Slides.MathText.MathPortion>()
            .Where(portion => !string.IsNullOrEmpty(portion.Text) && portion.Text.Contains(variable))
            .ToList();

        foreach (Aspose.Slides.MathText.MathPortion portion in mathPortions)
        {
            Aspose.Slides.MathText.IMathParagraph mathParagraph = portion.MathParagraph;
            string latex = mathParagraph.ToLatex();
            Console.WriteLine("LaTeX: " + latex);
        }

        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // format not supported
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
    }
}
