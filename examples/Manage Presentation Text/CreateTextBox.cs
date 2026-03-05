using System;

namespace TextBoxExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle AutoShape as a text box
            Aspose.Slides.IAutoShape textBox = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 150, 75, 150, 50);

            // Add a TextFrame with default text
            textBox.AddTextFrame(" ");

            // Access the TextFrame
            Aspose.Slides.ITextFrame textFrame = textBox.TextFrame;

            // Get the first paragraph
            Aspose.Slides.IParagraph paragraph = textFrame.Paragraphs[0];

            // Get the first portion
            Aspose.Slides.IPortion portion = paragraph.Portions[0];

            // Set the desired text
            portion.Text = "Aspose TextBox";

            // Save the presentation
            presentation.Save("TextBox_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}