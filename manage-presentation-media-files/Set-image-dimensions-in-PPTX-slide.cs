using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Define directories and file paths
            string dataDir = "Data";
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            string imagePath = Path.Combine(dataDir, "image.jpg");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Create a new presentation
            using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
            {
                // Add the image to the presentation's image collection
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                Aspose.Slides.IPPImage img = pres.Images.AddImage(imageBytes);

                // Access the first slide
                Aspose.Slides.ISlide slide = pres.Slides[0];

                // Define explicit position and size for the picture frame (in points)
                float x = 50f;      // X-coordinate
                float y = 50f;      // Y-coordinate
                float width = 300f; // Desired width
                float height = 200f; // Desired height

                // Add a picture frame with the specified dimensions
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    x,
                    y,
                    width,
                    height,
                    img);

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}