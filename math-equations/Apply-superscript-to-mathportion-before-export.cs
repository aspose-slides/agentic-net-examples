// -----------------------------------------------------------------------------
// Example: Apply superscript to mathportion before export using C#
//
// Description:
// Demonstrates how to apply superscript to a math portion before exporting a
// presentation using C# and Aspose.Slides for .NET. The example shows the
// required presentation-processing steps for PowerPoint files and produces the
// requested output in a standalone console application. Developers can use this
// pattern to automate PPTX workflows, validate results, or integrate presentation
// logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Superscript,
// Mathportion, Before, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying superscript to a math portion before export.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            string outputPath = "math_superscript.pptx";

            // Delete existing file if it exists
            if (File.Exists(outputPath))
            {
                try
                {
                    File.Delete(outputPath);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to delete existing file: " + ex.Message);
                }
            }

            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Add a math shape to the first slide
                    IAutoShape mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 400, 100);

                    // Retrieve the math paragraph from the first portion
                    IMathParagraph mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

                    // Create a superscript element: "c" with superscript "2"
                    IMathSuperscriptElement superscriptElement = new MathematicalText("c").SetSuperscript("2");

                    // Wrap the superscript element in a MathBlock
                    MathBlock superscriptBlock = new MathBlock(superscriptElement);

                    // Add the block to the math paragraph
                    mathParagraph.Add(superscriptBlock);

                    // Save the presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The requested file format is not supported.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
