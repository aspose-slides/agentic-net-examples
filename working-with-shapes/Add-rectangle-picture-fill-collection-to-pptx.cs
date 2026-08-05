// -----------------------------------------------------------------------------
// Example: Add rectangle picture fill collection to pptx using C#
//
// Description:
// Demonstrates how to add rectangle picture fill collection to pptx using C# 
// and Aspose.Slides for .NET. The example shows the required 
// presentation-processing steps for PowerPoint files and produces the 
// requested output in a standalone console application. Developers can use 
// this pattern to automate PPTX workflows, validate results, or integrate 
// presentation logic into .NET applications.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Picture, Fill, 
// Collection, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate add rectangle picture fill collection to pptx.
// - Build C# tools for PowerPoint presentation processing.
// - Generate or transform PPTX files in .NET applications.
// - Validate presentation workflows before publishing or integration.
// -----------------------------------------------------------------------------

using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Output directory and file
        string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
        if (!Directory.Exists(outputDir))
            Directory.CreateDirectory(outputDir);
        string outputPath = Path.Combine(outputDir, "RectanglesWithPictureFill.pptx");

        // Image files to use
        string[] imageFiles = new string[]
        {
            "image1.jpg",
            "image2.jpg",
            "image3.jpg"
        };

        // Create a new presentation
        Presentation pres = new Presentation();

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Rectangle layout parameters
        int startX = 50;
        int startY = 50;
        int rectWidth = 200;
        int rectHeight = 150;
        int verticalSpacing = 200;

        for (int i = 0; i < imageFiles.Length; i++)
        {
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), imageFiles[i]);

            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                continue;
            }

            try
            {
                // Load image and add to presentation
                IImage img = Images.FromFile(imagePath);
                IPPImage ppImg = pres.Images.AddImage(img);

                // Add rectangle shape
                int posY = startY + i * verticalSpacing;
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, startX, posY, rectWidth, rectHeight);
                shape.FillFormat.FillType = FillType.Picture;

                // Configure picture fill
                IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                picFill.Picture.Image = ppImg;
                picFill.PictureFillMode = PictureFillMode.Tile;
                picFill.TileOffsetX = 0f;
                picFill.TileOffsetY = 0f;
                picFill.TileScaleX = 1f;
                picFill.TileScaleY = 1f;
                picFill.TileAlignment = RectangleAlignment.BottomRight;
                picFill.TileFlip = TileFlip.FlipBoth;
            }
            catch (NotSupportedException)
            {
                // Image format not supported
                Console.WriteLine("Image format not supported for file: " + imagePath);
            }
            catch (Exception ex)
            {
                // General error handling
                Console.WriteLine("Error processing image: " + imagePath);
                Console.WriteLine(ex.Message);
            }
        }

        // Save the presentation
        pres.Save(outputPath, SaveFormat.Pptx);
        pres.Dispose();
    }
}
