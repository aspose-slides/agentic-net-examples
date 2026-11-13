// -----------------------------------------------------------------------------
// Example: Add Rectangle Picture Fill Collection to PPTX using C#
// 
// Description:
// Demonstrates how to create a PowerPoint presentation, add rectangle shapes,
// and apply picture fill using images. Utilizes Aspose.Slides for .NET to
// generate a PPTX file with rectangles filled by pictures, suitable for
// automation or batch processing scenarios.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Picture Fill, Automation
// 
// Use Cases:
// - Automate adding picture-filled rectangles to presentations.
// - Build .NET tools for batch PowerPoint image processing.
// - Generate visual reports with image-filled shapes programmatically.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

class Program
{
    static void Main()
    {
        // Prepare output directory
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }
        string outputPath = Path.Combine(outputDir, "RectanglesWithPictureFill.pptx");

        // Define image file names
        string[] imageFiles = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };

        // Ensure sample images exist
        for (int i = 0; i < imageFiles.Length; i++)
        {
            string imgPath = Path.Combine(Directory.GetCurrentDirectory(), imageFiles[i]);
            if (!File.Exists(imgPath))
            {
                try
                {
                    using (Bitmap bmp = new Bitmap(200, 200))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.Clear(Color.FromArgb(100 + i * 50, 150 + i * 30, 200 - i * 40));
                            using (Font font = new Font("Arial", 24))
                            {
                                g.DrawString("Img " + (i + 1), font, Brushes.White, new PointF(20, 80));
                            }
                        }
                        bmp.Save(imgPath, ImageFormat.Jpeg);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample image: " + imgPath);
                    Console.WriteLine(ex.Message);
                    Environment.Exit(1);
                }
            }
        }

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Rectangle layout parameters
        int startX = 50;
        int startY = 50;
        int rectWidth = 300;
        int rectHeight = 200;
        int verticalSpacing = 250;

        // Add rectangles with picture fill
        for (int i = 0; i < imageFiles.Length; i++)
        {
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), imageFiles[i]);

            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                Environment.Exit(1);
            }

            try
            {
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(imageBytes);

                int posY = startY + i * verticalSpacing;
                Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    startX,
                    posY,
                    rectWidth,
                    rectHeight);

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
            }
            catch (NotSupportedException)
            {
                Console.WriteLine("Image format not supported for file: " + imagePath);
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing image: " + imagePath);
                Console.WriteLine(ex.Message);
                Environment.Exit(1);
            }
        }

        // Save the presentation
        try
        {
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save presentation: " + ex.Message);
            Environment.Exit(1);
        }
        finally
        {
            pres.Dispose();
        }

        Console.WriteLine("Presentation saved to: " + outputPath);
    }
}
