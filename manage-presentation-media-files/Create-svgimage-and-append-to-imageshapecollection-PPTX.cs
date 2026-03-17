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
            using (Presentation presentation = new Presentation())
            {
                // Read SVG content from a file
                string svgPath = "content.svg";
                string svgContent = File.ReadAllText(svgPath);

                // Instantiate an SvgImage object
                ISvgImage svgImage = new SvgImage(svgContent);

                // Add the SVG image to the presentation's image collection
                IPPImage addedImage = presentation.Images.AddImage(svgImage);

                // Add a picture frame to display the SVG image on the first slide
                ISlide slide = presentation.Slides[0];
                slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 400, 300, addedImage);

                // Save the presentation
                presentation.Save("output.pptx", SaveFormat.Pptx);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}