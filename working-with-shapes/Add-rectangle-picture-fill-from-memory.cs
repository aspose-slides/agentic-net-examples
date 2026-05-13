using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string imagePath = Path.Combine(dataDir, "image.jpg");
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
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(ms);

                Aspose.Slides.ISlide slide = pres.Slides[0];

                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 400f, 300f);

                shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                Aspose.Slides.IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                picFill.Picture.Image = ppImg;
                picFill.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;
                picFill.TileOffsetX = 0f;
                picFill.TileOffsetY = 0f;
                picFill.TileScaleX = 1f;
                picFill.TileScaleY = 1f;
                picFill.TileAlignment = Aspose.Slides.RectangleAlignment.BottomRight;
                picFill.TileFlip = Aspose.Slides.TileFlip.FlipBoth;

                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                pres.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}