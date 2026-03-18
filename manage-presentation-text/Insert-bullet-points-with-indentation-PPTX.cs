using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Output directory
            string outDir = "Output";
            if (!Directory.Exists(outDir))
                Directory.CreateDirectory(outDir);

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);

            // Get the text frame of the shape
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Remove the default empty paragraph
            textFrame.Paragraphs.RemoveAt(0);

            // First bullet paragraph
            Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
            para1.Text = "First bullet item";
            para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para1.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226); // •
            para1.ParagraphFormat.Indent = 20f;

            // Second bullet paragraph
            Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
            para2.Text = "Second bullet item";
            para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para2.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226);
            para2.ParagraphFormat.Indent = 20f;

            // Numbered paragraph
            Aspose.Slides.Paragraph para3 = new Aspose.Slides.Paragraph();
            para3.Text = "First numbered item";
            para3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;
            para3.ParagraphFormat.Bullet.NumberedBulletStyle = Aspose.Slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain;
            para3.ParagraphFormat.Indent = 30f;

            // Add paragraphs to the text frame
            textFrame.Paragraphs.Add(para1);
            textFrame.Paragraphs.Add(para2);
            textFrame.Paragraphs.Add(para3);

            // Save the presentation
            string outPath = Path.Combine(outDir, "BulletPoints.pptx");
            presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}