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

            // Access the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Load an image from file and add it to the presentation
            using (FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read))
            {
                Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

                // Add a picture frame to the slide
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    100f,   // X position
                    100f,   // Y position
                    400f,   // Width
                    300f,   // Height
                    image);

                // Set picture frame formatting
                pictureFrame.Rotation = 15f; // Rotate 15 degrees
                pictureFrame.LineFormat.Width = 2f;
                pictureFrame.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
                pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                // Set alternative text
                pictureFrame.AlternativeText = "Sample picture";
                pictureFrame.AlternativeTextTitle = "Picture Frame";
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