// -----------------------------------------------------------------------------
// Example: Add Rectangle Shape with Picture Fill and Crop Region using C#
// 
// Description:
// Demonstrates how to create a new PowerPoint presentation, add a rectangle
// shape filled with an image, apply cropping to the picture fill, and save the
// result as a PPTX file using Aspose.Slides for .NET. The program creates a
// placeholder image if none is found, making the example self‑contained.
// 
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, rectangle shape, picture fill, crop
// 
// Use Cases:
// - Automate insertion of images with custom crop areas into slides.
// - Generate presentations with programmatically controlled picture fills.
// - Prepare slide decks where image focus needs to be adjusted dynamically.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string imagePath = Path.Combine(dataDir, "image.jpg");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Create a placeholder image if it does not exist
            if (!File.Exists(imagePath))
            {
                try
                {
                    using (Bitmap bmp = new Bitmap(400, 300))
                    {
                        using (Graphics g = Graphics.FromImage(bmp))
                        {
                            g.Clear(Color.LightGray);
                            using (Pen pen = new Pen(Color.DarkGray, 5))
                            {
                                g.DrawRectangle(pen, 10, 10, 380, 280);
                            }
                            using (Font font = new Font("Arial", 24))
                            {
                                g.DrawString("Sample Image", font, Brushes.Black, new PointF(80, 130));
                            }
                        }
                        bmp.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create placeholder image: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            // Verify the image file exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Input image file not found: " + imagePath);
                Environment.Exit(1);
            }

            try
            {
                // Create a new presentation
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Load image bytes
                byte[] imageBytes = File.ReadAllBytes(imagePath);
                Aspose.Slides.IPPImage ppImage = presentation.Images.AddImage(imageBytes);

                // Add a rectangle shape
                Aspose.Slides.IAutoShape rectangle = slide.Shapes.AddAutoShape(
                    Aspose.Slides.ShapeType.Rectangle, 100, 100, 400, 300);

                // Apply picture fill
                rectangle.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                Aspose.Slides.IPictureFillFormat pictureFill = rectangle.FillFormat.PictureFillFormat;
                pictureFill.Picture.Image = ppImage;

                // Set cropping percentages (values between 0 and 1)
                pictureFill.CropTop = 0.1f;    // Crop 10% from top
                pictureFill.CropBottom = 0.1f; // Crop 10% from bottom
                pictureFill.CropLeft = 0.2f;   // Crop 20% from left
                pictureFill.CropRight = 0.2f;  // Crop 20% from right

                // Save the presentation
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
        }
    }
}
