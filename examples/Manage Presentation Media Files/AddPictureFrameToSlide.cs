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

        // Open the image file stream
        System.IO.FileStream imageStream = new System.IO.FileStream("image.jpg", System.IO.FileMode.Open, System.IO.FileAccess.Read);

        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

        // Close the image stream
        imageStream.Close();

        // Add a picture frame containing the image to the slide
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50f,   // X position
            50f,   // Y position
            300f,  // Width
            200f,  // Height
            image);

        // Save the presentation in PPTX format
        presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation object
        presentation.Dispose();
    }
}