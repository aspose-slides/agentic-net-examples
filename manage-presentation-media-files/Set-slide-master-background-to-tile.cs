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

        // Verify that the pattern image exists
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Pattern image not found: " + imagePath);
            return;
        }

        try
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Set the master slide background to use picture fill
            presentation.Masters[0].Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
            presentation.Masters[0].Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;

            // Load the image and add it to the presentation's image collection
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage ppImg = presentation.Images.AddImage(img);

            // Configure picture fill format for tiling
            Aspose.Slides.IPictureFillFormat picFill = presentation.Masters[0].Background.FillFormat.PictureFillFormat;
            picFill.Picture.Image = ppImg;
            picFill.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;
            picFill.TileAlignment = Aspose.Slides.RectangleAlignment.BottomRight;

            // Save the presentation
            presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            // Handle unsupported format or other errors
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}