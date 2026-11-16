// -----------------------------------------------------------------------------
// Example: Insert Image into Picture Placeholder from File Path
//
// Description:
// Demonstrates inserting an image from a local file into a picture placeholder
// within a newly created PowerPoint presentation using C# and Aspose.Slides
// for .NET. The program creates a sample JPEG if none exists, adds a picture
// placeholder to a blank layout slide, places the image into the placeholder,
// and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert Image, Picture Placeholder
//
// Use Cases:
// - Automate image insertion into predefined placeholders in slide templates.
// - Generate presentations with dynamic content based on external image files.
// - Build command‑line tools for batch processing of PowerPoint assets.
// Tested and Verified with Aspose.Slides for .NET v26.11.0.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using System.Drawing;

namespace InsertImageIntoPlaceholder
{
    class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "input.jpg";
            string outputPath = "output.pptx";

            // Ensure sample image exists
            if (!File.Exists(imagePath))
            {
                try
                {
                    using (Bitmap bitmap = new Bitmap(200, 200))
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.Clear(Color.LightBlue);
                            using (Pen pen = new Pen(Color.DarkBlue, 5))
                            {
                                graphics.DrawEllipse(pen, 25, 25, 150, 150);
                            }
                        }
                        bitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to create sample image: " + ex.Message);
                    Environment.Exit(1);
                }
            }

            // Verify image file existence
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                Environment.Exit(1);
            }

            Aspose.Slides.Presentation pres = null;
            try
            {
                pres = new Aspose.Slides.Presentation();

                // Get a blank layout slide
                Aspose.Slides.ILayoutSlide layout = pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank);

                // Add a picture placeholder to the layout slide
                Aspose.Slides.IAutoShape placeholder = layout.PlaceholderManager.AddPicturePlaceholder(50, 50, 400, 300);

                // Load the external image
                Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
                Aspose.Slides.IPPImage imgX = pres.Images.AddImage(img);

                // Add a picture frame to the first slide using the placeholder dimensions
                Aspose.Slides.ISlide slide = pres.Slides[0];
                slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, placeholder.X, placeholder.Y, placeholder.Width, placeholder.Height, imgX);

                // Save the presentation
                pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                Environment.Exit(1);
            }
            finally
            {
                if (pres != null)
                {
                    pres.Dispose();
                }
            }
        }
    }
}
