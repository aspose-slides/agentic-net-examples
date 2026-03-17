using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PictureFrameDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];

                    // Load an image from file
                    using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
                    {
                        IPPImage image = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);

                        // Add a picture frame to the slide
                        IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 100f, 100f, 400f, 300f, image);

                        // Modify picture frame properties
                        pictureFrame.X = 150f;          // New X position
                        pictureFrame.Y = 120f;          // New Y position
                        pictureFrame.Width = 500f;      // New width
                        pictureFrame.Height = 350f;     // New height
                        pictureFrame.Rotation = 15f;    // Rotate 15 degrees
                    }

                    // Save the presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}