using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPath = "output.pptx";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (var presentation = new Presentation(inputPath))
            {
                foreach (var slide in presentation.Slides)
                {
                    foreach (var shape in slide.Shapes)
                    {
                        if (shape is IAutoShape autoShape && autoShape.TextFrame != null)
                        {
                            foreach (var paragraph in autoShape.TextFrame.Paragraphs)
                            {
                                foreach (var portion in paragraph.Portions)
                                {
                                    var mathPortion = portion as MathPortion;
                                    if (mathPortion != null)
                                    {
                                        Console.WriteLine($"Found MathPortion on slide {slide.SlideNumber}");
                                        var mathParagraph = mathPortion.MathParagraph;
                                        // Additional processing of mathParagraph can be done here
                                    }
                                }
                            }
                        }
                    }
                }

                presentation.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}