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
                // Create a new presentation
                Presentation pres = new Presentation();

                // Path to the SVG file
                string svgPath = "image.svg";

                // Add the SVG image to the presentation's image collection
                using (FileStream svgStream = new FileStream(svgPath, FileMode.Open, FileAccess.Read))
                {
                    // Keep the stream locked to avoid file access issues
                    IPPImage svgImage = pres.Images.AddImage(svgStream, LoadingStreamBehavior.KeepLocked);

                    // Add the image to the first slide as a picture frame
                    // Parameters: shape type, X, Y, width, height, image
                    pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 300, svgImage);
                }

                // Save the presentation to a PPTX file
                pres.Save("output.pptx", SaveFormat.Pptx);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}