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
                // Load image file into a stream
                using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
                {
                    // Add image to the presentation's image collection
                    IPPImage image = presentation.Images.AddImage(imageStream);
                    // Retrieve image dimensions
                    float imageWidth = (float)image.Width;
                    float imageHeight = (float)image.Height;
                    // Access the first slide
                    ISlide slide = presentation.Slides[0];
                    // Add a picture frame sized to the image dimensions
                    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, imageWidth, imageHeight, image);
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