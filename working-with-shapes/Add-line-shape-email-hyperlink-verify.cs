using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Aspose.Slides.Presentation presentation = new Aspose.Slides.Presentation();

            // Get the first slide
            Aspose.Slides.ISlide slide = presentation.Slides[0];

            // Add a line shape to the slide
            Aspose.Slides.IShape lineShape = slide.Shapes.AddAutoShape(Aspose.Slides.ShapeType.Line, 100, 100, 300, 0);

            // Assign a hyperlink that opens an email with a subject line
            lineShape.HyperlinkManager.SetExternalHyperlinkClick("mailto:someone@example.com?subject=Hello%20World");

            // Save the presentation
            presentation.Save("LineHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}