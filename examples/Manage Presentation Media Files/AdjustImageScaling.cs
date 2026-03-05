using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PictureFrameScalingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get reference to the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Path to the image file to be added
            string imagePath = "sample.jpg";

            // Load image into presentation and add a picture frame
            using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    50,    // X position
                    50,    // Y position
                    300,   // Width
                    200,   // Height
                    image);

                // Adjust relative scaling to create a more complex frame
                pictureFrame.RelativeScaleWidth = 1.5f;   // 150% of original width
                pictureFrame.RelativeScaleHeight = 0.8f;  // 80% of original height
            }

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}