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
                    IPPImage image = presentation.Images.AddImage(imageStream);

                    // Get slide dimensions
                    float slideWidth = presentation.SlideSize.Size.Width;
                    float slideHeight = presentation.SlideSize.Size.Height;

                    // Define picture frame size as 50% of slide size and center it
                    float pictureWidth = slideWidth * 0.5f;
                    float pictureHeight = slideHeight * 0.5f;
                    float pictureX = (slideWidth - pictureWidth) / 2;
                    float pictureY = (slideHeight - pictureHeight) / 2;

                    // Add picture frame to the slide
                    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, pictureX, pictureY, pictureWidth, pictureHeight, image);

                    // Set relative scaling to maintain original aspect ratio
                    pictureFrame.RelativeScaleWidth = 1.0f;
                    pictureFrame.RelativeScaleHeight = 1.0f;
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