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
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Load an image from file
                using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
                {
                    Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

                    // Add a picture frame containing the image
                    Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        100f, 100f, 400f, 300f,
                        image);

                    // Rotate the picture frame 45 degrees clockwise
                    pictureFrame.Rotation = 45f;
                }

                // Save the modified presentation
                presentation.Save("RotatedPicture.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}