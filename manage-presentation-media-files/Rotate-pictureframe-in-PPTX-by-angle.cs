using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace RotatePictureFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Load image bytes
                byte[] imageBytes = File.ReadAllBytes("image.png");

                // Add image to presentation resources
                IPPImage image = presentation.Images.AddImage(imageBytes);

                // Add picture frame to the first slide
                IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    100f,   // X position
                    100f,   // Y position
                    300f,   // Width
                    200f,   // Height
                    image);

                // Rotate the picture frame (positive for clockwise, negative for counter‑clockwise)
                pictureFrame.Rotation = 45f; // Rotate 45 degrees clockwise

                // Save the presentation
                presentation.Save("RotatedPictureFrame.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}