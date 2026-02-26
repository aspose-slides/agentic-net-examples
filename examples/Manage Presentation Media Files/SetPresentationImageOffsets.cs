using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Define data directory
        string dataDir = "Data";
        if (!Directory.Exists(dataDir))
            Directory.CreateDirectory(dataDir);

        // Image file name and path
        string imageFileName = "example.jpg";
        string imagePath = Path.Combine(dataDir, imageFileName);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Load image from file and add it to the presentation's image collection
        Aspose.Slides.IImage img = Aspose.Slides.Images.FromFile(imagePath);
        Aspose.Slides.IPPImage imgx = pres.Images.AddImage(img);

        // Define shape position and size
        float x = 50f;
        float y = 50f;
        float width = 400f;
        float height = 300f;

        // Add a rectangle auto shape
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, x, y, width, height);

        // Set picture fill with stretch mode and specify offsets
        shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
        shape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
        shape.FillFormat.PictureFillFormat.Picture.Image = imgx;
        shape.FillFormat.PictureFillFormat.StretchOffsetLeft = 10f;    // 10% inset from left
        shape.FillFormat.PictureFillFormat.StretchOffsetRight = 10f;   // 10% inset from right
        shape.FillFormat.PictureFillFormat.StretchOffsetTop = 5f;      // 5% inset from top
        shape.FillFormat.PictureFillFormat.StretchOffsetBottom = 5f;   // 5% inset from bottom

        // Save the presentation
        string outPath = Path.Combine(dataDir, "output.pptx");
        pres.Save(outPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Dispose the presentation
        pres.Dispose();
    }
}