using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Load SVG content from a file
        string svgPath = "content.svg";
        string svgContent = System.IO.File.ReadAllText(svgPath);

        // Create an SvgImage object from the SVG content
        Aspose.Slides.SvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

        // Add the SVG image to the presentation's image collection
        Aspose.Slides.IPPImage addedImage = pres.Images.AddImage(svgImage);

        // Get the first slide
        Aspose.Slides.ISlide slide = pres.Slides[0];

        // Define position and size for the picture frame
        float x = 50f;
        float y = 50f;
        float width = 400f;
        float height = 300f;

        // Insert the SVG image as a picture frame on the slide
        Aspose.Slides.IPictureFrame pictureFrame = slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, x, y, width, height, addedImage);

        // Save the presentation to a PPTX file
        pres.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}