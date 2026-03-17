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
            using (Presentation presentation = new Presentation())
            {
                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Load an image from file
                using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
                {
                    // Add the image to the presentation's image collection
                    IPPImage image = presentation.Images.AddImage(imageStream);

                    // Add a picture frame to the slide using the image
                    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        50,
                        50,
                        image.Width,
                        image.Height,
                        image);

                    // Adjust relative scaling of the picture frame
                    pictureFrame.RelativeScaleWidth = 1.5f;   // 150% width
                    pictureFrame.RelativeScaleHeight = 1.2f; // 120% height
                }

                // Export the slide as a high‑resolution image using scaling factors
                float scaleX = 2f;
                float scaleY = 2f;
                using (IImage slideImage = slide.GetImage(scaleX, scaleY))
                {
                    slideImage.Save("slide_output.png", Aspose.Slides.ImageFormat.Png);
                }

                // Save the modified presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}