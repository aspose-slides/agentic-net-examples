using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output directory
            string outDir = "Output";
            if (!Directory.Exists(outDir))
            {
                Directory.CreateDirectory(outDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a rectangle auto shape and a text frame
            Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 500, 300);
            autoShape.AddTextFrame(" ");
            Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

            // Remove the default empty paragraph
            textFrame.Paragraphs.RemoveAt(0);

            // First level bullet
            Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
            para1.Text = "Top Level Item";
            para1.ParagraphFormat.Depth = 0;
            para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para1.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226); // •
            para1.ParagraphFormat.Indent = 20f;
            textFrame.Paragraphs.Add(para1);

            // Second level bullet
            Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
            para2.Text = "Second Level Item";
            para2.ParagraphFormat.Depth = 1;
            para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para2.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226);
            para2.ParagraphFormat.Indent = 40f;
            textFrame.Paragraphs.Add(para2);

            // Third level bullet
            Aspose.Slides.Paragraph para3 = new Aspose.Slides.Paragraph();
            para3.Text = "Third Level Item";
            para3.ParagraphFormat.Depth = 2;
            para3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
            para3.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226);
            para3.ParagraphFormat.Indent = 60f;
            textFrame.Paragraphs.Add(para3);

            // Remove the second level bullet (index 1)
            textFrame.Paragraphs.RemoveAt(1);

            // Save the presentation
            presentation.Save(Path.Combine(outDir, "HierarchicalBullets.pptx"),
                Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}