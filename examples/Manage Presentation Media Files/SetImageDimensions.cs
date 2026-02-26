using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Load an image file into the presentation's image collection
        using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
        {
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

            // Add a picture frame to the slide
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                50,    // X position
                50,    // Y position
                200,   // Width
                200,   // Height
                image);

            // Set relative width and height (e.g., 150% width, 80% height)
            pictureFrame.RelativeScaleWidth = 1.5f;   // 150%
            pictureFrame.RelativeScaleHeight = 0.8f;  // 80%
        }

        // Save the presentation
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}