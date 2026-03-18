using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define output directory
            string outDir = "Output";
            if (!System.IO.Directory.Exists(outDir))
            {
                System.IO.Directory.CreateDirectory(outDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

            // Get the text frame of the shape
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Remove the default empty paragraph
            textFrame.Paragraphs.RemoveAt(0);

            // Create first paragraph with a symbol bullet
            Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
            para1.Text = "Symbol bullet paragraph";
            para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para1.ParagraphFormat.Bullet.Char = System.Convert.ToChar(0x2022); // bullet character
            para1.ParagraphFormat.Bullet.Color.ColorType = Aspose.Slides.ColorType.RGB;
            para1.ParagraphFormat.Bullet.Color.Color = System.Drawing.Color.Blue;
            para1.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
            textFrame.Paragraphs.Add(para1);

            // Create second paragraph with a numbered bullet
            Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
            para2.Text = "Numbered bullet paragraph";
            para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            para2.ParagraphFormat.Bullet.NumberedBulletStyle = Aspose.Slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain;
            para2.ParagraphFormat.Bullet.Color.ColorType = Aspose.Slides.ColorType.RGB;
            para2.ParagraphFormat.Bullet.Color.Color = System.Drawing.Color.Green;
            para2.ParagraphFormat.Bullet.IsBulletHardColor = Aspose.Slides.NullableBool.True;
            textFrame.Paragraphs.Add(para2);

            // Save the modified presentation as PPTX
            string outPath = System.IO.Path.Combine(outDir, "ModifiedBullets.pptx");
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}