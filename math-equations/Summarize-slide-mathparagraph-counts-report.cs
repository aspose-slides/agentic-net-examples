// -----------------------------------------------------------------------------
// Example: Generate Summary Report of MathParagraphs per Slide in PowerPoint using Aspose.Slides
//
// Description:
// This console application loads a PowerPoint PPTX file, iterates through each slide,
// and counts the number of MathParagraph objects found within MathPortion elements.
// It uses Aspose.Slides for .NET to access slide, shape, paragraph, and portion APIs,
// handling missing files and unsupported formats gracefully. The result is printed
// to the console, and the presentation is saved before the program exits.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, MathParagraph, MathPortion, slide analysis
//
// Use Cases:
// - Auditing presentations for mathematical content before publishing.
// - Generating reports on the distribution of equations across slides.
// - Validating that slides contain the expected number of math expressions.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;

namespace AsposeSlidesMathParagraphReport
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Error: The file '" + inputPath + "' does not exist.");
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                // If the format is not supported, Aspose may throw a specific exception.
                // For simplicity, we treat any exception as a format issue here.
                Console.WriteLine("The file format may not be supported.");
                return;
            }

            int slideCount = presentation.Slides.Count;
            for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
            {
                Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                int mathParagraphCount = 0;

                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                    if (autoShape != null && autoShape.TextFrame != null)
                    {
                        foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                        {
                            foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                            {
                                Aspose.Slides.MathText.MathPortion mathPortion = portion as Aspose.Slides.MathText.MathPortion;
                                if (mathPortion != null && mathPortion.MathParagraph != null)
                                {
                                    mathParagraphCount++;
                                }
                            }
                        }
                    }
                }

                Console.WriteLine("Slide " + (slideIndex + 1) + ": " + mathParagraphCount + " MathParagraph(s)");
            }

            try
            {
                presentation.Save(inputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving presentation: " + ex.Message);
            }
        }
    }
}
