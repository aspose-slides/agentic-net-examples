// -----------------------------------------------------------------------------
// Example: Add rectangle picture fill crop region using C#
//
// Description:
// Demonstrates how to add a rectangle shape with a picture fill and crop the
// picture region using C# and Aspose.Slides for .NET. The example creates a new
// presentation, inserts an image as a picture fill for a rectangle, applies
// cropping to focus on a specific area, and saves the result as a PPTX file.
// This pattern can be used to automate PowerPoint image manipulation tasks.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Rectangle, Picture, Fill, Crop,
// Presentation Processing, Office Automation
//
// Use Cases:
// - Automate adding rectangle shapes with picture fills and custom crop regions.
// - Build C# utilities for PowerPoint image processing and layout adjustments.
// - Generate or modify PPTX files programmatically in .NET applications.
// - Validate picture fill and cropping behavior before publishing presentations.
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
            // Define paths
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string imagePath = Path.Combine(dataDir, "image.jpg");
            string outputPath = Path.Combine(dataDir, "output.pptx");

            // Ensure data directory exists
            if (!Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            // Check if the input image exists
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Input image file not found: " + imagePath);
                return;
            }

            try
            {
                // Create a new presentation
                Presentation presentation = new Presentation();

                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Load the image
                IImage img = Images.FromFile(imagePath);
                IPPImage ppImg = presentation.Images.AddImage(img);

                // Add a rectangle shape
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 300);

                // Apply picture fill to the rectangle
                shape.FillFormat.FillType = FillType.Picture;
                IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                picFill.Picture.Image = ppImg;

                // Crop the picture within the shape to focus on a region
                picFill.CropTop = 0.1f;    // Crop 10% from top
                picFill.CropBottom = 0.1f; // Crop 10% from bottom
                picFill.CropLeft = 0.2f;   // Crop 20% from left
                picFill.CropRight = 0.2f;  // Crop 20% from right

                // Save the presentation
                presentation.Save(outputPath, SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                // Handle unsupported format or other errors
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
