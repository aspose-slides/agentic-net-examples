using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape with a text frame
            Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);

            // Set the text of the shape
            autoShape.TextFrame.Text = "This paragraph will have an indent.";

            // Get the first paragraph
            Aspose.Slides.IParagraph paragraph = autoShape.TextFrame.Paragraphs[0];

            // Set the indent value (e.g., 20 points)
            paragraph.ParagraphFormat.Indent = 20f;

            // Save the presentation
            presentation.Save("ParagraphIndent_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}