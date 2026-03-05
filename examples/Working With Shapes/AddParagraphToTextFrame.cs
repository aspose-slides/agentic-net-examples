using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle AutoShape
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 300, 100);

        // Add a TextFrame with initial text
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("Initial text");

        // Create a new paragraph
        Aspose.Slides.IParagraph newParagraph = new Aspose.Slides.Paragraph();
        newParagraph.Text = "This is a new paragraph.";

        // Add the new paragraph to the TextFrame
        textFrame.Paragraphs.Add(newParagraph);

        // Save the presentation
        presentation.Save("AddParagraph_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}