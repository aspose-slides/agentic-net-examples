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

            // Add a rectangle AutoShape
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

            // Add a TextFrame to the shape
            shape.AddTextFrame("");

            // Access the TextFrame
            Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

            // Clear any default paragraphs
            textFrame.Paragraphs.Clear();

            // Create first paragraph
            Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
            // Add a portion with text
            Aspose.Slides.Portion portion1 = new Aspose.Slides.Portion("First formatted paragraph.");
            // Set portion formatting
            portion1.PortionFormat.FontHeight = 24;
            portion1.PortionFormat.FontBold = Aspose.Slides.NullableBool.True;
            portion1.PortionFormat.FontUnderline = Aspose.Slides.TextUnderlineType.Single;
            // Add portion to paragraph
            para1.Portions.Clear();
            para1.Portions.Add(portion1);
            // Set paragraph alignment
            para1.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
            // Add paragraph to text frame
            textFrame.Paragraphs.Add(para1);

            // Create second paragraph
            Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
            // Add a portion with text
            Aspose.Slides.Portion portion2 = new Aspose.Slides.Portion("Second paragraph with different style.");
            // Set portion formatting
            portion2.PortionFormat.FontHeight = 18;
            portion2.PortionFormat.FontItalic = Aspose.Slides.NullableBool.True;
            portion2.PortionFormat.FontBold = Aspose.Slides.NullableBool.False;
            // Add portion to paragraph
            para2.Portions.Clear();
            para2.Portions.Add(portion2);
            // Set paragraph alignment
            para2.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Left;
            // Add paragraph to text frame
            textFrame.Paragraphs.Add(para2);

            // Save the presentation
            presentation.Save("FormattedParagraphs_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}