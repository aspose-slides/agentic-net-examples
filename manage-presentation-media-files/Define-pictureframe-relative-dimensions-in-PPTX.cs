using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Load an image from file
                FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read);
                IPPImage image = presentation.Images.AddImage(imageStream);
                imageStream.Close();

                // Add a picture frame to the slide
                IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    ShapeType.Rectangle,
                    50,    // X position
                    50,    // Y position
                    300,   // Width
                    200,   // Height
                    image);

                // Set relative width and height (e.g., 75% of original size)
                pictureFrame.RelativeScaleWidth = 0.75f;
                pictureFrame.RelativeScaleHeight = 0.75f;

                // Save the presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}