using System;
using System.IO;
using Aspose.Slides.Export;

namespace ImportPptxEquations
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");

                // Load the presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath))
                {
                    // Iterate through all slides
                    foreach (Aspose.Slides.ISlide slide in presentation.Slides)
                    {
                        // Iterate through all shapes on the slide
                        foreach (Aspose.Slides.IShape shape in slide.Shapes)
                        {
                            // Process only AutoShape objects that contain a TextFrame
                            Aspose.Slides.IAutoShape autoShape = shape as Aspose.Slides.IAutoShape;
                            if (autoShape != null && autoShape.TextFrame != null)
                            {
                                // Iterate through paragraphs
                                foreach (Aspose.Slides.IParagraph paragraph in autoShape.TextFrame.Paragraphs)
                                {
                                    // Iterate through portions
                                    foreach (Aspose.Slides.IPortion portion in paragraph.Portions)
                                    {
                                        // Identify MathPortion instances
                                        Aspose.Slides.MathText.MathPortion mathPortion = portion as Aspose.Slides.MathText.MathPortion;
                                        if (mathPortion != null)
                                        {
                                            // Retrieve the MathParagraph and convert to LaTeX
                                            Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;
                                            string latex = mathParagraph.ToLatex();

                                            // Output LaTeX string (or further processing)
                                            Console.WriteLine(latex);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Save the (potentially modified) presentation before exiting
                    presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during processing
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}