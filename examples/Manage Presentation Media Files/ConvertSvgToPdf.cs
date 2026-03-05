using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgToShapesExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the SVG file
            string svgFilePath = "example.svg";

            // Read SVG content from file
            string svgContent = File.ReadAllText(svgFilePath);

            // Create an SVG image object from the content
            ISvgImage svgImage = new SvgImage(svgContent);

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide in the presentation
                ISlide slide = presentation.Slides[0];

                // Add a group shape to the slide by converting the SVG image into shapes
                // Parameters: SVG image, X position, Y position, width, height
                IGroupShape groupShape = slide.Shapes.AddGroupShape(svgImage, 0f, 0f, 500f, 500f);

                // Save the presentation as a PDF file
                presentation.Save("output.pdf", SaveFormat.Pdf);
            }
        }
    }
}