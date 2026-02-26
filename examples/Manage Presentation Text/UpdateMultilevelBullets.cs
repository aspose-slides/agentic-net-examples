using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Output directory
        string outDir = "Output";
        if (!System.IO.Directory.Exists(outDir))
            System.IO.Directory.CreateDirectory(outDir);

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle auto shape to hold the text
        Aspose.Slides.IAutoShape autoShape = slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

        // Get the text frame of the shape
        Aspose.Slides.ITextFrame textFrame = autoShape.TextFrame;

        // Remove the default empty paragraph
        textFrame.Paragraphs.RemoveAt(0);

        // First level bullet
        Aspose.Slides.Paragraph para1 = new Aspose.Slides.Paragraph();
        para1.Text = "First level bullet";
        para1.ParagraphFormat.Depth = 0;
        para1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para1.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226); // •
        textFrame.Paragraphs.Add(para1);

        // Second level bullet
        Aspose.Slides.Paragraph para2 = new Aspose.Slides.Paragraph();
        para2.Text = "Second level bullet";
        para2.ParagraphFormat.Depth = 1;
        para2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para2.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226); // •
        textFrame.Paragraphs.Add(para2);

        // Third level bullet
        Aspose.Slides.Paragraph para3 = new Aspose.Slides.Paragraph();
        para3.Text = "Third level bullet";
        para3.ParagraphFormat.Depth = 2;
        para3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        para3.ParagraphFormat.Bullet.Char = System.Convert.ToChar(8226); // •
        textFrame.Paragraphs.Add(para3);

        // Save the presentation as PPTX
        string outPath = System.IO.Path.Combine(outDir, "MultilevelBullets.pptx");
        presentation.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        presentation.Dispose();
    }
}