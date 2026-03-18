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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle autoshape with an initial text frame
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("Initial text");

            // Access the paragraph collection of the shape's text frame
            Aspose.Slides.IParagraphCollection paragraphs = shape.TextFrame.Paragraphs;

            // Add a new paragraph
            Aspose.Slides.Paragraph newParagraph = new Aspose.Slides.Paragraph();
            newParagraph.Text = "Added paragraph";
            paragraphs.Add(newParagraph);

            // Modify the first paragraph's text
            Aspose.Slides.IParagraph firstParagraph = paragraphs[0];
            firstParagraph.Text = "Modified first paragraph";

            // Delete the second paragraph (the one we just added)
            paragraphs.RemoveAt(1);

            // Save the presentation
            presentation.Save("ManagedParagraphs.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}