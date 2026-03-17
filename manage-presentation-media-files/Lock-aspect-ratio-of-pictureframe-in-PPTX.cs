using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Load an image from file
                System.IO.FileStream imageStream = System.IO.File.OpenRead("sample.jpg");
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
                imageStream.Dispose();

                // Add a picture frame to the slide
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    100f,
                    100f,
                    200f,
                    200f,
                    image);

                // Resize the picture frame
                pictureFrame.Width = 300f;
                pictureFrame.Height = 150f;

                // Lock the aspect ratio of the picture frame
                Aspose.Slides.IPictureFrameLock lockObj = pictureFrame.ShapeLock;
                lockObj.AspectRatioLocked = true;

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Clean up
                presentation.Dispose();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}