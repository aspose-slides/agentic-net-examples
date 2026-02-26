using System;
using System.IO;
using System.Drawing;

namespace ManagePresentationText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define output directory
            string outDir = "Output";
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle shape to hold the bullet list
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 500, 300);

            // Access the text frame of the shape
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Remove the default empty paragraph
            textFrame.Paragraphs.RemoveAt(0);

            // Common bullet settings
            int bulletCharCode = 8226; // •
            float bulletIndent = 20f;
            System.Drawing.Color bulletColor = System.Drawing.Color.Black;

            // First bullet point
            Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
            para1.Text = "Clarity";
            para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para1.ParagraphFormat.Bullet.Char = Convert.ToChar(bulletCharCode);
            para1.ParagraphFormat.Indent = bulletIndent;
            para1.ParagraphFormat.Bullet.Color.ColorType = Aspose.Slides.ColorType.RGB;
            para1.ParagraphFormat.Bullet.Color.Color = bulletColor;
            para1.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
            textFrame.Paragraphs.Add(para1);

            // Second bullet point
            Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
            para2.Text = "Organization";
            para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para2.ParagraphFormat.Bullet.Char = Convert.ToChar(bulletCharCode);
            para2.ParagraphFormat.Indent = bulletIndent;
            para2.ParagraphFormat.Bullet.Color.ColorType = Aspose.Slides.ColorType.RGB;
            para2.ParagraphFormat.Bullet.Color.Color = bulletColor;
            para2.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
            textFrame.Paragraphs.Add(para2);

            // Third bullet point
            Aspose.Slides.Paragraph para3 = new Aspose.Slides.Paragraph();
            para3.Text = "Emphasis";
            para3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para3.ParagraphFormat.Bullet.Char = Convert.ToChar(bulletCharCode);
            para3.ParagraphFormat.Indent = bulletIndent;
            para3.ParagraphFormat.Bullet.Color.ColorType = Aspose.Slides.ColorType.RGB;
            para3.ParagraphFormat.Bullet.Color.Color = bulletColor;
            para3.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
            textFrame.Paragraphs.Add(para3);

            // Save the presentation as PPTX
            presentation.Save(Path.Combine(outDir, "BulletListPresentation.pptx"),
                Aspose.Slides.Export.SaveFormat.Pptx);

            // Dispose the presentation object
            presentation.Dispose();
        }
    }
}