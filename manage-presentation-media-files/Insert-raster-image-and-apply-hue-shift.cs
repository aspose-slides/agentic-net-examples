// -----------------------------------------------------------------------------
// Example: Insert raster image and apply hue shift using C#
//
// Description:
// Demonstrates how to insert a raster image into a slide and apply a hue‑shift
// effect using Aspose.Slides for .NET. The example creates a new presentation,
// adds a picture frame with the specified image, modifies its color using an
// HSL transformation, and saves the result as a PPTX file.
//
// Keywords:
// C#, PowerPoint, PPTX, Aspose.Slides for .NET, Insert, Raster Image, Hue Shift,
// Image Transform, Presentation Processing, Office Automation
//
// Use Cases:
// - Automate insertion of raster images with color adjustments into PowerPoint.
// - Build .NET tools for applying visual effects to slide content.
// - Generate or modify PPTX files programmatically with hue‑shift effects.
// - Validate image processing workflows in presentation automation.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string inputPath = Path.Combine("Data", "image.jpg");
        string outputPath = Path.Combine("Output", "result.pptx");

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Insert the raster image as a picture frame
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            50, 50, 400, 300,
            presentation.Images.AddImage(File.ReadAllBytes(inputPath)));

        // Access the image transform collection
        Aspose.Slides.Effects.IImageTransformOperationCollection imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

        // Apply a hue‑shift effect (e.g., shift hue by 30 degrees)
        imageTransform.AddHSLEffect(30f, 0f, 0f);

        // Save the presentation
        try
        {
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle format not supported or other saving errors
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}
