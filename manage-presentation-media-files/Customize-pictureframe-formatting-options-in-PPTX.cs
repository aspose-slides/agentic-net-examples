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
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Access the first slide
            ISlide slide = presentation.Slides[0];

            // Path to the image file
            string imagePath = "sample.jpg";

            // Load the image into a stream
            FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);

            // Add the image to the presentation and obtain an IPPImage instance
            IPPImage image = presentation.Images.AddImage(imageStream);
            imageStream.Close();

            // Insert a picture frame containing the image
            IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                100f,   // X position
                100f,   // Y position
                300f,   // Width
                200f,   // Height
                image   // IPPImage instance
            );

            // Apply formatting options to the picture frame
            pictureFrame.Rotation = 45f;                     // Rotate 45 degrees
            pictureFrame.Width = 400f;                       // Set new width
            pictureFrame.Height = 250f;                      // Set new height
            pictureFrame.RelativeScaleWidth = 1.2f;          // Scale width to 120%
            pictureFrame.RelativeScaleHeight = 1.2f;         // Scale height to 120%
            pictureFrame.AlternativeText = "Sample picture";

            // Save the modified presentation
            presentation.Save("output.pptx", SaveFormat.Pptx);

            // Clean up resources
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}