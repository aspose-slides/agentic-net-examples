using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide (use ISlide interface)
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a math shape to host the equation
                Aspose.Slides.IAutoShape mathShape = slide.Shapes.AddMathShape(0, 0, 400, 100);

                // Retrieve the math paragraph from the shape
                Aspose.Slides.MathText.IMathParagraph mathParagraph = ((Aspose.Slides.MathText.MathPortion)mathShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

                // Create a MathFraction (x / y)
                Aspose.Slides.MathText.MathFraction fraction = new Aspose.Slides.MathText.MathFraction(
                    new Aspose.Slides.MathText.MathematicalText("x"),
                    new Aspose.Slides.MathText.MathematicalText("y")
                );

                // Wrap the fraction in a MathBlock (required by MathParagraph.Add)
                Aspose.Slides.MathText.MathBlock fractionBlock = new Aspose.Slides.MathText.MathBlock(fraction);

                // Add the MathBlock to the paragraph
                mathParagraph.Add(fractionBlock);

                // Save the presentation
                presentation.Save("MathFraction.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}