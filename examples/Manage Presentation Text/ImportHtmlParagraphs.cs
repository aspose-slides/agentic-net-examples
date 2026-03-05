using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation.
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide.
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to the slide.
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

        // Add an empty text frame to the shape.
        Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame("");

        // HTML content to import.
        string html = "<p>This is <b>bold</b> and <i>italic</i> text.</p>" +
                      "<ul><li>Item 1</li><li>Item 2</li></ul>";

        // Import the HTML into the text frame's paragraphs.
        textFrame.Paragraphs.AddFromHtml(html);

        // Save the presentation.
        presentation.Save("ImportHtmlParagraphs_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}