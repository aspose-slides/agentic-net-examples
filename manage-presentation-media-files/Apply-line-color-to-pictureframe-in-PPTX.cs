using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Load an image from file
            using (FileStream imageStream = new FileStream("image.jpg", FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

                // Add a picture frame to the slide
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    50, 50, 300, 200,
                    image);

                // Set the line color of the picture frame to blue
                pictureFrame.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                pictureFrame.LineFormat.Width = 5; // optional line width
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