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
            // Define directories and file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            string imagePath = Path.Combine(dataDir, "image.jpg");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Verify that the image file exists
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

                // Load the image and add it to the presentation's image collection
                IImage img = Images.FromFile(imagePath);
                IPPImage ppImg = pres.Images.AddImage(img);

                // Add a picture frame to the slide
                IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    50,   // X position
                    50,   // Y position
                    ppImg.Width,
                    ppImg.Height,
                    ppImg);

                // Set the picture fill format to Tile mode and configure offsets and scales
                pictureFrame.PictureFormat.PictureFillMode = PictureFillMode.Tile;
                IPictureFillFormat picFill = pictureFrame.PictureFormat;
                picFill.TileOffsetX = 10f;          // Horizontal offset in points
                picFill.TileOffsetY = 20f;          // Vertical offset in points
                picFill.TileScaleX = 150f;          // Horizontal scale as percentage
                picFill.TileScaleY = 150f;          // Vertical scale as percentage
                picFill.TileAlignment = RectangleAlignment.BottomRight;
                picFill.TileFlip = TileFlip.FlipBoth;

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}