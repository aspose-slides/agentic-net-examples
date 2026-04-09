using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ApplyDropShadow
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the image file to be added
            string imagePath = "sample.jpg";

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get reference to the first slide
                ISlide slide = presentation.Slides[0];

                // Load the image into the presentation as IPPImage
                IPPImage image;
                try
                {
                    using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        image = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to load image: " + ex.Message);
                    return;
                }

                // Add a picture frame containing the image
                IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 300, 200, image);

                // Apply a drop shadow effect using the EffectFormat API
                // Enable outer shadow effect and configure its properties
                pictureFrame.EffectFormat.EnableOuterShadowEffect();
                pictureFrame.EffectFormat.OuterShadowEffect.BlurRadius = 5.0;
                pictureFrame.EffectFormat.OuterShadowEffect.Direction = 45.0f;
                pictureFrame.EffectFormat.OuterShadowEffect.Distance = 3.0;
                pictureFrame.EffectFormat.OuterShadowEffect.ShadowColor.Color = System.Drawing.Color.Black;

                // Save the presentation
                try
                {
                    presentation.Save("DropShadowOutput.pptx", SaveFormat.Pptx);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to save presentation: " + ex.Message);
                }
            }
        }
    }
}