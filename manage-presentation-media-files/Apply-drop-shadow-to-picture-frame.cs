// -----------------------------------------------------------------------------
// Example: Apply drop shadow to picture frame using C#
//
// Description:
// Demonstrates how to apply a drop shadow effect to a picture frame using C#
// and Aspose.Slides for .NET. The example loads an external image, inserts it
// into a new presentation as a picture frame, configures the outer shadow
// properties, and saves the resulting PPTX file. This pattern can be used to
// automate PowerPoint presentation enhancements, validate visual effects, or
// integrate shadow styling into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Drop, Shadow, Picture,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying a drop shadow to picture frames in presentations.
// - Build C# tools for enhancing visual appearance of PowerPoint slides.
// - Generate or transform PPTX files with custom styling in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

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
