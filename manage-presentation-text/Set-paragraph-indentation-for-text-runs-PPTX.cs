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

            // Add a rectangle auto shape with a text frame
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
            shape.AddTextFrame("First line\r\nSecond line");

            // Access the first paragraph of the text frame
            Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];

            // Apply specific indentation to the paragraph
            paragraph.ParagraphFormat.Indent = 20f;        // Indent from the left margin
            paragraph.ParagraphFormat.MarginLeft = 10f;   // Additional left margin if needed

            // Save the presentation
            presentation.Save("IndentedParagraph.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}