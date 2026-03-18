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

            // Add a rectangle AutoShape and set its text
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 150, 400, 100);
            shape.TextFrame.Text = "Centered Text";

            // Retrieve the first paragraph of the shape's text frame
            Aspose.Slides.IParagraph paragraph = shape.TextFrame.Paragraphs[0];

            // Align the paragraph text to center
            paragraph.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

            // Save the presentation
            presentation.Save("AlignedParagraph_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}