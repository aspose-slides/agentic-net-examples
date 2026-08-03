// -----------------------------------------------------------------------------
// Example: Apply picture fill shape image collection using C#
//
// Description:
// Demonstrates how to load an external image file, add it to a presentation's
// image collection, and apply that image as a tiled picture fill to a rectangle
// shape using Aspose.Slides for .NET. The example creates a new PPTX file,
// configures picture fill properties such as tile mode, alignment, and flip,
// and saves the result to the Data folder.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Apply, Picture Fill, Shape,
// Image Collection, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate applying picture fill to shapes from an image collection.
// - Build C# utilities for customizing slide graphics programmatically.
// - Generate or modify PPTX files with tiled image backgrounds in .NET apps.
// - Validate picture fill settings before publishing presentations.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define directories and file paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string imagePath = Path.Combine(dataDir, "image.jpg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Ensure data directory exists
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Verify that the image file exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = pres.Slides[0];

            // Load image from file and add it to the presentation's image collection
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

            // Add a rectangle shape to the slide
            Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(
                Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

            // Apply picture fill to the shape using the image from the collection
            shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            Aspose.Slides.IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
            picFill.Picture.Image = ppImg;
            picFill.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;
            picFill.TileOffsetX = 0f;
            picFill.TileOffsetY = 0f;
            picFill.TileScaleX = 1f;
            picFill.TileScaleY = 1f;
            picFill.TileAlignment = Aspose.Slides.RectangleAlignment.BottomRight;
            picFill.TileFlip = Aspose.Slides.TileFlip.FlipBoth;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
