using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define data directory and ensure it exists
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Input image path and output presentation path
            string imagePath = Path.Combine(dataDir, "image.png");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Load image from file
            Aspose.Slides.IImage image = Aspose.Slides.Images.FromFile(imagePath);

            // Add image to presentation's image collection
            Aspose.Slides.IPPImage ipPImage = presentation.Images.AddImage(image);

            // Add picture frame to the slide using the image dimensions
            float xPos = 50f;
            float yPos = 50f;
            Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                xPos,
                yPos,
                ipPImage.Width,
                ipPImage.Height,
                ipPImage);

            // Set line formatting for the picture frame
            pictureFrame.LineFormat.FillFormat.FillType = Aspose.Slides.FillType.Solid;
            pictureFrame.LineFormat.FillFormat.SolidFillColor.Color = System.Drawing.Color.Blue;
            pictureFrame.LineFormat.Width = 5f;

            // Set rotation (no rotation in this example)
            pictureFrame.Rotation = 0f;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up
            presentation.Dispose();
        }
    }
}