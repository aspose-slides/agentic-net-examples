using System;
using System.IO;

namespace ExportMathToPng
{
    class Program
    {
        static void Main(string[] args)
        {
            // Output file paths
            System.String outputPptx = Path.Combine("Data", "output_math.pptx");
            System.String outputPng = Path.Combine("Data", "math_equation.png");

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Add a math shape to host the equation
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddMathShape(50, 50, 400, 100);

            // Get the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)shape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the equation: a + b = c
            Aspose.Slides.MathText.MathBlock block = new Aspose.Slides.MathText.MathBlock(new Aspose.Slides.MathText.MathematicalText("a"));
            block = (Aspose.Slides.MathText.MathBlock)block.Join("+");
            block = (Aspose.Slides.MathText.MathBlock)block.Join(new Aspose.Slides.MathText.MathematicalText("b"));
            block = (Aspose.Slides.MathText.MathBlock)block.Join("=");
            block = (Aspose.Slides.MathText.MathBlock)block.Join(new Aspose.Slides.MathText.MathematicalText("c"));

            // Add the constructed block to the paragraph
            mathParagraph.Add(block);

            // Export the shape as a high‑resolution PNG (scale factor 3)
            System.Int32 scaleX = 3;
            System.Int32 scaleY = 3;
            Aspose.Slides.IImage shapeImage = shape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, scaleX, scaleY);
            shapeImage.Save(outputPng, Aspose.Slides.ImageFormat.Png);

            // Save the presentation
            pres.Save(outputPptx, Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}