using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add two rectangle shapes with text frames
        Aspose.Slides.IAutoShape shape1 = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 100);
        shape1.AddTextFrame("First placeholder");
        Aspose.Slides.IAutoShape shape2 = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 200, 400, 100);
        shape2.AddTextFrame("Second placeholder");

        // Align paragraphs to center using the paragraphs-alignment rule
        Aspose.Slides.ISlide slide0 = presentation.Slides[0];
        Aspose.Slides.ITextFrame tf1 = ((Aspose.Slides.IAutoShape)slide0.Shapes[0]).TextFrame;
        Aspose.Slides.ITextFrame tf2 = ((Aspose.Slides.IAutoShape)slide0.Shapes[1]).TextFrame;
        tf1.Text = "Center Align by Aspose";
        tf2.Text = "Center Align by Aspose";
        Aspose.Slides.IParagraph para1 = tf1.Paragraphs[0];
        Aspose.Slides.IParagraph para2 = tf2.Paragraphs[0];
        para1.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
        para2.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

        // Save the presentation as PPTX
        presentation.Save("AlignedParagraphs_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}