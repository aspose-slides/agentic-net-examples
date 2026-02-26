using System;
using Aspose.Slides;
using System.Drawing.Imaging;

class Program
{
    static void Main()
    {
        // Load the presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation("input.pptx");

        // Access the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Access the first shape on the slide
        Aspose.Slides.IShape shape = slide.Shapes[0];

        // Generate a thumbnail image of the shape
        Aspose.Slides.IImage shapeImage = shape.GetImage();

        // Save the thumbnail as a JPEG file
        shapeImage.Save("shape_thumbnail.jpg", ImageFormat.Jpeg);

        // Save the presentation before exiting
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}