using System;
using System.IO;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Load image file into stream
            FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read);
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
            imageStream.Close();

            // Add picture frame to slide
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                100f, // X position
                100f, // Y position
                200f, // Width
                200f, // Height
                image);

            // Set relative width and height (e.g., 50% of original size)
            pictureFrame.RelativeScaleWidth = 0.5f;
            pictureFrame.RelativeScaleHeight = 0.5f;

            // Save the presentation
            presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}