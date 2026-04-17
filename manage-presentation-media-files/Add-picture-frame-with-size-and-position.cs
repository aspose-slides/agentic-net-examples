using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PictureFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Define input image path
            string imagePath = Path.Combine(dataDir, "image.jpg");
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Input image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            try
            {
                // Load image and add to presentation resources
                IImage img = Images.FromFile(imagePath);
                IPPImage image = presentation.Images.AddImage(img);

                // Add picture frame at (100,150) with explicit width and height
                IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    100f,
                    150f,
                    200f,   // width
                    150f,   // height
                    image);

                // Save the presentation
                string outPath = Path.Combine(dataDir, "output.pptx");
                presentation.Save(outPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Ensure the presentation is disposed
                presentation.Dispose();
            }
        }
    }
}