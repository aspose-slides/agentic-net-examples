// -----------------------------------------------------------------------------
// Example: Enable autofit shrink on overflow for placeholders using C#
//
// Description:
// Demonstrates how to enable the autofit shrink‑on‑overflow behavior for
// placeholder AutoShapes that contain a TextFrame using Aspose.Slides for .NET.
// The program loads a PPTX file, iterates through all slides and shapes, sets
// the TextFrameFormat.AutofitType to Normal for applicable placeholders, and
// saves the updated presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Enable, Autofit, Shrink, Overflow,
// Placeholder, TextFrame, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate enabling autofit shrink on overflow for placeholder text in PPTX files.
// - Build .NET tools that adjust text fitting behavior in existing presentations.
// - Prepare presentations for consistent text layout before distribution.
// - Integrate placeholder text formatting into larger PowerPoint automation workflows.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program <input.pptx> <output.pptx>");
            return;
        }

        var inputPath = args[0];
        var outputPath = args[1];

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"Input file does not exist: {inputPath}");
            return;
        }

        try
        {
            // Load the presentation from the input file
            var presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through all slides
            foreach (var slide in presentation.Slides)
            {
                // Iterate through all shapes on the slide
                foreach (var shape in slide.Shapes)
                {
                    // Process only AutoShape placeholders that have a TextFrame
                    if (shape is Aspose.Slides.IAutoShape autoShape && autoShape.Placeholder != null && autoShape.TextFrame != null)
                    {
                        // Enable auto‑fit mode to shrink text on overflow
                        autoShape.TextFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Normal;
                    }
                }
            }

            // Save the modified presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
