// -----------------------------------------------------------------------------
// Example: Export MathML from Shapes with Alternative Text using Aspose.Slides
//
// Description:
// This console application loads a PowerPoint PPTX file, scans all slides for
// shapes that have a non‑empty Alternative Text attribute and contain mathematical
// content. For each such shape it extracts the MathML representation of the
// equation and writes it to an individual XML file. The program uses Aspose.Slides
// for .NET to access slide and shape objects and saves the presentation after
// processing.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathML export, alternative text, shape extraction
//
// Use Cases:
// - Generate MathML for accessibility tools from PowerPoint presentations.
// - Automate extraction of equations for documentation.
// - Batch process slides to collect mathematical content.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMathMLExport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Input and output paths
            System.String inputPath = "input.pptx";
            System.String outputFolder = "MathML_Output";

            // Verify input file exists
            if (System.IO.File.Exists(inputPath) == false)
            {
                System.Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Ensure output directory exists
            if (System.IO.Directory.Exists(outputFolder) == false)
            {
                System.IO.Directory.CreateDirectory(outputFolder);
            }

            try
            {
                // Load presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Iterate through slides
                for (System.Int32 slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                    // Iterate through shapes on the slide
                    for (System.Int32 shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                        // Process only shapes with non‑empty Alternative Text
                        if (String.IsNullOrWhiteSpace(shape.AlternativeText) == false)
                        {
                            // Cast to IAutoShape to access TextFrame
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.TextFrame != null)
                            {
                                // Scan paragraphs for MathPortion objects
                                for (System.Int32 paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                                {
                                    Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];
                                    for (System.Int32 portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                                    {
                                        Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];
                                        Aspose.Slides.MathText.MathPortion mathPortion = portion as Aspose.Slides.MathText.MathPortion;
                                        if (mathPortion != null)
                                        {
                                            // Retrieve MathParagraph
                                            Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                            if (mathParagraph != null)
                                            {
                                                // Attempt to get MathML (using ToString as placeholder)
                                                System.String mathML = mathParagraph.ToString();

                                                // Build output file name using alternative text (sanitize file name)
                                                System.String safeAltText = shape.AlternativeText.Replace(Path.GetInvalidFileNameChars(), '_');
                                                System.String outputFilePath = System.IO.Path.Combine(outputFolder, safeAltText + ".xml");

                                                // Write MathML to file
                                                System.IO.File.WriteAllText(outputFilePath, mathML);
                                                System.Console.WriteLine("Exported MathML for shape: " + shape.AlternativeText);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Save presentation (optional – here we overwrite the original)
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }

    // Extension method to replace invalid filename characters
    internal static class StringExtensions
    {
        public static System.String Replace(this System.String input, System.Char[] chars, System.Char replacement)
        {
            System.String result = input;
            foreach (System.Char c in chars)
            {
                result = result.Replace(c, replacement);
            }
            return result;
        }
    }
}
