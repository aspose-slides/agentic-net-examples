using System;
using System.IO;
using Aspose.Slides;
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
            // Create a new presentation
            Presentation pres = new Presentation();

            // Load image into memory stream
            byte[] imageBytes = File.ReadAllBytes(imagePath);
            MemoryStream ms = new MemoryStream(imageBytes);

            // Add image to presentation
            IPPImage ppImg = pres.Images.AddImage(ms);

            // Get first slide
            ISlide slide = pres.Slides[0];

            // Add rectangle shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 300);

            // Apply picture fill with tiling
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

            // Save presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}