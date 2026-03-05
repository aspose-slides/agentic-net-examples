using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Add a rectangle shape to the slide
        Aspose.Slides.IAutoShape shape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300);

        // Path to the image file
        string imagePath = "sample.jpg";

        // Load the image and add it to the presentation's image collection
        using (FileStream imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            Aspose.Slides.IPPImage image = presentation.Images.AddImage(imageStream);

            // Set the shape's fill to the picture
            shape.FillFormat.FillType = Aspose.Slides.FillType.Picture;
            shape.FillFormat.PictureFillFormat.PictureFillMode = Aspose.Slides.PictureFillMode.Stretch;
            shape.FillFormat.PictureFillFormat.Picture.Image = image;
        }

        // Save the presentation
        presentation.Save("SetImageFill.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}