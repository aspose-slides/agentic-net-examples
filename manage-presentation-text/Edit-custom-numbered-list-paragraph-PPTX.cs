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
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to hold the text
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
            ITextFrame textFrame = shape.TextFrame;

            // Remove the default empty paragraph
            textFrame.Paragraphs.RemoveAt(0);

            // First custom numbered paragraph
            Paragraph paragraph1 = new Paragraph();
            paragraph1.Text = "First custom numbered item";
            paragraph1.ParagraphFormat.Depth = 0;
            paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
            paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 5;
            paragraph1.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
            textFrame.Paragraphs.Add(paragraph1);

            // Second custom numbered paragraph
            Paragraph paragraph2 = new Paragraph();
            paragraph2.Text = "Second custom numbered item";
            paragraph2.ParagraphFormat.Depth = 0;
            paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
            paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 6;
            paragraph2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
            textFrame.Paragraphs.Add(paragraph2);

            // Third custom numbered paragraph
            Paragraph paragraph3 = new Paragraph();
            paragraph3.Text = "Third custom numbered item";
            paragraph3.ParagraphFormat.Depth = 0;
            paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
            paragraph3.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
            paragraph3.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
            textFrame.Paragraphs.Add(paragraph3);

            // Save the presentation
            string outputPath = "CustomNumberedList_out.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}