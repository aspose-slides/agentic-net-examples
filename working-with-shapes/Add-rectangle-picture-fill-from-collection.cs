using System;
using System.IO;
using Aspose.Slides.Export;

namespace TilePictureFillExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and ensure it exists
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Define output file path
            string outputPath = Path.Combine(dataDir, "TilePictureFillPresentation.pptx");

            // List of image file names (place your images in the Data folder)
            string[] imageFiles = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Position variables for rectangles
            float startX = 50f;
            float startY = 50f;
            float rectWidth = 200f;
            float rectHeight = 150f;
            float offsetX = 250f; // horizontal distance between rectangles

            for (int i = 0; i < imageFiles.Length; i++)
            {
                string imagePath = Path.Combine(dataDir, imageFiles[i]);

                // Check if the image file exists
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine($"Image file not found: {imagePath}");
                    continue;
                }

                try
                {
                    // Load image from file
                    Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);

                    // Add image to presentation's image collection
                    Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

                    // Add a rectangle shape
                    float posX = startX + i * offsetX;
                    Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                        Aspose.Slides.ShapeType.Rectangle,
                        posX,
                        startY,
                        rectWidth,
                        rectHeight);

                    // Set fill type to picture
                    shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;

                    // Get picture fill format
                    Aspose.Slides.IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;

                    // Assign the picture
                    picFill.Picture.Image = ppImg;

                    // Set tile mode and additional properties
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
                    // Format not supported
                    Console.WriteLine($"The image format of {imagePath} is not supported.");
                }
                catch (Exception ex)
                {
                    // General exception handling
                    Console.WriteLine($"Error processing {imagePath}: {ex.Message}");
                }
            }

            try
            {
                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
                Console.WriteLine($"Presentation saved to {outputPath}");
            }
            catch (NotSupportedException)
            {
                // Save format not supported
                Console.WriteLine("The specified save format is not supported.");
            }
            finally
            {
                // Dispose presentation
                pres.Dispose();
            }
        }
    }
}