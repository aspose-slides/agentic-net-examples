using System;

namespace BulletDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape to hold text
            Aspose.Slides.IAutoShape shape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

            // Add a text frame to the shape
            Aspose.Slides.ITextFrame textFrame = shape.AddTextFrame("Agenda");

            // Set the title text
            textFrame.Paragraphs[0].Portions[0].Text = "Agenda";

            // Create first bullet paragraph
            Aspose.Slides.Paragraph bullet1 = new Aspose.Slides.Paragraph();
            bullet1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            bullet1.ParagraphFormat.Bullet.Char = (char)8226; // bullet character
            Aspose.Slides.Portion portion1 = new Aspose.Slides.Portion();
            portion1.Text = "First item";
            bullet1.Portions.Add(portion1);
            textFrame.Paragraphs.Add(bullet1);

            // Create second bullet paragraph
            Aspose.Slides.Paragraph bullet2 = new Aspose.Slides.Paragraph();
            bullet2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            bullet2.ParagraphFormat.Bullet.Char = (char)8226;
            Aspose.Slides.Portion portion2 = new Aspose.Slides.Portion();
            portion2.Text = "Second item";
            bullet2.Portions.Add(portion2);
            textFrame.Paragraphs.Add(bullet2);

            // Save the presentation
            presentation.Save("BulletsPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}