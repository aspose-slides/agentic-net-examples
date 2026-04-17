using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string dataDir = Directory.GetCurrentDirectory();
            string imagePath = Path.Combine(dataDir, "pattern.png");
            if (!File.Exists(imagePath))
            {
                Console.WriteLine("Image file not found: " + imagePath);
                return;
            }

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Load image and add to presentation images collection
            Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
            Aspose.Slides.IPPImage ppImg = pres.Images.AddImage(img);

            // Apply tiled picture background to each slide
            foreach (Aspose.Slides.ISlide slide in pres.Slides)
            {
                slide.Background.Type = Aspose.Slides.BackgroundType.OwnBackground;
                slide.Background.FillFormat.FillType = Aspose.Slides.FillType.Picture;
                slide.Background.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Tile;
                slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImg;
            }

            // Save the presentation
            string outPath = Path.Combine(dataDir, "TiledBackground.pptx");
            pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);
        }
        catch (NotSupportedException)
        {
            // Format not supported
            Console.WriteLine("The specified file format is not supported.");
        }
        catch (Exception ex)
        {
            // General exception handling
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}