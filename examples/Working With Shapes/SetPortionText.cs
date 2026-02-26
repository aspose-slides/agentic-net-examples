using System;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 75, 150, 50);

            // Add a TextFrame with placeholder text
            autoShape.AddTextFrame(" ");

            // Access the TextFrame
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Get the first paragraph
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Get the first portion
            Aspose.Slides.IPortion portion = paragraph.Portions[0];

            // Set the text of the portion
            portion.Text = "Aspose TextBox";

            // Save the presentation
            presentation.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}