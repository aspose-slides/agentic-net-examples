// -----------------------------------------------------------------------------
// Example: Identify MathParagraphs in PowerPoint Shapes Using Aspose.Slides
//
// Description:
// This console application loads a PPTX file, iterates through all slides and
// shapes, and checks each shape's TextFrame for MathPortion objects to locate
// MathParagraph instances. It demonstrates using Aspose.Slides for .NET to
// analyze mathematical content within PowerPoint presentations and outputs
// findings to the console.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathPortion, MathParagraph, TextFrame
//
// Use Cases:
// - Detect and list all mathematical equations embedded in a presentation.
// - Prepare a report of slides containing math content for review.
// - Automate validation of presentation assets before publishing.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMathParagraphFinder
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: File not found - " + inputPath);
                return;
            }

            try
            {
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                {
                    foreach (Aspose.Slides.IShape shape in slide.Shapes)
                    {
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null)
                        {
                            foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                            {
                                foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                                {
                                    Aspose.Slides.MathText.IMathPortion mathPortion = portion as Aspose.Slides.MathText.IMathPortion;
                                    if (mathPortion != null)
                                    {
                                        Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                        Console.WriteLine(
                                            $"Found MathParagraph on Slide {slide.SlideNumber}, Shape \"{shape.Name}\".");
                                    }
                                }
                            }
                        }
                    }
                }

                // Save the presentation (optional, here we just rewrite the same file)
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
