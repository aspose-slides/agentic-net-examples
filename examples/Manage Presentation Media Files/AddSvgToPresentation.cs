using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main(string[] args)
    {
        // Load or create a presentation
        using (Presentation presentation = new Presentation())
        {
            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Read SVG content from a file
            string svgContent = File.ReadAllText("example.svg");

            // Create an SVG image object
            ISvgImage svgImage = new SvgImage(svgContent);

            // Add the SVG as a group shape to the slide
            IGroupShape groupShape = slide.Shapes.AddGroupShape(svgImage, 50f, 50f, 400f, 300f);

            // Save the presentation to PPTX format
            presentation.Save("OutputPresentation.pptx", SaveFormat.Pptx);
        }
    }
}