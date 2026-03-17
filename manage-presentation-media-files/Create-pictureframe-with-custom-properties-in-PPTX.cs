using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PictureFrameExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get reference to the first slide
                ISlide slide = presentation.Slides[0];

                // Load an image from file
                FileStream imageStream = new FileStream("sample_image.jpg", FileMode.Open, FileAccess.Read);
                IPPImage image = presentation.Images.AddImage(imageStream);
                imageStream.Dispose();

                // Add a picture frame to the slide with custom dimensions
                // ShapeType.Rectangle is a common picture frame type
                IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 100f, 150f, 300f, 200f, image);

                // Set visual properties
                pictureFrame.AlternativeText = "Sample picture frame";
                pictureFrame.Rotation = 15f; // Rotate 15 degrees clockwise
                pictureFrame.LineFormat.Width = 2f; // Set line width
                pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue; // Set line color

                // Save the presentation
                presentation.Save("PictureFrameOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

                // Dispose the presentation
                presentation.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}