using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
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

                // Load an image from file
                using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
                {
                    // Add the image to the presentation's image collection
                    Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                    // Use the image's dimensions for the picture frame
                    float pictureWidth = image.Width;
                    float pictureHeight = image.Height;

                    // Add a picture frame to the slide using the image
                    Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        0,
                        0,
                        pictureWidth,
                        pictureHeight,
                        image);
                }

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}