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

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape with a text frame
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);
            shape.AddTextFrame("Placeholder");

            // Get the text frame
            Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

            // Remove the default paragraph
            textFrame.Paragraphs.Clear();

            // First paragraph with custom indentation
            Aspose.Slides.IParagraph para1 = new Aspose.Slides.Paragraph();
            para1.Text = "First paragraph with indentation.";
            para1.ParagraphFormat.Indent = 20f;       // First line indent
            para1.ParagraphFormat.MarginLeft = 30f;   // Left margin
            textFrame.Paragraphs.Add(para1);

            // Second paragraph with larger indentation
            Aspose.Slides.IParagraph para2 = new Aspose.Slides.Paragraph();
            para2.Text = "Second paragraph with larger indentation.";
            para2.ParagraphFormat.Indent = 40f;
            para2.ParagraphFormat.MarginLeft = 60f;
            textFrame.Paragraphs.Add(para2);

            // Save the presentation
            presentation.Save("ParagraphIndentation_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}