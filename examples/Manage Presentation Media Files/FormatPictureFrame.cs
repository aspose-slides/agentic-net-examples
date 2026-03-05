using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace PictureFrameFormattingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Load an image from file
            FileStream imageStream = new FileStream("sample.jpg", FileMode.Open, FileAccess.Read);
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);
            imageStream.Dispose();

            // Add a picture frame to the first slide
            Aspose.Slides.IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                100f,   // X position
                100f,   // Y position
                300f,   // Width
                200f,   // Height
                image);

            // Set alternative text
            pictureFrame.AlternativeText = "Sample picture";
            pictureFrame.AlternativeTextTitle = "Picture Title";

            // Apply rotation
            pictureFrame.Rotation = 45f;

            // Adjust size and position
            pictureFrame.X = 50f;
            pictureFrame.Y = 50f;
            pictureFrame.Width = 400f;
            pictureFrame.Height = 300f;

            // Scale relative to original picture size
            pictureFrame.RelativeScaleWidth = 0.8f;
            pictureFrame.RelativeScaleHeight = 0.8f;

            // Set decorative flag and visibility
            pictureFrame.IsDecorative = true;
            pictureFrame.Hidden = false;

            // Configure line format (border)
            pictureFrame.LineFormat.Width = 5f;
            pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
            pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;

            // Configure fill format (background of the frame)
            pictureFrame.FillFormat.FillType = FillType.Solid;
            pictureFrame.FillFormat.SolidFillColor.Color = Color.LightBlue;

            // Save the presentation
            presentation.Save("FormattedPictureFrame_out.pptx", SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();
        }
    }
}