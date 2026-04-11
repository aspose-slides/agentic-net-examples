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
            // Path to the external image file (will be linked, not embedded)
            string externalImagePath = @"C:\Images\external.jpg";

            // Optional placeholder image to satisfy AddPictureFrame requirement
            string placeholderImagePath = @"C:\Images\placeholder.png";

            // Verify that the external image file exists
            if (!File.Exists(externalImagePath))
            {
                Console.WriteLine("External image file does not exist: " + externalImagePath);
                return;
            }

            // Verify that the placeholder image file exists
            if (!File.Exists(placeholderImagePath))
            {
                Console.WriteLine("Placeholder image file does not exist: " + placeholderImagePath);
                return;
            }

            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Load placeholder image into the presentation's image collection
            IImage placeholderImage = Images.FromFile(placeholderImagePath);
            IPPImage ppPlaceholderImage = presentation.Images.AddImage(placeholderImage);

            // Add a picture frame using the placeholder image
            IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                50f,   // X position
                150f,  // Y position
                ppPlaceholderImage.Width,
                ppPlaceholderImage.Height,
                ppPlaceholderImage);

            // Link the picture frame to the external image file (no embedding)
            pictureFrame.PictureFormat.Picture.LinkPathLong = externalImagePath;

            // Save the presentation
            string outputPath = @"C:\Output\LinkedImagePresentation.pptx";
            presentation.Save(outputPath, SaveFormat.Pptx);

            // Dispose the presentation
            presentation.Dispose();

            Console.WriteLine("Presentation saved to: " + outputPath);
        }
    }
}