// -----------------------------------------------------------------------------
// Example: Create dynamic table of contents using C#
//
// Description:
// Demonstrates how to generate a PowerPoint presentation with a dynamic
// Table of Contents (TOC) slide using Aspose.Slides for .NET. The example
// creates sample slides, inserts a TOC slide, populates it with slide titles,
// reorders slides, and updates the TOC to reflect the new order. It can be
// used as a standalone console application for automating PPTX workflows.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, Table of Contents, Dynamic TOC,
// Slide Reordering, Presentation Automation, Office Automation
//
// Use Cases:
// - Automatically generate a TOC for newly created presentations.
// - Update TOC after slide reordering or content changes.
// - Build .NET tools that manipulate PowerPoint files programmatically.
// - Validate presentation structure before publishing or integration.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace DynamicTocExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to save the presentation
            string outputPath = "DynamicTocPresentation.pptx";

            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Add a few sample slides with titles
                    for (int i = 1; i <= 5; i++)
                    {
                        ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides[0]);
                        // Add title shape
                        IAutoShape titleShape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 600, 50);
                        titleShape.AddTextFrame("Slide " + i + " Title");
                        titleShape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;
                    }

                    // Insert Table of Contents slide at the beginning
                    ISlide tocSlide = pres.Slides.InsertEmptySlide(0, pres.LayoutSlides[0]);
                    // Add TOC title
                    IAutoShape tocTitle = (IAutoShape)tocSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 30, 600, 50);
                    tocTitle.AddTextFrame("Table of Contents");
                    tocTitle.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Center;

                    // Initial TOC population
                    UpdateTableOfContents(pres, tocSlide);

                    // Reorder some slides (move slide 5 to position 2)
                    // After inserting the TOC, slide indices are: 0=TOC, 1-5=content slides
                    // Move slide at index 5 (original slide 5) to index 2
                    pres.Slides.Reorder(5, 2);

                    // Update TOC after reordering
                    UpdateTableOfContents(pres, tocSlide);

                    // Save the presentation
                    pres.Save(outputPath, SaveFormat.Pptx);
                }
            }
            catch (PptxUnsupportedFormatException ex)
            {
                // Handle unsupported PPTX format
                Console.WriteLine("Unsupported PPTX format: " + ex.Message);
            }
            catch (PptUnsupportedFormatException ex)
            {
                // Handle unsupported PPT format
                Console.WriteLine("Unsupported PPT format: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // Updates the Table of Contents slide with current slide order
        private static void UpdateTableOfContents(Presentation pres, ISlide tocSlide)
        {
            // Remove existing TOC entries (keep the title shape at index 0)
            while (tocSlide.Shapes.Count > 1)
            {
                tocSlide.Shapes.RemoveAt(1);
            }

            // Add entry for each slide except the TOC slide itself
            for (int i = 1; i < pres.Slides.Count; i++)
            {
                ISlide slide = pres.Slides[i];
                // Create a textbox for the entry
                IAutoShape entryShape = (IAutoShape)tocSlide.Shapes.AddAutoShape(
                    ShapeType.Rectangle,
                    50,
                    100 + (i - 1) * 30,
                    600,
                    30);
                entryShape.AddTextFrame(string.Format("{0}. {1}", i, GetSlideTitle(slide)));
                entryShape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = TextAlignment.Left;
            }
        }

        // Retrieves the title text of a slide (first shape with text)
        private static string GetSlideTitle(ISlide slide)
        {
            foreach (IShape shape in slide.Shapes)
            {
                if (shape is IAutoShape autoShape && autoShape.TextFrame != null && autoShape.TextFrame.Text != null && autoShape.TextFrame.Text.Length > 0)
                {
                    return autoShape.TextFrame.Text;
                }
            }
            return "Untitled";
        }
    }
}
