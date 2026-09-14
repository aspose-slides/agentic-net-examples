// -----------------------------------------------------------------------------
// Example: Extract Math Equations from PowerPoint using Aspose.Slides
//
// Description:
// This console application loads a PPTX file, iterates through all slides and
// shapes, extracts mathematical equations from MathPortion objects and prints
// their LaTeX representation. It uses Aspose.Slides for .NET to handle the
// PowerPoint format and demonstrates proper handling of math text APIs.
// Expected outcome is a list of LaTeX strings printed to the console.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Math extraction, LaTeX, IAutoShape, MathPortion
//
// Use Cases:
// - Automating extraction of equations from lecture slides for documentation.
// - Converting presentation math content to LaTeX for academic publishing.
// - Analyzing mathematical content across multiple presentations in batch jobs.
// Tested and Verified with Aspose.Slides for .NET v26.9.0.
// -----------------------------------------------------------------------------
using System;

namespace AsposeSlidesMathExtraction
{
    public class Program
    {
        public static void Main(string[] args)
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

            if (!System.IO.File.Exists(inputPath))
            {
                Console.WriteLine("Error: File not found - " + inputPath);
                return;
            }

            Aspose.Slides.Presentation presentation = null;
            try
            {
                presentation = new Aspose.Slides.Presentation(inputPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error loading presentation: " + ex.Message);
                return;
            }

            try
            {
                for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
                {
                    Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];
                    for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
                    {
                        Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];
                        if (shape is Aspose.Slides.IAutoShape)
                        {
                            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;
                            if (autoShape.TextFrame != null)
                            {
                                for (int paraIndex = 0; paraIndex < autoShape.TextFrame.Paragraphs.Count; paraIndex++)
                                {
                                    Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[paraIndex];
                                    for (int portionIndex = 0; portionIndex < paragraph.Portions.Count; portionIndex++)
                                    {
                                        Aspose.Slides.IPortion portion = paragraph.Portions[portionIndex];
                                        if (portion is Aspose.Slides.MathText.IMathPortion)
                                        {
                                            Aspose.Slides.MathText.MathPortion mathPortion = (Aspose.Slides.MathText.MathPortion)portion;
                                            Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                            string latex = mathParagraph.ToLatex();
                                            Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}, Equation: {latex}");
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Save a copy of the presentation (optional)
                string outputPath = "output.pptx";
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error during processing: " + ex.Message);
            }
            finally
            {
                if (presentation != null)
                {
                    presentation.Dispose();
                }
            }
        }
    }
}
