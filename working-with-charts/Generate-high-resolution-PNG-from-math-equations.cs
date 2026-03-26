using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

public class Program
{
    public static void Main()
    {
        // Output file paths
        string outPptx = "MathEquation.pptx";
        string outPng = "MathEquation.png";

        // Create a new presentation and add a mathematical equation
        using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
        {
            // Add a rectangle shape to host the equation
            Aspose.Slides.IAutoShape mathShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

            // Retrieve the math paragraph from the shape
            Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            // Build the equation: c² = a² + b²
            Aspose.Slides.MathText.IMathElement elementC = new Aspose.Slides.MathText.MathematicalText("c");
            Aspose.Slides.MathText.IMathBlock mathBlock = new Aspose.Slides.MathText.MathBlock(elementC);
            mathBlock.SetSuperscript("2")
                     .Join("=")
                     .Join(new Aspose.Slides.MathText.MathematicalText("a").SetSuperscript("2"))
                     .Join("+")
                     .Join(new Aspose.Slides.MathText.MathematicalText("b").SetSuperscript("2"));

            // Add the block to the paragraph
            mathParagraph.Add(mathBlock);

            // Save the presentation (required before exporting images)
            pres.Save(outPptx, Aspose.Slides.Export.SaveFormat.Pptx);
        }

        // Verify that the presentation file exists before exporting
        if (File.Exists(outPptx))
        {
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation(outPptx))
            {
                // High‑resolution scaling factor (e.g., 2×)
                float scaleFactor = 2f;

                // Export the first slide as a high‑resolution PNG
                using (Aspose.Slides.IImage image = pres.Slides[0].GetImage(scaleFactor, scaleFactor))
                {
                    image.Save(outPng, Aspose.Slides.ImageFormat.Png);
                }
            }
        }
        else
        {
            Console.WriteLine("Error: Presentation file not found - " + outPptx);
        }
    }
}