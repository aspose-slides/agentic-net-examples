using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Input image file path
        string imagePath = "input.png";
        // Output presentation file path
        string outputPath = "output.pptx";

        // Read image bytes from file
        byte[] imageData = File.ReadAllBytes(imagePath);

        // Create a new presentation
        Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

        // Add the image to the presentation's image collection
        Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

        // Get the first slide (or create one if none exist)
        Aspose.Slides.ISlide slide;
        if (pres.Slides.Count > 0)
        {
            slide = pres.Slides[0];
        }
        else
        {
            slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank));
        }

        // Add a picture frame that displays the added image, covering the whole slide
        slide.Shapes.AddPictureFrame(
            Aspose.Slides.ShapeType.Rectangle,
            0,
            0,
            pres.SlideSize.Size.Width,
            pres.SlideSize.Size.Height,
            img);

        // Save the presentation in PPTX format
        pres.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);

        // Clean up resources
        pres.Dispose();
    }
}