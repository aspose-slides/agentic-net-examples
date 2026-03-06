using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to host text
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50f, 100f, 400f, 100f);

        // Compute arithmetic expression
        int a = 5;
        int b = 3;
        int c = 2;
        int result = (a + b) * c - (a / b);

        // Set text with the result
        shape.TextFrame.Text = "Result of (5 + 3) * 2 - (5 / 3) = " + result;

        // Save the presentation
        presentation.Save("ArithmeticOperators.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}