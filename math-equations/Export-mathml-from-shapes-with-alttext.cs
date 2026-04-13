using System;
using System.IO;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

class Program
{
    static void Main()
    {
        var inputPath = "input.pptx";
        var outputDir = "output";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file not found.");
            return;
        }

        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            var pres = new Aspose.Slides.Presentation(inputPath);

            foreach (var slide in pres.Slides)
            {
                foreach (var shape in slide.Shapes)
                {
                    if (!string.IsNullOrEmpty(shape.AlternativeText))
                    {
                        var autoShape = shape as Aspose.Slides.IAutoShape;
                        if (autoShape != null && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                        {
                            var portion = autoShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion;
                            if (portion != null)
                            {
                                var mathParagraph = portion.MathParagraph;
                                var outPath = Path.Combine(outputDir, $"{shape.AlternativeText}.xml");
                                using (var stream = new FileStream(outPath, FileMode.Create, FileAccess.Write))
                                {
                                    mathParagraph.WriteAsMathMl(stream);
                                }
                            }
                        }
                    }
                }
            }

            pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other exceptions
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}