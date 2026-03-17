using System;
using System.IO;
using Aspose.Slides.Export;

namespace SetImageSize
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

                // Path to the image file to be added
                string imagePath = "sample.jpg";

                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage img = pres.Images.AddImage(File.ReadAllBytes(imagePath));

                // Add a picture frame shape to the first slide using the added image
                Aspose.Slides.IShape shape = pres.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    0, 0, 100, 100, img);

                // Cast the shape to a picture frame to modify its dimensions
                Aspose.Slides.IPictureFrame pictureFrame = (Aspose.Slides.IPictureFrame)shape;
                pictureFrame.Width = 400;   // Set desired width
                pictureFrame.Height = 300;  // Set desired height

                // Save the presentation
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}