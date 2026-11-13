// -----------------------------------------------------------------------------
// Example: Add bitmap pattern fill to shape using C#
// 
// Description:
// Demonstrates how to apply a bitmap pattern fill to an AutoShape in a PowerPoint
// presentation using Aspose.Slides for .NET. The program creates a sample PNG
// image if none exists, sets it as a tiled picture fill with alignment and flip
// options, and saves the resulting PPTX file.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Bitmap, Pattern Fill, Shape
// 
// Use Cases:
// - Automate adding bitmap pattern fills to shapes in PPTX files.
// - Build .NET tools for customizing slide graphics.
// - Generate presentations with tiled image backgrounds.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        string imagePath = Path.Combine(dataDir, "pattern.png");
        if (!File.Exists(imagePath))
        {
            try
            {
                using (Bitmap bmp = new Bitmap(100, 100))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                        using (Pen pen = new Pen(Color.LightGray, 2))
                        {
                            for (int i = 0; i < 100; i += 10)
                            {
                                g.DrawLine(pen, i, 0, 0, i);
                                g.DrawLine(pen, 100, i, i, 100);
                            }
                        }
                    }
                    bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create sample image: " + ex.Message);
                Environment.Exit(1);
            }
        }

        string outputPath = Path.Combine(dataDir, "output.pptx");

        try
        {
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();
            Aspose.Slides.ISlide slide = pres.Slides[0];
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 300);
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
            Console.WriteLine("Presentation saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Environment.Exit(1);
        }
    }
}
