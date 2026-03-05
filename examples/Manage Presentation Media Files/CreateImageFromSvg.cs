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

        // Load SVG content from a file
        string svgFilePath = "image.svg";
        Aspose.Slides.SvgImage svgImage = new Aspose.Slides.SvgImage(svgFilePath);

        // Add the SVG image to the presentation's image collection
        Aspose.Slides.IPPImage pptxImage = presentation.Images.AddImage(svgImage);

        // Get the first slide
        Aspose.Slides.ISlide slide = presentation.Slides[0];

        // Insert the SVG image as a picture frame on the slide
        slide.Shapes.AddPictureFrame(Aspose.Slides.ShapeType.Rectangle, 50, 50, 400, 300, pptxImage);

        // Save the presentation to a PPTX file
        presentation.Save("OutputPresentation.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}