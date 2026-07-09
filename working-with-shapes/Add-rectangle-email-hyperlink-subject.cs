using System;
using Aspose.Slides;
using Aspose.Slides.Export;

namespace HyperlinkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new presentation
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            IAutoShape rectangle = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 50);

            // Add a text frame with display text
            rectangle.AddTextFrame("Send Email");

            // Define mailto hyperlink with subject
            string mailtoUrl = "mailto:example@example.com?subject=Hello%20World";

            // Set external hyperlink on click
            rectangle.HyperlinkManager.SetExternalHyperlinkClick(mailtoUrl);

            // Save the presentation
            presentation.Save("EmailHyperlink.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
        }
    }
}