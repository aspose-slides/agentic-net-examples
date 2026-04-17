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