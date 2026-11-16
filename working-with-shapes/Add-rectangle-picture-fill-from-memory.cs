// -----------------------------------------------------------------------------
// Example: Add rectangle picture fill from memory using C#
// 
// Description:
// Demonstrates loading an image from a file into memory, adding it to a
// presentation, and applying it as a tiled picture fill to a rectangle shape
// using Aspose.Slides for .NET. The program creates a PPTX file with a rectangle
// whose fill is configured with tile mode, alignment, and flip settings.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, rectangle picture fill, memory stream
// 
// Use Cases:
// - Apply custom picture fills to shapes from in‑memory images.
// - Generate PowerPoint slides programmatically with image‑based styling.
// - Automate creation of presentations where images are sourced from streams.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------

using System;
using System.IO;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string imagePath = Path.Combine(dataDir, "image.png");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        try
        {
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            if (!File.Exists(imagePath))
            {
                // Create a simple 1x1 red PNG image
                byte[] pngBytes = Convert.FromBase64String(
                    "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=");
                File.WriteAllBytes(imagePath, pngBytes);
            }

            byte[] imageBytes = File.ReadAllBytes(imagePath);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(ms);

                Aspose.Slides.ISlide slide = pres.Slides[0];

                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 50f, 50f, 400f, 300f);

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

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
