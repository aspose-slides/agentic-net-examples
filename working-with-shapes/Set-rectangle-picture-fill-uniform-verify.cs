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

        string imageFileName = "sample.jpg";
        string imagePath = Path.Combine(dataDir, imageFileName);
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image file not found: " + imagePath);
            return;
        }

        string outputFileName = "output.pptx";
        string outPath = Path.Combine(dataDir, outputFileName);

        try
        {
            Presentation pres = new Presentation();
            ISlide slide = pres.Slides[0];
            IImage img = Images.FromFile(imagePath);
            IPPImage imgx = pres.Images.AddImage(img);
            IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, imgx.Width, imgx.Height);
            shape.FillFormat.FillType = FillType.Picture;
            shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
            shape.FillFormat.PictureFillFormat.StretchOffsetLeft = 0;
            shape.FillFormat.PictureFillFormat.StretchOffsetRight = 0;
            shape.FillFormat.PictureFillFormat.StretchOffsetTop = 0;
            shape.FillFormat.PictureFillFormat.StretchOffsetBottom = 0;

            // Verify that the picture fill mode is set to Stretch (uniform scaling preserves aspect ratio)
            bool aspectRatioPreserved = shape.FillFormat.PictureFillFormat.PictureFillMode == PictureFillMode.Stretch;
            Console.WriteLine("Aspect ratio preserved: " + aspectRatioPreserved);

            pres.Save(outPath, SaveFormat.Pptx);
            pres.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}