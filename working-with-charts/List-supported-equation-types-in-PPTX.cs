using System;
using System.IO;
using Aspose.Slides.Export;

namespace MathEquationIdentifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath;
            if (args.Length > 0)
            {
                inputPath = args[0];
            }
            else
            {
                inputPath = "input.pptx";
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
                {
                    for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                    {
                        Aspose.Slides.ISlide slide = pres.Slides[slideIndex];
                        for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                        {
                            Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                            {
                                Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                                if (paragraph.Portions.Count > 0)
                                {
                                    Aspose.Slides.IPortion portion = paragraph.Portions[0];
                                    Aspose.Slides.MathText.MathPortion mathPortion = portion as Aspose.Slides.MathText.MathPortion;
                                    if (mathPortion != null)
                                    {
                                        Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                        string latex = mathParagraph.ToLatex();
                                        Console.WriteLine("Slide " + slideIndex + ", Shape " + shapeIndex + " LaTeX: " + latex);
                                    }
                                }
                            }
                        }
                    }

                    string outputPath = "output.pptx";
                    pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                    Console.WriteLine("Presentation saved to: " + outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}