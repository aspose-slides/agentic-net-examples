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

            // Add a rectangle auto shape to contain the bullet list
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

            // Add an empty text frame to the shape
            autoShape.AddTextFrame(" ");

            // Access the text frame
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Remove the default paragraph
            textFrame.Paragraphs.Clear();

            // Paragraph 1 – Symbol bullet
            Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
            para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para1.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226); // •
            para1.Text = "Clear structure and hierarchy";
            textFrame.Paragraphs.Add(para1);

            // Paragraph 2 – Numbered bullet
            Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
            para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            para2.ParagraphFormat.Bullet.NumberedBulletStyle = Aspose.Slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain;
            para2.Text = "Easy to scan key points";
            textFrame.Paragraphs.Add(para2);

            // Paragraph 3 – Symbol bullet
            Aspose.Slides.Paragraph para3 = new Aspose.Slides.Paragraph();
            para3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para3.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226); // •
            para3.Text = "Improves readability and retention";
            textFrame.Paragraphs.Add(para3);

            // Save the presentation before exiting
            string outPath = "BulletBenefits.pptx";
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}