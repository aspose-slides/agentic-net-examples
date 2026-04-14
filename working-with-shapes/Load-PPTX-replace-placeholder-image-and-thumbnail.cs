using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define file names
        string inputFileName = "input.pptx";
        string outputFileName = "output.pptx";
        string thumbnailPath = "shape_thumbnail.png";
        string newImageFileName = "newImage.png";

        // Build full paths
        string inputPath = Path.Combine(Directory.GetCurrentDirectory(), inputFileName);
        string outputPath = Path.Combine(Directory.GetCurrentDirectory(), outputFileName);
        string newImagePath = Path.Combine(Directory.GetCurrentDirectory(), newImageFileName);

        // Check if input presentation exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input presentation not found.");
            return;
        }

        try
        {
            // Load the presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation(inputPath);

            // Find the first placeholder shape on the first slide
            Aspose.Slides.IShape placeholderShape = null;
            foreach (Aspose.Slides.IShape shape in presentation.Slides[0].Shapes)
            {
                if (shape.Placeholder != null)
                {
                    placeholderShape = shape;
                    break;
                }
            }

            if (placeholderShape != null && File.Exists(newImagePath))
            {
                // Add the new image to the presentation's image collection
                using (FileStream imgStream = new FileStream(newImagePath, FileMode.Open, FileAccess.Read))
                {
                    Aspose.Slides.IPPImage newImg = presentation.Images.AddImage(imgStream, Aspose.Slides.LoadingStreamBehavior.KeepLocked);

                    // Preserve original placeholder dimensions and position
                    float x = placeholderShape.X;
                    float y = placeholderShape.Y;
                    float width = placeholderShape.Width;
                    float height = placeholderShape.Height;

                    // Remove the placeholder shape
                    presentation.Slides[0].Shapes.Remove(placeholderShape);

                    // Insert a picture frame with the new image
                    presentation.Slides[0].Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, x, y, width, height, newImg);
                }
            }
            else
            {
                Console.WriteLine("Placeholder shape not found or new image file missing.");
            }

            // Generate thumbnail of the first shape on the slide (the newly added picture frame)
            if (presentation.Slides[0].Shapes.Count > 0)
            {
                Aspose.Slides.IShape firstShape = presentation.Slides[0].Shapes[0];
                Aspose.Slides.IImage shapeThumbnail = firstShape.GetImage(Aspose.Slides.ShapeThumbnailBounds.Shape, 1f, 1f);
                shapeThumbnail.Save(thumbnailPath, Aspose.Slides.ImageFormat.Png);
            }

            // Save the modified presentation and refresh its thumbnail
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx, new Aspose.Slides.Export.PptxOptions { RefreshThumbnail = true });
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            // Format not supported
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}