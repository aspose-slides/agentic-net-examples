using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace LinkedImageExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the external image file (will be linked, not embedded)
            string externalImagePath = "large_image.jpg";

            // Create a new presentation
            using (Presentation pres = new Presentation())
            {
                // Add the external image as a picture frame on the first slide
                // First, add a placeholder image (can be a small dummy image)
                // Here we use a 1x1 pixel transparent PNG created in memory
                byte[] dummyImageBytes = new byte[]
                {
                    0x89,0x50,0x4E,0x47,0x0D,0x0A,0x1A,0x0A,
                    0x00,0x00,0x00,0x0D,0x49,0x48,0x44,0x52,
                    0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,
                    0x08,0x06,0x00,0x00,0x00,0x1F,0x15,0xC4,
                    0x89,0x00,0x00,0x00,0x0A,0x49,0x44,0x41,
                    0x54,0x78,0x9C,0x63,0x00,0x01,0x00,0x00,
                    0x05,0x00,0x01,0x0D,0x0A,0x2D,0xB4,0x00,
                    0x00,0x00,0x00,0x49,0x45,0x4E,0x44,0xAE,
                    0x42,0x60,0x82
                };
                IPPImage dummyImage = pres.Images.AddImage(dummyImageBytes);

                // Add picture frame using the dummy image
                ISlidesPicture picture = pres.Slides[0].Shapes.AddPictureFrame(
                    ShapeType.Rectangle, 50, 50, 400, 300, dummyImage) as ISlidesPicture;

                // Set the link to the external image file
                picture.LinkPathLong = externalImagePath;

                // Save the presentation
                pres.Save("LinkedImagePresentation.pptx", SaveFormat.Pptx);
            }
        }
    }
}