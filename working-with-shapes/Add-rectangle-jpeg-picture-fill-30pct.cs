// -----------------------------------------------------------------------------
// Example: Add rectangle jpeg picture fill 30pct using C#
//
// Description:
// Demonstrates how to add a rectangle shape filled with a JPEG picture at
// 30% transparency using C# and Aspose.Slides for .NET. The example creates a
// new presentation, inserts a rectangle, applies a JPEG image as a picture
// fill, adjusts the fill transparency to 30%, and saves the result as a PPTX
// file. This pattern can be used to automate PowerPoint image‑fill workflows
// in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, JPEG, Rectangle, Picture Fill,
// Transparency, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding rectangle shapes with JPEG picture fills at a specific
//   transparency level.
// - Build C# tools for PowerPoint presentation processing that involve image
//   fills.
// - Generate or transform PPTX files with customized shape styling in .NET
//   applications.
// - Validate picture‑fill workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Effects;

namespace AddRectangleJpegPictureFill30Pct
{
    class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "sample.jpg";
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            try
            {
                using (Presentation presentation = new Presentation())
                {
                    ISlide slide = presentation.Slides[0];

                    // Add a rectangle shape
                    IAutoShape rectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 300);

                    // Load JPEG image from file stream
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    IPPImage pictureImage = presentation.Images.AddImage(imageBytes);

                    // Set picture fill
                    rectangle.FillFormat.FillType = FillType.Picture;
                    rectangle.FillFormat.PictureFillFormat.Picture.Image = pictureImage;

                    // Adjust picture fill transparency to 30%
                    rectangle.FillFormat.PictureFillFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(30f);

                    // Save the presentation
                    presentation.Save("output.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
