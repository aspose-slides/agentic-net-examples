using System;
using System.IO;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Path to the source image file
                string imagePath = "image.png";

                // Read the image file into a byte array
                byte[] imageData = File.ReadAllBytes(imagePath);

                // Create a new presentation
                using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
                {
                    // Add the image to the presentation's image collection
                    Aspose.Slides.IPPImage addedImage = presentation.Images.AddImage(imageData);

                    // Insert the image onto the first slide as a picture frame
                    Aspose.Slides.IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        0,
                        0,
                        300,
                        200,
                        addedImage);

                    // Save the presentation to a file
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}