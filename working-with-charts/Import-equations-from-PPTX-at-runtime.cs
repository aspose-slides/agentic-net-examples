using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

namespace MathEquationImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Input PPTX file path
            string inputPath = "input.pptx";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file not found: " + inputPath);
                return;
            }

            // Load the presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(inputPath))
            {
                // Iterate through all slides
                for (int slideIndex = 0; slideIndex < pres.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = pres.Slides[slideIndex];

                    // Iterate through all shapes on the slide
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;

                        // Process only AutoShapes that contain a MathPortion
                        if (autoShape != null && autoShape.TextFrame != null && autoShape.TextFrame.Paragraphs.Count > 0)
                        {
                            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];
                            if (paragraph.Portions.Count > 0 && paragraph.Portions[0] is Aspose.Slides.MathText.MathPortion)
                            {
                                Aspose.Slides.MathText.MathPortion mathPortion = (Aspose.Slides.MathText.MathPortion)paragraph.Portions[0];
                                Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;

                                // Export the mathematical equation to LaTeX format
                                string latex = mathParagraph.ToLatex();
                                Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1} LaTeX: {latex}");
                            }
                        }
                    }
                }

                // Save the (potentially unchanged) presentation
                string outputPath = "output.pptx";
                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
    }
}