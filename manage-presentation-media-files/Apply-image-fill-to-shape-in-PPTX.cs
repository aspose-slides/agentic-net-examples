using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyImageFillToShape
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define directories and file paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string imagePath = Path.Combine(dataDir, "sample.jpg");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure the data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Create a new presentation
            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Add a rectangle shape
                Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle,
                    100, 100, 400, 300);

                // Set the fill type to picture
                shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;

                // Load the image from file and add it to the presentation's image collection
                Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
                Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

                // Assign the image to the shape's picture fill format
                Aspose.Slides.IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                picFill.Picture.Image = ppImg;

                // Set the picture fill mode (optional)
                picFill.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                // Dispose the presentation if it was created
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}