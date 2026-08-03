// -----------------------------------------------------------------------------
// Example: Load PPTX presentation and extract math using C#
//
// Description:
// Demonstrates how to load a PPTX presentation, iterate through its slides and
// shapes, identify mathematical portions, convert the equations to LaTeX, and
// output the results using Aspose.Slides for .NET. The example also saves the
// (potentially unchanged) presentation, illustrating a complete workflow for
// PowerPoint math extraction in a console application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Extract, Math, LaTeX,
// Presentation, MathPortion, MathParagraph, Office Automation
//
// Use Cases:
// - Automate extraction of mathematical equations from PPTX files.
// - Build C# tools for processing PowerPoint presentations containing math.
// - Convert PowerPoint math equations to LaTeX for documentation or publishing.
// - Validate and transform PPTX content in .NET applications.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

namespace MathEquationExtractor
{
    class Program
    {
        static void Main()
        {
            // Path to the input PowerPoint file
            string inputPath = "input.pptx";

            // Verify that the file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                // Load the presentation from the specified file
                Presentation pres = new Presentation(inputPath);

                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    // Get the current slide
                    ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        // Cast the shape to IAutoShape to access TextFrame
                        IAutoShape autoShape = slide.Shapes[shapeIndex] as IAutoShape;
                        if (autoShape == null)
                        {
                            continue; // Not an AutoShape, skip
                        }

                        // Ensure the shape has a TextFrame with at least one paragraph and portion
                        if (autoShape.TextFrame == null ||
                            autoShape.TextFrame.Paragraphs.Count == 0 ||
                            autoShape.TextFrame.Paragraphs[0].Portions.Count == 0)
                        {
                            continue; // No text content, skip
                        }

                        // Attempt to treat the first portion as a MathPortion
                        MathPortion mathPortion = autoShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion;
                        if (mathPortion == null)
                        {
                            continue; // Not a mathematical portion, skip
                        }

                        // Retrieve the mathematical paragraph
                        IMathParagraph mathParagraph = mathPortion.MathParagraph;

                        // Convert the equation to LaTeX and output it
                        string latex = mathParagraph.ToLatex();
                        Console.WriteLine("Slide {0}, Shape {1}: {2}", slideIndex + 1, shapeIndex + 1, latex);
                    }
                }

                // Save the (potentially unchanged) presentation before exiting
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
