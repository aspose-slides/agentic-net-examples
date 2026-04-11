using System;
using System.IO;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define data directory
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Define image file name and path
        string imageFileName = "sample.jpg";
        string imagePath = Path.Combine(dataDir, imageFileName);

        // Check if image file exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        // Define output presentation path
        string outputPath = Path.Combine(dataDir, "output.pptx");

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Load image and add to presentation resources
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage imgx = pres.Images.AddImage(img);

            // Add picture frame with original image size
            Aspose.Slides.IPictureFrame pf = pres.Slides[0].Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                50f, 50f,
                imgx.Width, imgx.Height,
                imgx);

            // Apply relative scaling: 150% width, 80% height
            pf.RelativeScaleWidth = 1.5f;
            pf.RelativeScaleHeight = 0.8f;

            // Save the presentation
            pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            // Handle any errors (e.g., unsupported format)
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}