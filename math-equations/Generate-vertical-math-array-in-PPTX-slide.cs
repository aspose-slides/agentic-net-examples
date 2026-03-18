using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.MathText;

namespace MathArrayExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                var presentation = new Aspose.Slides.Presentation();

                // Add a math shape to host the equations
                var mathShape = presentation.Slides[0].Shapes.AddMathShape(0, 0, 720, 150);

                // Get the MathParagraph from the shape
                var mathParagraph = (mathShape.TextFrame.Paragraphs[0].Portions[0] as MathPortion).MathParagraph;

                // Create individual equations as MathBlocks
                var equation1 = new MathBlock(new MathematicalText("a = b + c"));
                var equation2 = new MathBlock(new MathematicalText("d = e - f"));
                var equation3 = new MathBlock(new MathematicalText("g = h \\times i"));

                // Add equations to the paragraph; they will appear vertically stacked
                mathParagraph.Add(equation1);
                mathParagraph.Add(equation2);
                mathParagraph.Add(equation3);

                // Save the presentation
                presentation.Save("MathArrayPresentation.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}