using System;
using System.IO;
using Aspose.Slides;
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

            // List of image file names (place your images in the Data folder)
            string[] imageFiles = new string[]
            {
                "image1.jpg",
                "image2.jpg",
                "image3.jpg"
            };

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Position variables for rectangles
            int startX = 50;
            int startY = 50;
            int rectWidth = 200;
            int rectHeight = 150;
            int offsetX = 250; // horizontal distance between rectangles

            for (int i = 0; i < imageFiles.Length; i++)
            {
                string imagePath = Path.Combine(dataDir, imageFiles[i]);

                // Check if the image file exists
                if (!File.Exists(imagePath))
                {
                    // Skip missing files
                    continue;
                }

                // Load image from file
                IImage img = Images.FromFile(imagePath);
                // Add image to presentation's image collection
                IPPImage ppImg = pres.Images.AddImage(img);

                // Add a rectangle shape
                int shapeX = startX + i * offsetX;
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, shapeX, startY, rectWidth, rectHeight);

                // Set picture fill
                shape.FillFormat.FillType = FillType.Picture;
                IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                picFill.Picture.Image = ppImg;
                picFill.PictureFillMode = PictureFillMode.Tile;

                // Optional: set tile properties (offsets, scales, alignment, flip)
                picFill.TileOffsetX = 0f;
                picFill.TileOffsetY = 0f;
                picFill.TileScaleX = 1f;
                picFill.TileScaleY = 1f;
                picFill.TileAlignment = RectangleAlignment.BottomRight;
                picFill.TileFlip = TileFlip.FlipBoth;
            }

            // Define output path
            string outputPath = Path.Combine(dataDir, "TilePictureFillPresentation.pptx");

            try
            {
                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
            }

            // Dispose presentation
            pres.Dispose();
        }
    }
}