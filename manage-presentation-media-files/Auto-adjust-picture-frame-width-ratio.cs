// -----------------------------------------------------------------------------
// Example: Auto adjust picture frame width ratio using C#
//
// Description:
// Demonstrates how to automatically adjust a picture frame's width ratio
// based on the slide's aspect ratio using C# and Aspose.Slides for .NET.
// The example creates a new presentation, inserts an image as a picture
// frame, computes the slide aspect ratio, applies the ratio to the picture
// frame's width scaling while preserving its height, locks the aspect ratio,
// and saves the result as a PPTX file.
//
// Keywords:
// C#, Aspose.Slides for .NET, PowerPoint, PPTX, picture frame, width ratio,
// aspect ratio, slide size, image insertion, presentation automation
//
// Use Cases:
// - Adjust picture frame dimensions dynamically according to slide size.
// - Build .NET utilities that modify image scaling in PowerPoint files.
// - Automate preparation of presentations with consistent visual layout.
// - Validate and transform PPTX media assets programmatically.
// -----------------------------------------------------------------------------
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define data directory and file paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }
        string imagePath = Path.Combine(dataDir, "sample.jpg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Verify that the image file exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Load the image and add it to the presentation's image collection
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage imgx = presentation.Images.AddImage(img);

            // Add a picture frame to the first slide
            Aspose.Slides.IPictureFrame pictureFrame = presentation.Slides[0].Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                50f, 50f,
                imgx.Width, imgx.Height,
                imgx);

            // Calculate slide aspect ratio
            float slideWidth = presentation.SlideSize.Size.Width;
            float slideHeight = presentation.SlideSize.Size.Height;
            float aspectRatio = slideWidth / slideHeight;

            // Adjust picture frame width based on slide aspect ratio
            pictureFrame.RelativeScaleWidth = aspectRatio;
            pictureFrame.RelativeScaleHeight = 1.0f; // keep original height scale

            // Lock aspect ratio to preserve proportions
            pictureFrame.PictureFrameLock.AspectRatioLocked = true;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
