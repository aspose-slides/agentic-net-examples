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
            // Paths for the source SVG and the output PPTX
            string svgFilePath = "heading.svg";
            string outputPptxPath = "output.pptx";

            // Create a new presentation
            using (Presentation presentation = new Presentation())
            {
                // Get the first slide
                ISlide slide = presentation.Slides[0];

                // Load SVG content from file and create an SvgImage object
                string svgContent = File.ReadAllText(svgFilePath);
                ISvgImage svgImage = new SvgImage(svgContent);

                // Convert the SVG image into a group of shapes and add it to the slide
                // Parameters: svgImage, x, y, width, height
                IGroupShape groupShape = slide.Shapes.AddGroupShape(svgImage, 0f, 0f, 500f, 100f);

                // Save the presentation to a PPTX file
                presentation.Save(outputPptxPath, SaveFormat.Pptx);
            }
        }
    }
}