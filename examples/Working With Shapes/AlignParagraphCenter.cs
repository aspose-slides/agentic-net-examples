using System;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add two rectangle shapes to act as placeholders
        Aspose.Slides.IAutoShape shape1 = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 50);
        Aspose.Slides.IAutoShape shape2 = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 150, 400, 50);

        // Get the text frames of the shapes
        Aspose.Slides.ITextFrame tf1 = shape1.TextFrame;
        Aspose.Slides.ITextFrame tf2 = shape2.TextFrame;

        // Set the text for both placeholders
        tf1.Text = "Center Align by Aspose";
        tf2.Text = "Center Align by Aspose";

        // Retrieve the first paragraph of each text frame
        Aspose.Slides.IParagraph para1 = tf1.Paragraphs[0];
        Aspose.Slides.IParagraph para2 = tf2.Paragraphs[0];

        // Align the paragraphs to the center
        para1.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;
        para2.ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

        // Save the presentation
        pres.Save("Centeralign_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}