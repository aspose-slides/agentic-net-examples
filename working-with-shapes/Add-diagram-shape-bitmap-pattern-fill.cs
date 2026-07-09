using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string imagePath = Path.Combine(dataDir, "pattern.png");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Ensure data directory exists
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Verify that the bitmap image exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        try
        {
            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Load the bitmap image
            IImage img = Images.FromFile(imagePath);
            IPPImage ppImg = pres.Images.AddImage(img);

            // Add a rectangle shape that will act as a diagram shape
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 300);

            // Apply picture fill with tiling using the bitmap image
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

            // Save the presentation
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            // Comment: The requested file format is not supported.
        }
        catch (Exception ex)
        {
            // Handle other exceptions (e.g., file I/O, Aspose errors)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}