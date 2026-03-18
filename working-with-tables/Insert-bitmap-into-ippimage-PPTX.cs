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
            // Path to the bitmap image file
            string imagePath = "sample.png";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Read image bytes
                byte[] imageBytes = File.ReadAllBytes(imagePath);

                // Add the image to the presentation and obtain an IPPImage instance
                Aspose.Slides.IPPImage img = pres.Images.AddImage(imageBytes);

                // Insert the image into the first slide as a picture frame
                pres.Slides[0].Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    50,    // X position
                    50,    // Y position
                    400,   // Width
                    300,   // Height
                    img);

                // Save the presentation before exiting
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}