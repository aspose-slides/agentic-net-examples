// -----------------------------------------------------------------------------
// Example: Ensure WriteAsMathMl does not modify original using C#
//
// Description:
// Demonstrates how to export a MathParagraph to MathML using Aspose.Slides for .NET 
// without altering the original presentation. The example creates a simple 
// mathematical equation, writes it to a MathML file, and then saves the unchanged 
// presentation as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Ensure, WriteAsMathMl, Does, 
// Modify, Presentation Processing, Office Automation, MathML, MathParagraph, MathShape
//
// Use Cases:
// - Export mathematical equations from a presentation to MathML while preserving the source.
// - Build C# utilities for PowerPoint math content extraction.
// - Integrate MathML generation into .NET applications without affecting original files.
// - Validate that MathML export does not modify presentation data.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        try
        {
            using (var presentation = new Aspose.Slides.Presentation())
            {
                // Add a mathematical shape to the first slide
                var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);

                // Retrieve the MathParagraph from the first portion
                var mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Build a simple equation: a + b = c
                mathParagraph.Add(
                    new Aspose.Slides.MathText.MathematicalText("a")
                    .Join("+")
                    .Join(new Aspose.Slides.MathText.MathematicalText("b"))
                    .Join("=")
                    .Join(new Aspose.Slides.MathText.MathematicalText("c"))
                );

                // Export the MathParagraph to MathML without modifying the presentation
                using (var stream = new FileStream("equation.xml", FileMode.Create, FileAccess.Write))
                {
                    mathParagraph.WriteAsMathMl(stream);
                }

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception)
        {
            // Handle other exceptions (e.g., external URL failures)
        }
    }
}
