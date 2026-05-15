using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace FindMathPortion
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputPath = "input.pptx";
            string outputPath = "output.pptx";

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file does not exist: " + inputPath);
                return;
            }

            try
            {
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    Aspose.Slides.ISlideCollection slides = presentation.Slides;
                    for (int i = 0; i < slides.Count; i++)
                    {
                        Aspose.Slides.ISlide slide = slides[i];
                        Aspose.Slides.IShapeCollection shapes = slide.Shapes;
                        for (int j = 0; j < shapes.Count; j++)
                        {
                            Aspose.Slides.IShape shape = shapes[j];
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.TextFrame != null)
                            {
                                Aspose.Slides.IParagraphCollection paragraphs = autoShape.TextFrame.Paragraphs;
                                for (int p = 0; p < paragraphs.Count; p++)
                                {
                                    Aspose.Slides.IParagraph paragraph = paragraphs[p];
                                    Aspose.Slides.IPortionCollection portions = paragraph.Portions;
                                    for (int q = 0; q < portions.Count; q++)
                                    {
                                        Aspose.Slides.IPortion portion = portions[q];
                                        Aspose.Slides.MathText.MathPortion mathPortion = portion as Aspose.Slides.MathText.MathPortion;
                                        if (mathPortion != null)
                                        {
                                            Console.WriteLine($"Slide {i + 1}, Shape {j + 1} contains MathPortion with text: {mathPortion.Text}");
                                            string latex = mathPortion.MathParagraph.ToLatex();
                                            Console.WriteLine("LaTeX: " + latex);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save presentation before exit
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Aspose.Slides.PptxUnsupportedFormatException)
            {
                // Format not supported
                Console.WriteLine("The presentation format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., file read errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}