using System;
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Presentation pres = new Presentation();

        // Load an image to be used as a picture bullet
        string bulletImagePath = "bullet.png";
        IPPImage bulletImg;
        using (FileStream imgStream = new FileStream(bulletImagePath, FileMode.Open, FileAccess.Read))
        {
            bulletImg = pres.Images.AddImage(imgStream);
        }

        // Add a rectangle shape with a text frame containing two paragraphs
        IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
        shape.AddTextFrame("First bullet\nSecond bullet");

        // Configure the first paragraph to use the picture bullet
        IParagraph para1 = shape.TextFrame.Paragraphs[0];
        para1.ParagraphFormat.Bullet.Type = BulletType.Picture;
        para1.ParagraphFormat.Bullet.Picture.Image = bulletImg;

        // Configure the second paragraph to use the same picture bullet
        IParagraph para2 = shape.TextFrame.Paragraphs[1];
        para2.ParagraphFormat.Bullet.Type = BulletType.Picture;
        para2.ParagraphFormat.Bullet.Picture.Image = bulletImg;

        // Save the updated presentation
        pres.Save("PictureBulletPresentation.pptx", SaveFormat.Pptx);
    }
}