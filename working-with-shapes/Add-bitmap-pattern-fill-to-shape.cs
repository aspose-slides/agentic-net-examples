// -----------------------------------------------------------------------------
// Example: Add bitmap pattern fill to shape using C#
//
// Description:
// Demonstrates how to apply a bitmap pattern fill to an AutoShape in a PowerPoint
// presentation using Aspose.Slides for .NET. The example loads a PNG image,
// sets it as a tiled picture fill with specific alignment and flip options,
// and saves the resulting presentation.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bitmap, Pattern Fill, Shape,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding bitmap pattern fills to shapes in PPTX files.
// - Build .NET tools for customizing slide graphics.
// - Generate presentations with tiled image backgrounds.
// - Validate fill settings before publishing.
// -----------------------------------------------------------------------------

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
