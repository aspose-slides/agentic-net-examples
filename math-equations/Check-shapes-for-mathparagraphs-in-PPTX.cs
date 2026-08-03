// -----------------------------------------------------------------------------
// Example: Check shapes for mathparagraphs in PPTX using C#
//
// Description:
// Demonstrates how to iterate through slides and shapes in a PPTX file to
// detect MathParagraphs within MathPortions using Aspose.Slides for .NET.
// The example loads a presentation, examines each AutoShape's text for
// mathematical content, outputs details about found MathParagraphs, and
// saves the presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Check, Shapes, MathParagraphs,
// MathPortion, Presentation Processing, Office Automation
//
// Use Cases:
// - Identify and report MathParagraphs embedded in slide shapes.
// - Build validation tools for mathematical content in PowerPoint files.
// - Automate extraction of math equation metadata from PPTX presentations.
// - Integrate math detection into .NET applications that process slides.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        Presentation presentation = null;
        try
        {
            presentation = new Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or loading errors
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Iterate through slides and shapes
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            ISlide slide = presentation.Slides[slideIndex];
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                IShape shape = slide.Shapes[shapeIndex];
                IAutoShape autoShape = shape as IAutoShape;
                if (autoShape == null || autoShape.TextFrame == null)
                {
                    continue;
                }

                ITextFrame textFrame = autoShape.TextFrame;
                for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                {
                    IParagraph paragraph = textFrame.Paragraphs[paraIndex];
                    for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                    {
                        IPortion portion = paragraph.Portions[portionIndex];
                        MathPortion mathPortion = portion as MathPortion;
                        if (mathPortion != null)
                        {
                            IMathParagraph mathParagraph = mathPortion.MathParagraph;
                            // Example: output number of blocks in the math paragraph
                            Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}, Paragraph {paraIndex + 1}, Portion {portionIndex + 1} contains MathParagraph with {mathParagraph.Count} blocks.");
                        }
                    }
                }
            }
        }

        // Save the presentation (could be same or new file)
        string outputPath = "output.pptx";
        try
        {
            presentation.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle save errors
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
    }
}
