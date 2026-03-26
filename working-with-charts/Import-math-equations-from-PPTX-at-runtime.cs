using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

class Program
{
    static void Main(string[] args)
    {
        // Path to the input PPTX file
        string inputPath = "input.pptx";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("The specified input file does not exist.");
            return;
        }

        // Load the presentation from the file
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

        // Iterate through all slides in the presentation
        for (int slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
        {
            Aspose.Slides.ISlide slide = presentation.Slides[slideIndex];

            // Iterate through all shapes on the current slide
            for (int shapeIndex = 0; shapeIndex < slide.Shapes.Count; shapeIndex++)
            {
                Aspose.Slides.IShape shape = slide.Shapes[shapeIndex];

                // Process only AutoShape objects that may contain mathematical content
                if (shape is Aspose.Slides.IAutoShape)
                {
                    Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)shape;

                    // Ensure the shape has a text frame with at least one paragraph and portion
                    if (autoShape.TextFrame != null &&
                        autoShape.TextFrame.Paragraphs.Count > 0 &&
                        autoShape.TextFrame.Paragraphs[0].Portions.Count > 0)
                    {
                        // Attempt to cast the first portion to a MathPortion
                        Aspose.Slides.MathText.MathPortion mathPortion = autoShape.TextFrame.Paragraphs[0].Portions[0] as Aspose.Slides.MathText.MathPortion;

                        if (mathPortion != null)
                        {
                            // Retrieve the mathematical paragraph associated with the MathPortion
                            Aspose.Slides.MathText.IMathParagraph mathParagraph = mathPortion.MathParagraph;

                            // Export the equation to LaTeX format
                            string latex = mathParagraph.ToLatex();

                            // Output the LaTeX string
                            Console.WriteLine($"Slide {slideIndex + 1}, Shape {shapeIndex + 1}: {latex}");
                        }
                    }
                }
            }
        }

        // Save the (potentially modified) presentation before exiting
        string outputPath = "output.pptx";
        presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
    }
}