using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgToPresentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source SVG file
            string svgPath = "example.svg";

            // Path to the output PPTX file
            string outputPath = "PresentationWithSvg.pptx";

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Load the SVG image from file
                Aspose.Slides.SvgImage svgImage = new Aspose.Slides.SvgImage(svgPath);

                // Add the SVG image to the presentation's image collection
                Aspose.Slides.IPPImage addedImage = presentation.Images.AddImage(svgImage);

                // Insert the SVG image onto the first slide as a picture frame
                Aspose.Slides.ISlide firstSlide = presentation.Slides[0];
                firstSlide.Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    50f,   // X position
                    50f,   // Y position
                    400f,  // Width
                    300f,  // Height
                    addedImage);

                // Save the presentation to disk
                presentation.Save(outputPath, Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}