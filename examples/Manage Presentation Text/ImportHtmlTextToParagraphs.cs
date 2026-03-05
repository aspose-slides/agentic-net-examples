using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HtmlToParagraphExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape to hold the text
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

            // Initialize an empty text frame
            autoShape.AddTextFrame(string.Empty);

            // Get the paragraph collection of the text frame
            Aspose.Slides.IParagraphCollection paragraphs = autoShape.TextFrame.Paragraphs;

            // Import HTML text into the paragraph collection
            string html = "<h1>Welcome</h1><p>This is <b>bold</b> and <i>italic</i> text.</p>";
            paragraphs.AddFromHtml(html);

            // Save the presentation
            presentation.Save("HtmlImportedPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}