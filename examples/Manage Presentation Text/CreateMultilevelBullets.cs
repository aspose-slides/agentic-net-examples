using System;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape that will contain the multilevel bullet text
        Aspose.Slides.IAutoShape autoShape = (Aspose.Slides.IAutoShape)slide.Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

        // Add a text frame to the shape
        Aspose.Slides.ITextFrame textFrame = autoShape.AddTextFrame(string.Empty);
        textFrame.TextFrameFormat.AutofitType = Aspose.Slides.TextAutofitType.Normal;

        // Clear any default paragraphs
        textFrame.Paragraphs.Clear();

        // Create first level bullet
        Aspose.Slides.IParagraph paraLevel1 = new Aspose.Slides.Paragraph();
        paraLevel1.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        paraLevel1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226); // •
        paraLevel1.ParagraphFormat.Depth = 0;
        paraLevel1.Portions.Add(new Aspose.Slides.Portion("First level bullet"));
        textFrame.Paragraphs.Add(paraLevel1);

        // Create second level bullet
        Aspose.Slides.IParagraph paraLevel2 = new Aspose.Slides.Paragraph();
        paraLevel2.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        paraLevel2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
        paraLevel2.ParagraphFormat.Depth = 1;
        paraLevel2.Portions.Add(new Aspose.Slides.Portion("Second level bullet"));
        textFrame.Paragraphs.Add(paraLevel2);

        // Create third level bullet
        Aspose.Slides.IParagraph paraLevel3 = new Aspose.Slides.Paragraph();
        paraLevel3.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Symbol;
        paraLevel3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
        paraLevel3.ParagraphFormat.Depth = 2;
        paraLevel3.Portions.Add(new Aspose.Slides.Portion("Third level bullet"));
        textFrame.Paragraphs.Add(paraLevel3);

        // Save the presentation
        presentation.Save("MultilevelBullets.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}