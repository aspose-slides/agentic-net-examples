using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string inputPath = "input.pptx";
        string outputPresPath = "output.pptx";
        string mathmlFolder = "MathML";

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist: " + inputPath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation(inputPath))
            {
                if (!Directory.Exists(mathmlFolder))
                {
                    Directory.CreateDirectory(mathmlFolder);
                }

                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    ISlide slide = pres.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        IShape shape = slide.Shapes[shapeIndex];
                        IAutoShape autoShape = shape as IAutoShape;
                        if (autoShape == null) continue;
                        if (autoShape.TextFrame == null) continue;
                        if (autoShape.TextFrame.Paragraphs.Count == 0) continue;
                        if (autoShape.TextFrame.Paragraphs[0].Portions.Count == 0) continue;

                        MathPortion mathPortion = autoShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion;
                        if (mathPortion == null) continue;

                        IMathParagraph mathParagraph = mathPortion.MathParagraph;
                        string mathmlPath = Path.Combine(mathmlFolder, $"slide_{slideIndex + 1}_shape_{shapeIndex + 1}.mathml");
                        using (FileStream fs = new FileStream(mathmlPath, FileMode.Create, FileAccess.Write))
                        {
                            mathParagraph.WriteAsMathMl(fs);
                        }

                        Console.WriteLine($"Slide {slideIndex + 1}, Shape '{shape.Name}', exported to {mathmlPath}");
                    }
                }

                pres.Save(outputPresPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The file format is not supported.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}