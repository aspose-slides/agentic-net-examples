// -----------------------------------------------------------------------------
// Example: Skip mathblock on writeasmathml notsupportedexception using C#
//
// Description:
// Demonstrates how to iterate through MathBlocks in a MathShape, attempt to
// export each block to MathML, and gracefully skip those that throw a
// NotSupportedException. The example creates a presentation, adds a math
// shape with sample equations, processes the blocks, and saves the final
// presentation using Aspose.Slides for .NET.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Skip, MathBlock, WriteAsMathMl, 
// NotSupportedException, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate handling of MathML export where some MathBlocks are not supported.
// - Build C# utilities for processing mathematical content in PowerPoint files.
// - Generate or transform PPTX files while safely ignoring unsupported MathML blocks.
// - Validate and log presentation workflows involving math equations before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Add a math shape to the first slide
        Aspose.Slides.IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

        // Retrieve the math paragraph from the shape
        Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

        // Add sample math blocks
        mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("x")));
        mathParagraph.Add(new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("y")));

        // Iterate over each MathBlock and attempt to write it as MathML, skipping unsupported blocks
        for (int i = 0; i < mathParagraph.Count; i++)
        {
            Aspose.Slides.MathText.IMathBlock block = mathParagraph[i];
            try
            {
                using (FileStream fileStream = new FileStream($"Block{i}.xml", FileMode.Create, FileAccess.Write))
                {
                    block.WriteAsMathMl(fileStream);
                }
            }
            catch (NotSupportedException)
            {
                // Skip this block if MathML export is not supported
                continue;
            }
        }

        // Save the presentation
        presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
    }
}
