// -----------------------------------------------------------------------------
// Example: Find mathportions in PPTX slides using C#
//
// Description:
// Demonstrates how to locate MathPortion objects within PPTX slides using
// C# and Aspose.Slides for .NET. The example loads a presentation, scans each
// slide and shape for text portions that represent mathematical equations, 
// reports their locations, and saves the presentation.
//
// Keywords:
// C#, Aspose.Slides, PPTX, MathPortion, Find, PowerPoint, Presentation Processing,
// Office Automation, .NET
//
// Use Cases:
// - Detect and list mathematical equations in PowerPoint files.
// - Build tools that analyze or validate PPTX content for math expressions.
// - Integrate math detection into automated PowerPoint workflows.
// - Prepare presentations for further processing based on math content.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Iterate through each slide
            for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

                // Iterate through each shape on the slide
                for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                {
                    Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

                    // Check if the shape is an AutoShape with a TextFrame
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                        // Iterate through paragraphs and portions
                        foreach (Aspose.Slides.IParagraph paragraph in textFrame.Paragraphs)
                        {
                            foreach (Aspose.Slides.Portion portion in paragraph.Portions)
                            {
                                // Identify MathPortion objects
                                if (portion is Aspose.Slides.MathText.MathPortion)
                                {
                                    Console.WriteLine($"MathPortion found on slide {slideIndex + 1}, shape {shapeIndex + 1}");
                                }
                            }
                        }
                    }
                }
            }

            // Save the presentation before exiting
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
