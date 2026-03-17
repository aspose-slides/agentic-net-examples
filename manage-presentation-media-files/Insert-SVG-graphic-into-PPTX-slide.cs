using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace InsertSvgDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a new presentation
                using (Presentation presentation = new Presentation())
                {
                    // Get the first slide
                    ISlide slide = presentation.Slides[0];

                    // Read SVG content from file
                    string svgPath = "graphic.svg";
                    string svgContent = File.ReadAllText(svgPath);

                    // Create SVG image object
                    ISvgImage svgImage = new SvgImage(svgContent);

                    // Add SVG image to the presentation's image collection
                    IPPImage picture = presentation.Images.AddImage(svgImage);

                    // Define position and size for the picture
                    float x = 100;
                    float y = 100;
                    float width = 400;
                    float height = 300;

                    // Add picture frame to the slide
                    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, x, y, width, height, picture);

                    // Save the presentation
                    presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}