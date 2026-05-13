using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string imagePath = Path.Combine(dataDir, "pattern.png");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file does not exist: " + imagePath);
            return;
        }

        try
        {
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];
            IImage img = Images.FromFile(imagePath);
            IPPImage ppImg = pres.Images.AddImage(img);
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 300);
            shape.FillFormat.FillType = FillType.Picture;
            IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
            picFill.Picture.Image = ppImg;
            picFill.PictureFillMode = PictureFillMode.Tile;
            picFill.TileOffsetX = 0f;
            picFill.TileOffsetY = 0f;
            picFill.TileScaleX = 1f;
            picFill.TileScaleY = 1f;
            picFill.TileAlignment = RectangleAlignment.BottomRight;
            picFill.TileFlip = TileFlip.FlipBoth;

            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}