using System;
using Aspose.Slides;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to the slide
        Aspose.Slides.IAutoShape faqShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50f, 150f, 400f, 200f);

        // Add a text frame with FAQ content
        faqShape.AddTextFrame("Frequently Asked Questions:\n1. How to use Aspose.Slides?\n2. How to add text?\n3. How to save the file?");

        // Save the presentation
        presentation.Save("FaqPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}