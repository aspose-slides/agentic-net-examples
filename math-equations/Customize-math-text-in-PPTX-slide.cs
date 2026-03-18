using System;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Retrieve the first slide as ISlide (fixes CS0266)
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a math shape to the slide
                Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 500, 50);

                // Get the math paragraph from the shape
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Build a custom mathematical block: "E = m c²"
                Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock();
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("E"));
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText(" = "));
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("m"));
                // Add "c" with superscript "2"
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("c").SetSuperscript("2"));

                // Add the block to the math paragraph
                mathParagraph.Add(mathBlock);

                // Save the presentation
                pres.Save("CustomMath.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}