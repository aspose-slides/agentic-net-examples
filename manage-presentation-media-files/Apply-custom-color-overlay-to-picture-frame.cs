using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using System.Drawing;

namespace ApplyColorOverlay
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the image file to be used in the picture frame
            string imagePath = "sample.jpg";

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Load the image into the presentation's image collection
                Aspose.Slides.IPPImage image;
                try
                {
                    using (FileStream imgStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        image = presentation.Images.AddImage(imgStream);
                    }
                }
                catch (Exception ex)
                {
                    // Handle unsupported image format
                    Console.WriteLine("Failed to load image. Format may not be supported. " + ex.Message);
                    return;
                }

                // Add a picture frame containing the image
                Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    50, 50, 400, 300,
                    image);

                // Apply a semi‑transparent solid color overlay using the shape's FillFormat
                // Set fill type to Solid
                pictureFrame.FillFormat.FillType = Aspose.Slides.FillType.Solid;

                // Set the overlay color (e.g., semi‑transparent red)
                pictureFrame.FillFormat.SolidFillColor.Color = Color.FromArgb(128, Color.Red);

                // Save the presentation
                try
                {
                    presentation.Save("ColorOverlayOutput.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to save presentation: " + ex.Message);
                }
            }
        }
    }
}