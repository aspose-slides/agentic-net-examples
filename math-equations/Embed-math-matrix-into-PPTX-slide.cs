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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide as ISlide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a math shape to host the matrix
                Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 500, 100);

                // Retrieve the math paragraph from the shape
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Create a 2x2 matrix
                Aspose.Slides.MathText.IMathMatrix matrix = new Aspose.Slides.MathText.MathMatrix(2, 2);
                matrix[0, 0] = new Aspose.Slides.MathText.MathematicalText("a");
                matrix[0, 1] = new Aspose.Slides.MathText.MathematicalText("b");
                matrix[1, 0] = new Aspose.Slides.MathText.MathematicalText("c");
                matrix[1, 1] = new Aspose.Slides.MathText.MathematicalText("d");

                // Wrap the matrix in a MathBlock and add to the paragraph
                Aspose.Slides.MathText.MathBlock matrixBlock = new Aspose.Slides.MathText.MathBlock(matrix);
                mathParagraph.Add(matrixBlock);

                // Save the presentation
                presentation.Save("MatrixPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}