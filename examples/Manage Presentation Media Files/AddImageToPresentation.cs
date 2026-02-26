using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace ManagePresentationMediaFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the image file to be added to the presentation
            string inputFilePath = "image.png";

            // Path where the resulting PPTX will be saved
            string outputFilePath = "output.pptx";

            // Read image bytes from file
            byte[] imageData = File.ReadAllBytes(inputFilePath);

            // Create a new presentation
            Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation();

            // Add the image to the presentation's image collection
            Aspose.Slides.IPPImage img = pres.Images.AddImage(imageData);

            // Get the first slide (or create one if none exist)
            Aspose.Slides.ISlide slide;
            if (pres.Slides.Count > 0)
                slide = pres.Slides[0];
            else
                slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(Aspose.Slides.SlideLayoutType.Blank));

            // Add a picture frame that covers the whole slide using the added image
            slide.Shapes.AddPictureFrame(
                Aspose.Slides.ShapeType.Rectangle,
                0,
                0,
                pres.SlideSize.Size.Width,
                pres.SlideSize.Size.Height,
                img);

            // Save the presentation in PPTX format
            pres.Save(outputFilePath, Aspose.Slides.Export.SaveFormat.Pptx);

            // Clean up resources
            pres.Dispose();
        }
    }
}