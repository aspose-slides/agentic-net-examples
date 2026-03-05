using System;
using Aspose.Slides;

class Program
{
    static void Main()
    {
        // Create a new presentation and ensure it is disposed properly
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Access the first slide in the presentation
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape with a TextFrame containing two paragraphs
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            autoShape.AddTextFrame("First paragraph.\nSecond paragraph.");

            // Retrieve the first paragraph from the TextFrame
            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

            // Adjust the first line indent of the paragraph (in points)
            paragraph.ParagraphFormat.Indent = 30;

            // Apply default paragraph indents shifts (useful when bullets are enabled)
            paragraph.ParagraphFormat.Bullet.ApplyDefaultParagraphIndentsShifts();

            // Save the modified presentation to disk
            presentation.Save("AdjustedIndentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}