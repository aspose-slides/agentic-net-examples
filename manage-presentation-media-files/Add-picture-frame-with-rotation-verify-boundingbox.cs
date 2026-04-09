using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define data directory
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Define image path
        string imagePath = Path.Combine(dataDir, "sample.jpg");
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        Presentation presentation = null;
        try
        {
            // Create a new presentation
            presentation = new Presentation();
            ISlide slide = presentation.Slides[0];

            // Load image and add to presentation resources
            IImage img = Images.FromFile(imagePath);
            IPPImage imgx = presentation.Images.AddImage(img);

            // Add picture frame with the image
            IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 100f, 100f, imgx.Width, imgx.Height, imgx);

            // Set custom rotation angle of 30 degrees
            pictureFrame.Rotation = 30f;

            // Verify bounding box properties
            float x = pictureFrame.X;
            float y = pictureFrame.Y;
            float width = pictureFrame.Width;
            float height = pictureFrame.Height;
            Console.WriteLine($"Bounding Box - X:{x}, Y:{y}, Width:{width}, Height:{height}, Rotation:{pictureFrame.Rotation}");

            // Save the presentation
            string outPath = Path.Combine(dataDir, "output.pptx");
            presentation.Save(outPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle errors such as unsupported format
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            if (presentation != null)
            {
                presentation.Dispose();
            }
        }
    }
}