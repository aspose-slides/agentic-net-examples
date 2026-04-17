using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AddImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and image file name
            string dataDir = "Data";
            string imageFileName = "image.jpg";

            // Ensure the data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Build full image path
            string imagePath = Path.Combine(dataDir, imageFileName);

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            Presentation pres = new Presentation();

            try
            {
                // Get the first slide
                ISlide slide = pres.Slides[0];

                // Load the image from file
                IImage img = Images.FromFile(imagePath);

                // Add the image to the presentation's image collection
                IPPImage imgx = pres.Images.AddImage(img);

                // Add a picture frame to the first slide
                slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0f, 0f, 300f, 200f, imgx);

                // Define output path
                string outPath = Path.Combine(dataDir, "output.pptx");

                // Save the presentation
                pres.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // If the format is not supported, comment accordingly
                // Format not supported
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Dispose the presentation object
                pres.Dispose();
            }
        }
    }
}