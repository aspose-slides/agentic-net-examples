using System;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a math shape to the slide
                Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(50, 50, 400, 100);

                // Retrieve the math paragraph from the shape
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Create a math block with multiple elements
                Aspose.Slides.MathText.MathBlock mathBlock = new Aspose.Slides.MathText.MathBlock();
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("x"));
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("y"));
                mathBlock.Add(new Aspose.Slides.MathText.MathematicalText("z"));

                // Convert the math block into a vertical array
                Aspose.Slides.MathText.IMathArray mathArray = mathBlock.ToMathArray();

                // Add the resulting array to the math paragraph
                mathParagraph.Add((Aspose.Slides.MathText.IMathBlock)mathArray);

                // Save the presentation
                presentation.Save("MathArrayPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}