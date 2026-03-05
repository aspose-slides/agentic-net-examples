using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

class Program
{
    static void Main()
    {
        // Create a new presentation
        using (Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation())
        {
            // Load SVG content from file
            string svgContent = System.IO.File.ReadAllText("input.svg");
            Aspose.Slides.ISvgImage svgImage = new Aspose.Slides.SvgImage(svgContent);

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add the SVG as a group shape (position and size can be adjusted)
            Aspose.Slides.IGroupShape groupShape = slide.Shapes.AddGroupShape(svgImage, 0f, 0f, 500f, 500f);

            // Save the presentation as PDF
            presentation.Save("output.pdf", Aspose.Slides.Export.SaveFormat.Pdf);
        }
    }
}