// -----------------------------------------------------------------------------
// Example: Remove hyperlink from text runs by keyword using C#
//
// Description:
// Demonstrates how to remove hyperlinks from text runs that contain a
// specific keyword using C# and Aspose.Slides for .NET. The example loads a
// PPTX presentation, scans all text portions for the given keyword, removes
// any associated click or mouse‑over hyperlinks, and saves the result.
// This pattern can be used to cleanse presentations of sensitive links.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Remove, Hyperlink, Text, Runs,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automatically strip hyperlinks from text containing confidential terms.
// - Build .NET utilities for sanitizing PowerPoint files before distribution.
// - Integrate hyperlink removal into larger presentation‑processing pipelines.
// - Ensure compliance by removing links from specific content in PPTX files.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RemoveHyperlinksByKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            // Expect input and output file paths as arguments
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: RemoveHyperlinksByKeyword <input.pptx> <output.pptx> [keyword]");
                return;
            }

            string inputPath = args[0];
            string outputPath = args[1];
            string keyword = args.Length >= 3 ? args[2] : "Sensitive";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine($"Input file not found: {inputPath}");
                return;
            }

            try
            {
                // Load the presentation
                using (Presentation presentation = new Presentation(inputPath))
                {
                    // Iterate through all slides
                    for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                    {
                        ISlide slide = presentation.Slides[slideIndex];

                        // Iterate through all shapes on the slide
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            IShape shape = slide.Shapes[shapeIndex];

                            // Process only shapes that contain a text frame
                            if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                            {
                                ITextFrame textFrame = autoShape.TextFrame;

                                // Iterate through paragraphs
                                for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                                {
                                    IParagraph paragraph = textFrame.Paragraphs[paraIndex];

                                    // Iterate through portions (text runs)
                                    for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                                    {
                                        IPortion portion = paragraph.Portions[portionIndex];

                                        if (portion.Text != null && portion.Text.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                                        {
                                            // Use the IHyperlinkManager interface to remove hyperlinks
                                            IHyperlinkManager hyperlinkMgr = portion.PortionFormat.HyperlinkManager;
                                            hyperlinkMgr.RemoveHyperlinkClick();
                                            hyperlinkMgr.RemoveHyperlinkMouseOver();
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the modified presentation
                    presentation.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported for PPTX
                Console.WriteLine("The input file format is not supported (PPTX).");
            }
            catch (Aspose.Slides.PptUnsupportedFormatException)
            {
                // Format not supported for PPT
                Console.WriteLine("The input file format is not supported (PPT).");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., network issues if URLs were used)
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
