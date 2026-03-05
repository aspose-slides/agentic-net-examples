using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to hold the text
        Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 500, 300);
        shape.AddTextFrame("");

        // First level bullet
        Aspose.Slides.IParagraph para1 = shape.TextFrame.Paragraphs[0];
        para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para1.ParagraphFormat.Bullet.Char = (char)8226; // •
        para1.ParagraphFormat.Depth = 0;
        para1.Portions[0].Text = "First level bullet";

        // Second level bullet
        Aspose.Slides.IParagraph para2 = new Aspose.Slides.Paragraph();
        para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para2.ParagraphFormat.Bullet.Char = (char)8226;
        para2.ParagraphFormat.Depth = 1;
        para2.Portions.Add(new Aspose.Slides.Portion("Second level bullet"));
        shape.TextFrame.Paragraphs.Add(para2);

        // Third level bullet
        Aspose.Slides.IParagraph para3 = new Aspose.Slides.Paragraph();
        para3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para3.ParagraphFormat.Bullet.Char = (char)8226;
        para3.ParagraphFormat.Depth = 2;
        para3.Portions.Add(new Aspose.Slides.Portion("Third level bullet"));
        shape.TextFrame.Paragraphs.Add(para3);

        // Save the presentation
        presentation.Save("MultilevelBullets.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}