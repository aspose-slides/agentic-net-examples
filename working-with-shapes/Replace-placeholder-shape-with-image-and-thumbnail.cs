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
            string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), "thumbnail.jpg");

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
                Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

                // Access the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Find a picture placeholder shape
                Aspose.Slides.IShape placeholderShape = null;
                foreach (Aspose.Slides.IShape shape in slide.Shapes)
                {
                    if (shape.Placeholder != null && shape.Placeholder.Type == Aspose.Slides.PlaceholderType.Picture)
                    {
                        placeholderShape = shape;
                        break;
                    }
                }

                // If placeholder found, replace it with the new image
                if (placeholderShape != null)
                {
                    // Store placeholder dimensions
                    float placeholderX = placeholderShape.X;
                    float placeholderY = placeholderShape.Y;
                    float placeholderWidth = placeholderShape.Width;
                    float placeholderHeight = placeholderShape.Height;

                    // Add the new image to the presentation's image collection
                    Aspose.Slides.IPPImage newImage = presentation.Images.AddImage(File.ReadAllBytes(imagePath));

                    // Remove the placeholder shape
                    slide.Shapes.Remove(placeholderShape);

                    // Add a picture frame with the new image at the same position
                    slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, placeholderX, placeholderY, placeholderWidth, placeholderHeight, newImage);
                }

                // Generate thumbnail of the first slide
                using (Aspose.Slides.IImage thumbnail = slide.GetImage(1f, 1f))
                {
                    thumbnail.Save(thumbnailPath, Aspose.Slides.ImageFormat.Jpeg);
                }

                // Save the modified presentation with refreshed thumbnail
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, new Aspose.Slides.Export.PptxOptions
                {
                    RefreshThumbnail = true
                });

                // Dispose the presentation
                presentation.Dispose();

                Console.WriteLine("Presentation updated and saved to: " + outputPath);
                Console.WriteLine("Thumbnail saved to: " + thumbnailPath);
            }
            catch (NotSupportedException)
            {
                // Format not supported
                // Handle unsupported file format here
                Console.WriteLine("The provided file format is not supported.");
            }
            catch (Exception ex)
            {
                // General exception handling (e.g., external URL issues)
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}