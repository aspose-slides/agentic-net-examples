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
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Access the first (default) slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Open the SVG file as a stream
            FileStream svgStream = new FileStream("image.svg", FileMode.Open, FileAccess.Read);

            // Add the SVG image to the presentation's image collection
            Aspose.Slides.IPPImage svgImage = presentation.Images.AddImage(svgStream);

            // Insert the SVG as a picture frame (vector shape) onto the slide
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 500, 400, svgImage);

            // Close the SVG stream
            svgStream.Close();

            // Save the presentation to a PPTX file
            presentation.Save("output.pptx", SaveFormat.Pptx);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}