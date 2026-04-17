using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string imagePath = Path.Combine(dataDir, "image.jpg");
        string outputPath = Path.Combine(dataDir, "output.pptx");

        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }

        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        try
        {
            using (Presentation pres = new Presentation())
            {
                ISlide slide = pres.Slides[0];
                IImage img = Images.FromFile(imagePath);
                IPPImage ppImg = pres.Images.AddImage(img);
                IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 300);
                shape.FillFormat.FillType = FillType.Picture;
                IPictureFillFormat picFill = shape.FillFormat.PictureFillFormat;
                picFill.Picture.Image = ppImg;
                picFill.PictureFillMode = PictureFillMode.Tile;
                // Picture fill transparency is not directly supported; adjust the image alpha before adding if needed.

                pres.Save(outputPath, SaveFormat.Pptx);
            }
        }
        catch (NotSupportedException)
        {
            // Format not supported
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}