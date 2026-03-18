using System;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add a rectangle auto shape to hold the text
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50, 50, 500, 300);

                // Get the text frame of the shape
                Aspose.Slides.ITextFrame textFrame = shape.TextFrame;

                // Remove the default empty paragraph
                textFrame.Paragraphs.RemoveAt(0);

                // ---------- Paragraph 1: Symbol bullet ----------
                Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
                para1.Text = "Symbol bullet item";
                para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
                // Use a solid bullet character (e.g., •)
                para1.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226);
                para1.ParagraphFormat.Indent = 20f;
                para1.ParagraphFormat.Bullet.Color.ColorType = Aspose.Slides.ColorType.RGB;
                para1.ParagraphFormat.Bullet.Color.Color = System.Drawing.Color.Black;
                para1.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
                textFrame.Paragraphs.Add(para1);

                // ---------- Paragraph 2: Numbered bullet with custom start ----------
                Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
                para2.Text = "Numbered bullet starting at 5";
                para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
                para2.ParagraphFormat.Bullet.NumberedBulletStyle = Aspose.Slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain;
                para2.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)5;
                para2.ParagraphFormat.Indent = 20f;
                para2.ParagraphFormat.Bullet.Color.ColorType = Aspose.Slides.ColorType.RGB;
                para2.ParagraphFormat.Bullet.Color.Color = System.Drawing.Color.Black;
                para2.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
                textFrame.Paragraphs.Add(para2);

                // ---------- Paragraph 3: Numbered bullet with different style ----------
                Aspose.Slides.Paragraph para3 = new Aspose.Slides.Paragraph();
                para3.Text = "Standard numbered bullet";
                para3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
                para3.ParagraphFormat.Bullet.NumberedBulletStyle = Aspose.Slides.NumberedBulletStyle.BulletArabicPeriod;
                para3.ParagraphFormat.Bullet.NumberedBulletStartWith = (short)1;
                para3.ParagraphFormat.Indent = 20f;
                para3.ParagraphFormat.Bullet.Color.ColorType = Aspose.Slides.ColorType.RGB;
                para3.ParagraphFormat.Bullet.Color.Color = System.Drawing.Color.Black;
                para3.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
                textFrame.Paragraphs.Add(para3);

                // Save the presentation
                string outputPath = "BulletedNumberedLists_out.pptx";
                presentation.Save(outputPath, SaveFormat.Pptx);
                presentation.Dispose();

                Console.WriteLine("Presentation saved to " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}