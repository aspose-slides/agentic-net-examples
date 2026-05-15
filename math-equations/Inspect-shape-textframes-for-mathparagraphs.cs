using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main(string[] args)
    {
        // Input presentation path (default or from command line)
        string inputPath = "input.pptx";
        if (args.Length > 0)
        {
            inputPath = args[0];
        }

        // Verify that the file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("File does not exist: " + inputPath);
            return;
        }

        // Load the presentation with exception handling for unsupported formats
        Aspose.Slides.Presentation presentation = null;
        try
        {
            presentation = new Aspose.Slides.Presentation(inputPath);
        }
        catch (Exception ex)
        {
            // format not supported
            Console.WriteLine("Failed to load presentation: " + ex.Message);
            return;
        }

        // Iterate through all slides
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

                // Process only AutoShapes that contain a TextFrame
                if (autoShape == null || autoShape.TextFrame == null)
                {
                    continue;
                }

                Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

                // Iterate through paragraphs
                for (int paraIndex = 0; paraIndex < textFrame.Paragraphs.Count; paraIndex++)
                {
                    Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[paraIndex];

                    // Iterate through portions
                    for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                    {
                        Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];
                        Aspose.Slides.MathText.MathPortion mathPortion = portion as Aspose.Slides.MathText.MathPortion;

                        // Identify MathPortion and retrieve its MathParagraph
                        if (mathPortion != null)
                        {
                            Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;
                            Console.WriteLine($"Slide {slideIndex}, Shape {shapeIndex}, Paragraph {paraIndex}, Portion {portionIndex} contains MathParagraph with {mathParagraph.Count} blocks.");
                        }
                    }
                }
            }
        }

        // Save the presentation before exiting
        string outputPath = "output.pptx";
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
        }
    }
}