using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            var presentation = new Presentation();
            var slide = presentation.Slides[0];
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
            var textFrame = shape.TextFrame;
            textFrame.Paragraphs.Clear();

            var para1 = new Paragraph();
            para1.Text = "First bullet paragraph";
            para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
            para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226); // bullet character
            para1.ParagraphFormat.Bullet.Height = 12f; // set bullet height
            para1.ParagraphFormat.Bullet.IsBulletHardFont = NullableBool.True;
            textFrame.Paragraphs.Add(para1);

            var para2 = new Paragraph();
            para2.Text = "Second numbered bullet";
            para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
            para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
            para2.ParagraphFormat.Bullet.NumberedBulletStartWith = 5;
            para2.ParagraphFormat.Bullet.Height = 14f; // set bullet height
            textFrame.Paragraphs.Add(para2);

            presentation.Save("ConfiguredBullets_out.pptx", SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}