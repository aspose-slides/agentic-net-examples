using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationMedia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and ensure it exists
            string dataDir = "Data";
            if (!Directory.Exists(dataDir))
                Directory.CreateDirectory(dataDir);

            // Path to the image file to be added
            string imagePath = Path.Combine(dataDir, "image.jpg");

            // Create a new presentation
            Presentation pres = new Presentation();

            // Get the first slide
            ISlide slide = pres.Slides[0];

            // Load the image from file
            IImage image = Images.FromFile(imagePath);

            // Add the image to the presentation's image collection
            IPPImage imgx = pres.Images.AddImage(image);

            // Add a picture frame to the slide using the image
            IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                50,    // X position
                50,    // Y position
                imgx.Width,
                imgx.Height,
                imgx);

            // Apply line formatting to the picture frame
            pictureFrame.LineFormat.FillFormat.FillType = FillType.Solid;
            pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
            pictureFrame.LineFormat.Width = 2; // Line width
            pictureFrame.Rotation = 0; // No rotation

            // Save the presentation
            string outPath = Path.Combine(dataDir, "output.pptx");
            pres.Save(outPath, SaveFormat.Pptx);

            // Release resources
            pres.Dispose();
        }
    }
}