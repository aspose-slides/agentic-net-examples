using System;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Aspose.Slides.Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 600, 400);
            shape.AddTextFrame(string.Empty);
            var textFrame = shape.TextFrame;
            textFrame.Paragraphs.Clear();

            var para0 = new Aspose.Slides.Paragraph();
            para0.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para0.ParagraphFormat.Bullet.Char = (char)8226;
            para0.ParagraphFormat.Depth = 0;
            para0.Text = "First level item";
            textFrame.Paragraphs.Add(para0);

            var para1 = new Aspose.Slides.Paragraph();
            para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para1.ParagraphFormat.Bullet.Char = (char)8226;
            para1.ParagraphFormat.Depth = 1;
            para1.Text = "Second level item";
            textFrame.Paragraphs.Add(para1);

            var para2 = new Aspose.Slides.Paragraph();
            para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para2.ParagraphFormat.Bullet.Char = (char)8226;
            para2.ParagraphFormat.Depth = 2;
            para2.Text = "Third level item";
            textFrame.Paragraphs.Add(para2);

            presentation.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}