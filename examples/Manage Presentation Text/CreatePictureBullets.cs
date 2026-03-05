using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Load picture to be used as bullet
        string imagePath = "bullet.png";
        Aspose.Slides.IPPImage bulletImage;
        using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            bulletImage = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);
        }

        // Add a rectangle shape with text
        Aspose.Slides.IAutoShape shape = presentation.Slides[0].Shapes.AddAutoShape(
            Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 200);
        shape.AddTextFrame("First bullet\nSecond bullet");

        // Set picture bullet for each paragraph
        foreach (Aspose.Slides.IParagraph paragraph in shape.TextFrame.Paragraphs)
        {
            paragraph.ParagraphFormat.Bullet.Type = Aspose.Slides.BulletType.Picture;
            paragraph.ParagraphFormat.Bullet.Picture.Image = bulletImage;
        }

        // Save the presentation
        presentation.Save("PictureBullets_out.pptx", SaveFormat.Pptx);
    }
}