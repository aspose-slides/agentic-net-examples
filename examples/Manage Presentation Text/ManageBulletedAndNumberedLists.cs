using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to hold the text
        Aspose.Slides.IAutoShape textShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 500, 300);

        // Access the text frame of the shape
        Aspose.Slides.ITextFrame textFrame = textShape.TextFrame;
        textFrame.Text = ""; // Clear any default text

        // Create a bulleted paragraph
        Aspose.Slides.Paragraph bulletParagraph = new Aspose.Slides.Paragraph();
        bulletParagraph.Text = "First bulleted item";
        bulletParagraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        bulletParagraph.ParagraphFormat.Bullet.Char = (char)8226; // • character

        // Add the bulleted paragraph to the text frame
        textFrame.Paragraphs.Add(bulletParagraph);

        // Create another bulleted paragraph
        Aspose.Slides.Paragraph bulletParagraph2 = new Aspose.Slides.Paragraph();
        bulletParagraph2.Text = "Second bulleted item";
        bulletParagraph2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        bulletParagraph2.ParagraphFormat.Bullet.Char = (char)8226;

        textFrame.Paragraphs.Add(bulletParagraph2);

        // Create a numbered paragraph
        Aspose.Slides.Paragraph numberedParagraph = new Aspose.Slides.Paragraph();
        numberedParagraph.Text = "First numbered item";
        numberedParagraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;

        textFrame.Paragraphs.Add(numberedParagraph);

        // Create another numbered paragraph
        Aspose.Slides.Paragraph numberedParagraph2 = new Aspose.Slides.Paragraph();
        numberedParagraph2.Text = "Second numbered item";
        numberedParagraph2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Numbered;

        textFrame.Paragraphs.Add(numberedParagraph2);

        // Save the presentation
        presentation.Save("BulletedNumberedLists_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}