using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Input image file path
        string inputFilePath = "image.jpg";
        // Output presentation file path
        string outputFilePath = "result.pptx";

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add image to the presentation's image collection
        byte[] imageData = System.IO.File.ReadAllBytes(inputFilePath);
        Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

        // Fill the shape with the added image
        shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
        shape.FillFormat.PictureFillFormat.Picture.Image = img;

        // Save the presentation
        pres.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);
        pres.Dispose();
    }
}