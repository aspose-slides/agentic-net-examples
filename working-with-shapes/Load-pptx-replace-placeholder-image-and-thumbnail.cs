// -----------------------------------------------------------------------------
// Example: Load pptx replace placeholder image and thumbnail using C#
//
// Description:
// Demonstrates how to load a PPTX file, replace a placeholder shape with a new
// image, generate a thumbnail of the inserted shape, and save the presentation
// with an updated thumbnail using Aspose.Slides for .NET. The example shows the
// required steps for presentation processing and image handling in a console
// application.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Load, Replace, Placeholder,
// Image, Thumbnail, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate replacement of placeholder images in existing PPTX files.
// - Generate shape thumbnails for documentation or preview purposes.
// - Build .NET tools that modify and refresh PowerPoint presentations.
// - Validate and process PPTX workflows before publishing or integration.
// -----------------------------------------------------------------------------
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
            // Define file paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "input.pptx");
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "newImage.png");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pptx");
            string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), "shapeThumbnail.png");

            // Verify input files exist
            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input presentation not found: " + inputPath);
                return;
            }

            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            try
            {
                // Load the presentation
                Presentation presentation = new Presentation(inputPath);

                // Access the first slide
                ISlide slide = presentation.Slides[0];

                // Assume the first shape is a placeholder to be replaced
                IShape placeholderShape = slide.Shapes[0];

                // Remove the placeholder shape
                slide.Shapes.Remove(placeholderShape);

                // Add the new image to the presentation's image collection
                using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    IPPImage ppImage = presentation.Images.AddImage(imageStream, LoadingStreamBehavior.KeepLocked);

                    // Add a picture frame using the dimensions of the removed placeholder
                    IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
                        ShapeType.Rectangle,
                        placeholderShape.X,
                        placeholderShape.Y,
                        placeholderShape.Width,
                        placeholderShape.Height,
                        ppImage);

                    // Generate a thumbnail of the newly added shape
                    IImage shapeThumbnail = pictureFrame.GetImage(ShapeThumbnailBounds.Shape, 1f, 1f);
                    shapeThumbnail.Save(thumbnailPath, ImageFormat.Png);
                }

                // Save the presentation and refresh its thumbnail
                presentation.Save(outputPath, SaveFormat.Pptx, new PptxOptions
                {
                    RefreshThumbnail = true
                });

                // Clean up
                presentation.Dispose();
            }
            catch (NotSupportedException ex)
            {
                // Handle unsupported file format
                Console.WriteLine("The file format is not supported: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General exception handling
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
