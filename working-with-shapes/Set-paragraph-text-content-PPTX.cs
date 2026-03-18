using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);

            // Add a text frame with placeholder text
            shape.AddTextFrame(" ");

            // Access the text frame
            ITextFrame textFrame = shape.TextFrame;

            // Get the first paragraph
            IParagraph paragraph = textFrame.Paragraphs[0];

            // Get the first portion of the paragraph
            IPortion portion = paragraph.Portions[0];

            // Set the custom string as the paragraph content
            portion.Text = "Custom paragraph content";

            // Save the presentation
            presentation.Save("CustomParagraph.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}