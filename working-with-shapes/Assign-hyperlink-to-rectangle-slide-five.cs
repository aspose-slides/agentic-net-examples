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
            Presentation presentation = new Presentation();

            // Get the first slide
            ISlide slide = presentation.Slides[0];

            // Add a rectangle shape
            IAutoShape shape = (IAutoShape)slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 50);

            // Add a text frame to the shape (optional)
            shape.AddTextFrame("Go to Slide 5");

            // Ensure that slide five exists; add empty slides if necessary
            while (presentation.Slides.Count < 5)
            {
                presentation.Slides.AddEmptySlide(presentation.Slides[0].LayoutSlide);
            }

            // Get the target slide (slide index is zero‑based, so index 4 is slide five)
            ISlide targetSlide = presentation.Slides[4];

            // Set an internal hyperlink on the shape that navigates to slide five
            shape.HyperlinkManager.SetInternalHyperlinkClick(targetSlide);

            // Save the presentation
            presentation.Save("HyperlinkToSlide5.pptx", SaveFormat.Pptx);
        }
    }
}