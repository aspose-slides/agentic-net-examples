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

        // Add a rectangle AutoShape to the slide
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 100);

        // Add a TextFrame to the shape (initially empty)
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame(string.Empty);

        // Access the first paragraph in the TextFrame
        Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

        // Set the paragraph text
        paragraph.Text = "Hello Aspose.Slides!";

        // Apply formatting: center alignment
        paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

        // Save the presentation to disk
        presentation.Save("ShapeParagraph.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}