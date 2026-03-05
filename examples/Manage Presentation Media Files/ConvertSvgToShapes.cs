using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace SvgToPptx
{
    class Program
    {
        static void Main(string[] args)
        {
            // Path to the source SVG file
            string svgPath = "input.svg";

            // Read SVG content from file
            string svgContent = File.ReadAllText(svgPath);

            // Create an SVG image object from the content
            Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

            // Create a new presentation
            using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
            {
                // Get the first slide
                Aspose.Slides.ISlide slide = presentation.Slides[0];

                // Add the SVG as a group shape to the slide (position and size can be adjusted)
                Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape(svgImage, 0f, 0f, 500f, 500f);

                // Save the presentation to a PPTX file
                presentation.Save("output.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
            }
        }
    }
}