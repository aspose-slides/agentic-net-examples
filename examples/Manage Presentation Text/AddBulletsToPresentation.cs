using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace BulletExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle shape to hold the bullet list
                Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

                // Add a text frame to the shape
                Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame("Bullet List");

                // Create first bullet paragraph
                Aspose.Slides.IParagraph paragraph1 = new Aspose.Slides.Paragraph();
                paragraph1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
                paragraph1.ParagraphFormat.Bullet.Char = (char)8226; // •
                Aspose.Slides.IPortion portion1 = new Aspose.Slides.Portion();
                portion1.Text = "First bullet item";
                paragraph1.Portions.Add(portion1);
                textFrame.Paragraphs.Add(paragraph1);

                // Create second bullet paragraph
                Aspose.Slides.IParagraph paragraph2 = new Aspose.Slides.Paragraph();
                paragraph2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
                paragraph2.ParagraphFormat.Bullet.Char = (char)8226; // •
                Aspose.Slides.IPortion portion2 = new Aspose.Slides.Portion();
                portion2.Text = "Second bullet item";
                paragraph2.Portions.Add(portion2);
                textFrame.Paragraphs.Add(paragraph2);

                // Save the presentation
                presentation.Save("Bullets_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}