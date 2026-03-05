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

        // Add a title shape
        Aspose.Slides.IAutoShape titleShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 20, 600, 50);
        titleShape.AddTextFrame("Why Use Bullet Lists?");
        titleShape.TextFrame.Paragraphs[0].ParagraphFormat.Alignment = Aspose.Slides.TextAlignment.Center;

        // Add a bullet list shape
        Aspose.Slides.IAutoShape bulletShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 500, 300);
        bulletShape.AddTextFrame("First bullet");
        bulletShape.TextFrame.Paragraphs[0].ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        bulletShape.TextFrame.Paragraphs[0].ParagraphFormat.Bullet.Char = (char)8226; // bullet character

        // Add second bullet point
        Aspose.Slides.IParagraph para2 = new Aspose.Slides.Paragraph();
        para2.Text = "Second bullet";
        para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para2.ParagraphFormat.Bullet.Char = (char)8226;
        bulletShape.TextFrame.Paragraphs.Add(para2);

        // Add third bullet point
        Aspose.Slides.IParagraph para3 = new Aspose.Slides.Paragraph();
        para3.Text = "Third bullet";
        para3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para3.ParagraphFormat.Bullet.Char = (char)8226;
        bulletShape.TextFrame.Paragraphs.Add(para3);

        // Save the presentation
        presentation.Save("BulletListPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}