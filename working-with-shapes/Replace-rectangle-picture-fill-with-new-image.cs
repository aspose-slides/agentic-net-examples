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
            // Define paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string firstImagePath = Path.Combine(dataDir, "image1.jpg");
            string secondImagePath = Path.Combine(dataDir, "image2.jpg");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Verify input images exist
            if (!File.Exists(firstImagePath) || !File.Exists(secondImagePath))
            {
                Console.WriteLine("One or both input image files do not exist.");
                return;
            }

            try
            {
                // Create a new presentation
                Presentation pres = new Presentation();

                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Load first image and add to presentation
                IImage firstImg = Images.FromFile(firstImagePath);
                IPPImage firstPpImg = pres.Images.AddImage(firstImg);

                // Add a rectangle shape with picture fill using the first image
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, firstPpImg.Width, firstPpImg.Height);
                shape.FillFormat.FillType = FillType.Picture;
                IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                picFill.Picture.Image = firstPpImg;

                // Load second image and add to presentation
                IImage secondImg = Images.FromFile(secondImagePath);
                IPPImage secondPpImg = pres.Images.AddImage(secondImg);

                // Replace the picture in the shape without changing its size
                picFill.Picture.Image = secondPpImg;

                // Save the presentation
                pres.Save(outputPath, SaveFormat.Pptx);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // Handle other exceptions (e.g., web service errors)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}