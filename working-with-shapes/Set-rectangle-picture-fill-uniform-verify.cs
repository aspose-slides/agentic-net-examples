using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define data directory
                string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
                if (!Directory.Exists(dataDir))
                {
                    Directory.CreateDirectory(dataDir);
                }

                // Define input image path
                string imageFileName = "image.jpg";
                string imagePath = Path.Combine(dataDir, imageFileName);

                // Verify input image exists
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine("Input image not found: " + imagePath);
                    return;
                }

                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Load image and add to presentation resources
                IImage img = Images.FromFile(imagePath);
                IPPImage ppImg = pres.Images.AddImage(img);

                // Define rectangle shape dimensions based on image size
                float shapeX = 50f;
                float shapeY = 50f;
                float shapeWidth = ppImg.Width;
                float shapeHeight = ppImg.Height;

                // Add rectangle auto shape
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, shapeX, shapeY, shapeWidth, shapeHeight);

                // Set picture fill
                shape.FillFormat.FillType = FillType.Picture;
                IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                picFill.Picture.Image = ppImg;

                // Set stretch mode (uniform) and lock aspect ratio by using stretch mode
                picFill.PictureFillMode = PictureFillMode.Stretch;

                // Verify that aspect ratio remains unchanged
                float imageRatio = (float)ppImg.Width / ppImg.Height;
                float shapeRatio = shape.Width / shape.Height;
                bool aspectUnchanged = Math.Abs(imageRatio - shapeRatio) < 0.01f;
                Console.WriteLine("Aspect ratio unchanged: " + aspectUnchanged);

                // Save the presentation
                string outputFileName = "output.pptx";
                string outPath = Path.Combine(dataDir, outputFileName);
                pres.Save(outPath, SaveFormat.Pptx);

                // Dispose presentation
                pres.Dispose();
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other exceptions
                Console.WriteLine("An error occurred: " + ex.Message);
                // Format not supported comment
                // The provided file format may not be supported by Aspose.Slides.
            }
        }
    }
}