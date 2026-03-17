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
            // Path to the image file
            string imagePath = "image.png";

            // Load the image into a byte array
            byte[] imageBytes = File.ReadAllBytes(imagePath);

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageBytes);

                // Add a picture frame to the first slide using the added image
                Aspose.Slides.IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    0, 0, 300, 200,
                    image);

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}