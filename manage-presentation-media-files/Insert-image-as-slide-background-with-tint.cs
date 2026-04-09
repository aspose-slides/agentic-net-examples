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