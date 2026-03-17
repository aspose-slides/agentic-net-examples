using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace AsposeSlidesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input SVG file path
                System.String svgPath = "input.svg";
                // Output PPTX file path
                System.String outPptxPath = "output.pptx";

                // Read SVG content
                System.String svgContent = System.IO.File.ReadAllText(svgPath);

                // Create a new presentation
                using (Aspose.Slides.Presentation pres = new Aspose.Slides.Presentation())
                {
                    // Create an ISvgImage from the SVG content
                    Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

                    // Add the SVG image to the presentation's image collection
                    Aspose.Slides.IPPImage ppImage = pres.Images.AddImage(svgImage);

                    // Insert the image as a picture frame on the first slide
                    pres.Slides[0].Shapes.AddPictureFrame(
                        Aspose.Slides.ShapeType.Rectangle,
                        0,
                        0,
                        ppImage.Width,
                        ppImage.Height,
                        ppImage);

                    // Save the presentation
                    pres.Save(outPptxPath, Aspose.Slides.Export.SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}