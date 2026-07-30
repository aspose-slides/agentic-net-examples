// -----------------------------------------------------------------------------
// Example: Add proportional scaling to picture frame using C#
//
// Description:
// Demonstrates how to add a picture frame to a slide and set its relative
// scaling properties to maintain the original image proportions using
// Aspose.Slides for .NET. The example creates a new presentation, loads an
// image from the file system, inserts it as a picture frame, applies 100%
// relative height and width scaling, and saves the result as a PPTX file.
// This pattern can be used to ensure consistent image rendering across
// different devices and slide dimensions.
//
// Keywords:
// C#, Aspose.Slides, PowerPoint, PPTX, picture frame, proportional scaling,
// RelativeScaleHeight, RelativeScaleWidth, image insertion, presentation
// automation
//
// Use Cases:
// - Insert images into slides while preserving their aspect ratio.
// - Apply uniform scaling to picture frames for consistent display.
// - Automate generation of PowerPoint files with correctly scaled graphics.
// - Build .NET tools that process and export presentations with image handling.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        string inputImagePath = Path.Combine(dataDir, "sample.jpg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        if (!File.Exists(inputImagePath))
        {
            Console.WriteLine("Input image not found: " + inputImagePath);
            return;
        }

        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Load image and add to presentation resources
            IImage img = Images.FromFile(inputImagePath);
            IPPImage image = presentation.Images.AddImage(img);

            // Add picture frame to the first slide
            IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                ShapeType.Rectangle,
                50,
                50,
                image.Width,
                image.Height,
                image);

            // Set relative scaling to keep proportions on different devices
            pictureFrame.RelativeScaleHeight = 1.0f; // 100%
            pictureFrame.RelativeScaleWidth = 1.0f;  // 100%

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();

            Console.WriteLine("Presentation saved to " + outputPath);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
