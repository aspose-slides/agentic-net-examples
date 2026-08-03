// -----------------------------------------------------------------------------
// Example: Close filestream after WriteAsMathMl failure using C#
//
// Description:
// Demonstrates how to safely close a FileStream after attempting to write MathML
// using Aspose.Slides for .NET. The example creates a presentation, adds a
// mathematical equation to a slide, writes the equation as MathML to a file with
// proper resource cleanup, and saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML, WriteAsMathMl, FileStream,
// Close, Resource Cleanup, Math Equations, Presentation Processing
//
// Use Cases:
// - Ensure FileStream is closed after WriteAsMathMl operation, even on failure.
// - Automate creation of PowerPoint slides containing mathematical equations.
// - Export mathematical content to MathML for interoperability.
// - Build robust .NET tools for PowerPoint and MathML handling.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace AsposeSlidesMathExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Add a math shape to the first slide
            IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);
            IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

            // Create a MathBlock using the parameterless constructor to avoid ambiguous overload
            MathBlock mathBlock = new MathBlock();
            // Add mathematical elements to the block
            mathBlock.Add(new MathematicalText("c"));
            mathBlock.Add(new MathematicalText("^"));
            mathBlock.Add(new MathematicalText("2"));
            mathBlock.Add(new MathematicalText("="));
            mathBlock.Add(new MathematicalText("a"));
            mathBlock.Add(new MathematicalText("^"));
            mathBlock.Add(new MathematicalText("2"));
            mathBlock.Add(new MathematicalText("+"));
            mathBlock.Add(new MathematicalText("b"));
            mathBlock.Add(new MathematicalText("^"));
            mathBlock.Add(new MathematicalText("2"));

            // Add the block to the paragraph
            mathParagraph.Add(mathBlock);

            // Write MathML to a file with proper resource cleanup
            string mathMlPath = "mathml.xml";
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(mathMlPath, FileMode.Create, FileAccess.Write);
                // Write the MathBlock as MathML
                mathBlock.WriteAsMathMl(fileStream);
            }
            finally
            {
                // Ensure the stream is closed even if WriteAsMathMl throws
                if (fileStream != null)
                {
                    fileStream.Close();
                }
            }

            // Save the presentation
            try
            {
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle format not supported or other save errors
                // Format not supported
            }
        }
    }
}
