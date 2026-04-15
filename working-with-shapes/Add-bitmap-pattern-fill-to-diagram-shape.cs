using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Define paths
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string imagePath = Path.Combine(dataDir, "pattern.png");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        // Ensure data directory exists
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        // Verify input image exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file does not exist: " + imagePath);
            return;
        }

        // Create a new presentation
        Presentation pres = null;
        try
        {
            pres = new Presentation();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to create presentation: " + ex.Message);
            return;
        }

        // Get the first slide
        ISlide slide = pres.Slides[0];

        // Load the bitmap image
        IImage img = null;
        try
        {
            img = Images.FromFile(imagePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unsupported image format or error loading image: " + ex.Message);
            return;
        }

        // Add image to presentation's image collection
        IPPImage ppImg = pres.Images.AddImage(img);

        // Retrieve or create a diagram shape
        LegacyDiagram diagram = null;
        if (slide.Shapes.Count > 0)
        {
            diagram = slide.Shapes[0] as LegacyDiagram;
        }
        if (diagram == null)
        {
            // If no diagram shape exists, add a rectangle as a placeholder and treat it as a diagram
            IShape placeholder = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 300);
            diagram = placeholder as LegacyDiagram;
        }

        // Apply picture fill with tile mode using the bitmap image
        if (diagram != null && diagram.FillFormat != null)
        {
            diagram.FillFormat.FillType = FillType.Picture;
            IPictureFillFormat picFill = diagram.FillFormat.PictureFillFormat;
            picFill.Picture.Image = ppImg;
            picFill.PictureFillMode = PictureFillMode.Tile;
        }

        // Save the presentation
        try
        {
            pres.Save(outputPath, SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving presentation: " + ex.Message);
        }
    }
}