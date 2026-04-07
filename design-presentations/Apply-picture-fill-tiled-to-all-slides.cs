using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SlideBackgroundTileExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and image file
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string imageFileName = "background.jpg";
            string imagePath = Path.Combine(dataDir, imageFileName);
            string outputPath = Path.Combine(dataDir, "PresentationWithTiledBackground.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

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

                // Load the image and add it to the presentation's image collection
                IImage img = Images.FromFile(imagePath);
                IPPImage ppImg = pres.Images.AddImage(img);

                // Apply tiled picture fill to each slide's background
                foreach (ISlide slide in pres.Slides)
                {
                    slide.Background.Type = BackgroundType.OwnBackground;
                    slide.Background.FillFormat.FillType = FillType.Picture;
                    IPictureFillFormat picFill = slide.Background.FillFormat.PictureFillFormat;
                    picFill.Picture.Image = ppImg;
                    picFill.PictureFillMode = PictureFillMode.Tile;
                    // Optional: set alignment and scaling for seamless tiling
                    picFill.TileAlignment = RectangleAlignment.TopLeft;
                    picFill.TileScaleX = 100;
                    picFill.TileScaleY = 100;
                }

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
                pres.Dispose();

                Console.WriteLine("Presentation saved successfully to: " + outputPath);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}