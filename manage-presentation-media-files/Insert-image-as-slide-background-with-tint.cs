// -----------------------------------------------------------------------------
// Example: Insert image as slide background with tint using C#
//
// Description:
// Demonstrates how to set an image as the background of a slide and apply a
// semi‑transparent color tint overlay using Aspose.Slides for .NET. The example
// creates a new presentation, adds a background picture, overlays a 50%
// transparent blue rectangle to achieve the tint effect, and saves the result.
// This pattern can be used to programmatically style slides with tinted
// backgrounds in .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Image, Slide, 
// Background, Tint, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding a tinted image background to PowerPoint slides.
// - Build C# utilities for customizing slide appearance with color overlays.
// - Generate or modify PPTX files with branded background styles in .NET.
// - Validate visual presentation workflows before publishing.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertImageBackgroundWithTint
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the background image file
            string imagePath = "background.jpg";

            // Verify that the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Error: Image file not found at path: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                using (Presentation pres = new Presentation())
                {
                    // Load image bytes and add to the presentation's image collection
                    byte[] imageBytes = File.ReadAllBytes(imagePath);
                    IPPImage backgroundImage = pres.Images.AddImage(imageBytes);

                    // Configure the first slide's background to use the image
                    IBackground slideBackground = pres.Slides[0].Background;
                    slideBackground.Type = BackgroundType.OwnBackground;
                    slideBackground.FillFormat.FillType = FillType.Picture;
                    slideBackground.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
                    slideBackground.FillFormat.PictureFillFormat.Picture.Image = backgroundImage;

                    // Add a semi‑transparent overlay rectangle covering the whole slide
                    float slideWidth = pres.SlideSize.Size.Width;
                    float slideHeight = pres.SlideSize.Size.Height;
                    IShape overlayShape = pres.Slides[0].Shapes.AddAutoShape(
                        ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
                    overlayShape.FillFormat.FillType = FillType.Solid;
                    // 50% transparent blue overlay
                    overlayShape.FillFormat.SolidFillColor.Color = Color.FromArgb(128, Color.Blue);

                    // Save the presentation
                    pres.Save("OutputWithBackgroundAndTint.pptx", SaveFormat.Pptx);
                }
            }
            catch (NotSupportedException)
            {
                // Format not supported
                Console.WriteLine("Error: The specified file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }
    }
}
