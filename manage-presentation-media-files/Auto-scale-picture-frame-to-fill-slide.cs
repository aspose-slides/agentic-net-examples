using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Prepare data directory
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Input image path
        string imageFileName = "sample.jpg";
        string imagePath = Path.Combine(dataDir, imageFileName);
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        // Output presentation path
        string outputPath = Path.Combine(dataDir, "output.pptx");

        try
        {
            // Create a new presentation
            Presentation presentation = new Presentation();
            ISlide slide = presentation.Slides[0];

            // Load image and add to presentation resources
            IImage img = Images.FromFile(imagePath);
            IPPImage imgx = presentation.Images.AddImage(img);

            // Add picture frame that covers the whole slide
            float slideWidth = presentation.SlideSize.Size.Width;
            float slideHeight = presentation.SlideSize.Size.Height;
            IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight, imgx);

            // Set relative scaling to fill slide while maintaining aspect ratio
            pictureFrame.RelativeScaleHeight = 1.0f;
            pictureFrame.RelativeScaleWidth = 1.0f;

            // Save the presentation
            presentation.Save(outputPath, SaveFormat.Pptx);
            presentation.Dispose();
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}