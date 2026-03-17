using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SetPictureFrameLineWidth
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Load image bytes from a file
                byte[] imageBytes = File.ReadAllBytes("sample.jpg");

                // Add the image to the presentation's image collection
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageBytes);

                // Add a picture frame to the slide
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    100f, 100f, 300f, 200f,
                    image);

                // Set the line width of the picture frame
                pictureFrame.LineFormat.Width = 5f;

                // Save the presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}