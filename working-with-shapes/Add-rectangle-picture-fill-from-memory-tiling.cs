using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths
        var dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        var imagePath = Path.Combine(dataDir, "image.jpg");
        var outputPath = Path.Combine(dataDir, "output.pptx");

        // Ensure directory exists
        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);

        // Verify image file exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        try
        {
            // Create presentation
            var pres = new Presentation();

            // Load image into memory stream
            var imageBytes = File.ReadAllBytes(imagePath);
            var ms = new MemoryStream(imageBytes);

            // Add image to presentation
            var ppImg = pres.Images.AddImage(ms);

            // Get first slide
            var slide = pres.Slides[0];

            // Add rectangle shape
            var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 300);

            // Apply picture fill with tiling
            shape.FillFormat.FillType = FillType.Picture;
            var picFill = shape.FillFormat.PictureFillFormat;
            picFill.Picture.Image = ppImg;
            picFill.PictureFillMode = PictureFillMode.Tile;
            picFill.TileOffsetX = 0f;
            picFill.TileOffsetY = 0f;
            picFill.TileScaleX = 100f;
            picFill.TileScaleY = 100f;
            picFill.TileAlignment = RectangleAlignment.BottomRight;
            picFill.TileFlip = TileFlip.FlipBoth;

            // Save presentation
            pres.Save(outputPath, SaveFormat.Pptx);
            pres.Dispose();

            Console.WriteLine("Presentation saved to " + outputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}