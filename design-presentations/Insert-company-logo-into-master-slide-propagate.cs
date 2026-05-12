using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Paths
        string dataDir = "Data";
        string imageFileName = "logo.png";
        string outputFile = "PresentationWithLogo.pptx";

        // Ensure data directory exists
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        string imagePath = Path.Combine(dataDir, imageFileName);

        // Verify image file exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        // Create a new presentation
        var pres = new Aspose.Slides.Presentation();

        // Add image to presentation
        var imageBytes = File.ReadAllBytes(imagePath);
        var img = pres.Images.AddImage(imageBytes);

        // Get master slide from the first slide's layout
        var masterSlide = pres.Slides[0].LayoutSlide.MasterSlide;

        // Insert logo onto master slide (will appear on all derived slides)
        masterSlide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 10, 10, img.Width, img.Height, img);

        // Save presentation
        pres.Save(outputFile, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}