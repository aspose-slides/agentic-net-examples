using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape with a TextFrame
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
        shape.AddTextFrame("First paragraph");

        // Get the first paragraph of the TextFrame
        Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];

        // Enable bullets and set bullet character
        paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
        paragraph.ParagraphFormat.Bullet.Char = (char)8226; // • bullet character

        // Apply default paragraph indents shifts for bullets
        paragraph.ParagraphFormat.Bullet.ApplyDefaultParagraphIndentsShifts();

        // Save the presentation
        presentation.Save("BulletDemo_out.pptx", SaveFormat.Pptx);
    }
}