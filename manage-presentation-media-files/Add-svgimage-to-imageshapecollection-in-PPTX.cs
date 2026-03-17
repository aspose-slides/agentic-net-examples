using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        try
        {
            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Path to the SVG file
                string svgPath = "example.svg";

                // Instantiate the SVG image
                Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgPath);

                // Add the SVG image to the presentation's image collection
                Aspose.Slides.IPPImage addedImage = presentation.Images.AddImage(svgImage);

                // Add a picture frame to the first slide using the added image
                presentation.Slides[0].Shapes.AddPictureFrame(
                    Aspose.Slides.ShapeType.Rectangle,
                    0,
                    0,
                    400,
                    300,
                    addedImage);

                // Save the presentation
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}