using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main()
        {
            using (Presentation presentation = new Presentation())
            {
                try
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Load image bytes from file
                    byte[] imageBytes = File.ReadAllBytes("sample.jpg");

                    // Add image to the presentation's image collection
                    IPPImage image = presentation.Images.AddImage(imageBytes);

                    // Add a picture frame containing the image
                    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 300, 200, image);

                    // Set the line color of the picture frame to blue
                    pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
                    pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

                    // Save the presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}